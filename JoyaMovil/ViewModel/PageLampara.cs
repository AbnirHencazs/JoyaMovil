using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using JoyaMovil.Models;
using System.Collections.ObjectModel;

namespace JoyaMovil.ViewModel
{
    public class PageLampara : ContentPage
    {
        PageWebSocketCan pageWebSocketCan = new PageWebSocketCan();
        int lastvalueSlider = -1;

        /********************************************************************************/
        public PageLampara()
        {

        }
        /********************************************************************************/
        public void AccesoCochera(string can, string pin, int porcentaje, int tiempo)
        {
            pageWebSocketCan.envioAccesoCochera(can, pin, porcentaje, tiempo);
        }
        /********************************************************************************/
        public void FocoCan(string can, string pin, int percent, int time)
        {
            pageWebSocketCan.FocoCan(can, pin, percent, time);
            //Thread.Sleep(Settings.delayApagon);
        }
        /********************************************************************************/
        public bool isChildrenEqual(Grid page, string device, int children)
        {
            int childs = 0;

            //Buscar t odos los focos seleccionado
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton foco = (ImageButton)page.Children[i];
                    //Si es de tipo foco y esta seleccionado
                    if (foco.ClassId == device)
                        childs++;
                }
            }

            return (childs == children);
        }
        /********************************************************************************/
        public void Toogled(ImageButton imgBtn)
        {
            string path = "";
            //No operar objeto nullo
            if (imgBtn == null)
                return;
            //Tooglear elemento
            string[] focoParams = imgBtn.CommandParameter.ToString().Split(new char[] { ',' });
            //Asignar path si es uwp
            path = "";
            if (Device.RuntimePlatform == Device.UWP && focoParams.Length >= 7)
                path = focoParams[6];
            //Cambiar icono a encendido
            if (imgBtn.StyleId.ToString() == "0")
            {
                imgBtn.StyleId = "1";
                imgBtn.Source = path + focoParams[5];
            }
            else
            {
                imgBtn.StyleId = "0";
                imgBtn.Source = path + focoParams[4];
            }
        }
        /********************************************************************************/
        public void ToogledColor(Button destino, Button origen)
        {
            destino.BackgroundColor = origen.BackgroundColor;
        }
        /********************************************************************************/
        public void FocusImageButton(Grid page, string name, ImageButton imgBtn)
        {
            string mostrar = "";
            string path = "";
            //Deselecionar a todos los botones
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton imageButton = (ImageButton)page.Children[i];
                    if (imageButton.ClassId == name)
                    {
                        string[] arguments = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
                        //Asignar path si es uwp
                        if (Device.RuntimePlatform == Device.UWP && arguments.Length >= 7)
                            path = arguments[6];
                        //Cambiar imagen apagada
                        imageButton.StyleId = "0";
                        imageButton.Source = path + arguments[4];
                        mostrar += page.Children[i].GetType().Name + "\r\n";
                    }
                }
            }
            //Selecionar el elemento
            if (imgBtn != null)
            {
                //ImageButton imgBtn = (ImageButton)sender;
                string[] focoParams = imgBtn.CommandParameter.ToString().Split(new char[] { ',' });
                //Asignar path si es uwp
                path = "";
                if (Device.RuntimePlatform == Device.UWP && focoParams.Length >= 7)
                    path = focoParams[6];
                //Cambiar imagen encendida
                imgBtn.StyleId = "1";
                imgBtn.Source = path + focoParams[5];
                //DisplayAlert("Children", mostrar, "Ok");
            }
        }
        /********************************************************************************/
        public async void Turn(Grid page, Grid pageAccion, string device, ImageButton imageButton)
        {
            bool isSelect = false;

            //Buscar todos los focos seleccionado
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton foco = (ImageButton)page.Children[i];
                    //Si es de tipo foco y esta seleccionado
                    if (foco.ClassId == device && (foco.StyleId == "1" || isChildrenEqual(page, device, 1)))
                    {
                        if (!isSelect)
                        {
                            isSelect = true;
                            FocusImageButton(pageAccion, imageButton.ClassId, imageButton);
                        }
                        //Obtengo el porcentaje de encendido
                        string[] commands = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
                        pageWebSocketCan.FocoOnOff(foco, commands[2] == "100");
                        await Task.Delay(Settings.delaySendWS);
                        Toogled(foco);
                    }
                }
            }
            //Si no selecciono algun foco mandar un warning y deseleccionar
            if (!isSelect)
                await DisplayAlert("#Error Device ON/OFF#", "Seleccione un dispositivo", "OK");
        }
        /********************************************************************************/
        public async void Dimmer(Grid page, string device, Slider slider)
        {
            bool isSelect = false;
            //Buscar algun foco seleccionado
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton foco = (ImageButton)page.Children[i];
                    //Si es de tipo foco y esta seleccionado
                    if (foco.ClassId == device && (foco.StyleId == "1" || isChildrenEqual(page, device, 1)))
                    {
                        isSelect = true;
                        int deck = (int)(10 * Math.Round(slider.Value/10));
                        //slider.value  = deck;
                        if(lastvalueSlider != deck)
                        {
                            //Obtengo el porcentaje de encendido
                            pageWebSocketCan.FocoDimeable(deck, foco);
                            await Task.Delay(Settings.delaySendWS);
                            lastvalueSlider = deck;
                        }
                        
                    }
                }
            }
            //Si no selecciono algun foco mandar un warning y deseleccionar
            if (!isSelect)
                await DisplayAlert("#Error Device DIMMER#", "Seleccione un dispositivo", "OK");
        }
        /********************************************************************************/
        public async void Rgb(Grid page, Grid pageAccion, string device, ImageButton imageButton, Button info)
        {
            bool isSelect = false;


            //Buscar algun foco seleccionado
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton foco = (ImageButton)page.Children[i];
                    //Si es de tipo foco y esta seleccionado
                    if (foco.ClassId == device && (foco.StyleId == "1" || isChildrenEqual(page, device, 1)))
                    {
                        if (!isSelect)
                        {
                            isSelect = true;
                            FocusImageButton(pageAccion, imageButton.ClassId, imageButton);
                        }

                        //Obtengo el porcentaje de encendido
                        string[] commands = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
                        if (commands[2] == "100")
                        {
                            pageWebSocketCan.FocoRGB(foco, info.BackgroundColor);
                            Toogled(foco);
                        }
                        else
                        {
                            pageWebSocketCan.FocoRGB(foco, Color.Black);
                            Toogled(foco);
                        }
                        await Task.Delay(Settings.delaySendWS);
                    }
                }
            }
            //Si no selecciono algun foco mandar un warning y deseleccionar
            if (!isSelect)
                await DisplayAlert("#Error Device RGB#", "Seleccione un dispositivo", "OK");
        }
        /********************************************************************************/
        public async Task<bool> apagon(ObservableCollection<Dispositivo> dispositivos)
        {
            foreach (Dispositivo dispositivo in dispositivos)
            {
                if(dispositivo.Porcentaje == 1 && dispositivo.Tiempo == 1)
                {
                    //Esto significa que es un dispositivo RGB
                    pageWebSocketCan.FocoRGBOff(dispositivo.Can, dispositivo.Pin);
                }
                else
                {
                    pageWebSocketCan.FocoCan(dispositivo.Can, dispositivo.Pin, dispositivo.Porcentaje, dispositivo.Tiempo);
                }
                await Task.Delay(Settings.delayApagon);
            }
            return true;
        }
        /********************************************************************************/
        public async void Persiana(Grid page,Grid pageAccion, string device, ImageButton imageButton)
        {
            bool isSelect = false;

            //Buscar todos los focos seleccionado
            for (int i = 0; i < page.Children.Count; i++)
            {
                if (page.Children[i].GetType().Name == "ImageButton")
                {
                    ImageButton foco = (ImageButton)page.Children[i];
                    //Si es de tipo foco y esta seleccionado
                    if (foco.ClassId == device && (foco.StyleId == "1" || isChildrenEqual(page, device, 1)))
                    {
                        if (!isSelect)
                        {
                            isSelect = true;
                            FocusImageButton(pageAccion, imageButton.ClassId, imageButton);
                        }
                        //Obtengo el porcentaje de encendido
                        string[] commands = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
                        //Validar condicion de la persiana
                        pageWebSocketCan.FocoOnOff(foco, Convert.ToInt32(commands[2]));
                        Toogled(foco);
                        /*
                         * Se cambio la propiedad de tiempo en Settings para probar el desempeño de
                         * activaciones multiples en persianas.
                         */
                        await Task.Delay(Settings.delayPersianaWS);
                    }
                }
            }
            //Si no selecciono algun foco mandar un warning y deseleccionar
            if (!isSelect)
                await DisplayAlert("#Error Device PERSIANA#", "Seleccione un dispositivo", "OK");
        }
        /********************************************************************************/

    }
}