using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace JoyaMovil.Models
{
    public class WebSocketAccesa
    {
        static ClientWebSocket webSocketAcc;
        string urlWebSocket;
        bool isReconect = false;
        Action<string> methodReceptionWS = null;
        System.Timers.Timer timer = new System.Timers.Timer();

        /****************************************************************************************/
        public WebSocketAccesa(string url, Action<string> methodReception = null, bool autoConect = false)
        {
            webSocketAcc = new ClientWebSocket();
            urlWebSocket = url;
            methodReceptionWS = methodReception;
            isReconect = autoConect;
            //Timer reconexion web socket
            if (autoConect)
            {
                timer.Interval = 500;
                timer.Elapsed += ReconexionAccesa;
                timer.Enabled = true;    //Deshabilitado
                timer.AutoReset = true;  //Modo set interval
            }
        }
        /****************************************************************************************/
        public void CloseAccesa()
        {
            webSocketAcc.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
        }
        /****************************************************************************************/
        public async Task<bool> ConnectAsyncAccesa()
        {
            //Intentar conectar
            try
            {
                await webSocketAcc.ConnectAsync(new Uri(urlWebSocket), CancellationToken.None);
            }
            catch
            {
                //Reconectar como nuevo cliente
                webSocketAcc = new ClientWebSocket();
                return false;
            }

            //Algoritmo de recepcion de datos
            await Task.Factory.StartNew(async () =>
            {
                string receivedMessage = "";

                while (webSocketAcc.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result;
                    var message = new ArraySegment<byte>(new byte[128]);
                    do
                    {
                        result = await webSocketAcc.ReceiveAsync(message, CancellationToken.None);
                        if (result.MessageType != WebSocketMessageType.Text)
                            continue;
                        var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
                        receivedMessage = Encoding.UTF8.GetString(messageBytes);
                        //Console.WriteLine("Received: {0}", receivedMessage);
                    }
                    while (!result.EndOfMessage);
                    //Verificiar si llego dato

                    //Realizar 
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (methodReceptionWS != null)
                            methodReceptionWS(receivedMessage);
                    });
                }
            }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            //Conexion exitosa
            return true;
        }
        /****************************************************************************************/
        public async Task<bool> SendAccesa(string texto)
        {
            try
            {
                //Intentar reconectar si no esta conectado
                if (webSocketAcc.State != WebSocketState.Open)
                    await ConnectAsyncAccesa();
                //Enviar dato si es posible
                if (webSocketAcc.State == WebSocketState.Open)  //Enviar por el puerto
                {
                    byte[] enconded = Encoding.Default.GetBytes(texto);
                    var bufferArray = new ArraySegment<byte>(enconded, 0, enconded.Length);
                    await webSocketAcc.SendAsync(bufferArray, WebSocketMessageType.Text, true, CancellationToken.None);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /****************************************************************************************/
        async void ReconexionAccesa(object sender, ElapsedEventArgs e)
        {
            //Conectar si no estaba conectado o fue cerrada la conexion  
            if (webSocketAcc.State == WebSocketState.None || webSocketAcc.State == WebSocketState.Aborted)
            {
                await ConnectAsyncAccesa();
            }

            //Para depuracion de error
            //if (methodReceptionWS != null)
            //methodReceptionWS(webSocket.State.ToString());
        }
        /****************************************************************************************/
    }
}