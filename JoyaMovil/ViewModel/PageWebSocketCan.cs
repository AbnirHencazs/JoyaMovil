using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.IO;
using JoyaMovil.Models;

namespace JoyaMovil.ViewModel
{
    public class PageWebSocketCan : ContentPage
    {
        WebSocketAccesa ws = new WebSocketAccesa(Settings.urlWebSocket, null, true);
        Enlace enlace = new Enlace();

        //Inicializar
        public PageWebSocketCan()
        {

        }
        /*******************************************************************************/
        public async void FocoCan(string can, string pin, int percent, int time)
        {
            await ws.SendAccesa(enlace.Lampara(can, pin, percent, time));
           
        }
        public async void envioAccesoCochera(string can, string pin, int porcentaje, int tiempo)
        {
            await ws.SendAccesa(enlace.cadenaAccesoCochera(can, pin, porcentaje, tiempo));
        }
        /*******************************************************************************/
        public async void FocoOnOff(ImageButton imageButton)
        {
            string imageName = Path.GetFileName(imageButton.Source.ToString()); //Source => File: path/filename.ext  
            string[] datosFoco = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
            string path = "";
            string can, pin;
            int percent, time;
            //Valirdar los datos
            if (datosFoco.Length < 6)
            {
                await DisplayAlert("ERROR PARAMETERS", "Bad Parameters CAN.\r\nRequired 6 parameters", "OK");
                return;
            }
            //Asignar variables
            can = datosFoco[0];
            pin = datosFoco[1];
            percent = Convert.ToInt16(datosFoco[2]);
            time = Convert.ToInt16(datosFoco[3]);
            //Asignar path si es uwp
            if (Device.RuntimePlatform == Device.UWP && datosFoco.Length >= 7)
                path = datosFoco[6];
            //Cambiar estado del foco
            if (imageName == datosFoco[4])
            {
                imageButton.Source = path + datosFoco[5];
                await ws.SendAccesa(enlace.Lampara(can, pin, percent, time));
            }
            else
            {
                imageButton.Source = path + datosFoco[4];
                await ws.SendAccesa(enlace.Lampara(can, pin, 0, time));
            }
        }
        /*******************************************************************************/
        public async void FocoOnOff(ImageButton imageButton, bool turnOn)
        {
            string[] datosFoco = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
            string can, pin;
            int percent, time;

            //Valirdar los datos
            if (datosFoco.Length < 6)
            {
                await DisplayAlert("ERROR PARAMETERS", "Bad Parameters CAN.\r\nRequired 6 parameters", "OK");
                return;
            }
            //Asignar variables
            can = datosFoco[0];
            pin = datosFoco[1];
            percent = Convert.ToInt16(datosFoco[2]);
            time = Convert.ToInt16(datosFoco[3]);
            //Cambiar estado del foco
            if (turnOn)
                await ws.SendAccesa(enlace.Lampara(can, pin, percent, time));
            else
                await ws.SendAccesa(enlace.Lampara(can, pin, 0, time));
        }
        /*******************************************************************************/
        public async void FocoOnOff(ImageButton imageButton, int xpercent)
        {
            string[] datosFoco = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
            string can, pin;
            int percent, time;

            //Valirdar los datos
            if (datosFoco.Length < 6)
            {
                await DisplayAlert("ERROR PARAMETERS", "Bad Parameters CAN.\r\nRequired 6 parameters", "OK");
                return;
            }
            //Asignar variables
            can = datosFoco[0];
            pin = datosFoco[1];
            percent = Convert.ToInt16(datosFoco[2]);
            time = Convert.ToInt16(datosFoco[3]);
            //Cambiar estado del foco
            await ws.SendAccesa(enlace.Lampara(can, pin, xpercent, time));
        }
        /*******************************************************************************/
        public async void FocoDimeable(Double slider, ImageButton imageButton = null)
        {
            string[] datosFoco;
            string can, pin;
            int percent;
            //Obtener parametros
            /*if (imageButton == null)
                datosFoco = slider.ClassId.ToString().Split(new char[] { ',' });
            else*/
                datosFoco = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
                
            //Valirdar los datos
            if (datosFoco.Length < 2)
            {
                await DisplayAlert("ERROR PARAMETERS", "Bad Parameters CAN.\r\nRequired 2 parameters", "OK");
                return;
            }
            //Asignar variables
            can = datosFoco[0];
            pin = datosFoco[1];
            percent = (int)slider;
            //Enviar porcentaje
            await ws.SendAccesa(enlace.Lampara(can, pin, percent, 0));
        }
        /*******************************************************************************/
        public async void FocoRGB(ImageButton button, Color color)
        {
            string[] datosFoco = button.CommandParameter.ToString().Split(new char[] { ',' });
            string can, pin;

            //Valirdar los datos
            if (datosFoco.Length < 2)
            {
                await DisplayAlert("ERROR PARAMETERS", "Bad Parameters CAN.\r\nRequired 2 parameters", "OK");
                return;
            }
            //Asignar variables
            can = datosFoco[0];
            pin = datosFoco[1];
            //Convertir color en formato 0xFFF
            string rgb = ((int)(color.R * 15)).ToString("X1");
            rgb += ((int)(color.G * 15)).ToString("X1");
            rgb += ((int)(color.B * 15)).ToString("X1");
            //Enviar porcentaje
            await ws.SendAccesa(enlace.LamparaRGB(can, pin, rgb));  //FF1687xxxxxF1E
        }
        /*******************************************************************************/
        public async void FocoRGBOff(string can, string pin)
        {
            await ws.SendAccesa(enlace.LamparaRGB(can, pin, "000"));
        }
    }
}