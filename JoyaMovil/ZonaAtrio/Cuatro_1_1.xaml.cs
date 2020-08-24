using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cuatro_1_1 : ContentPage
    {
        public Cuatro_1_1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Funcionabilidad
        PageLampara acceso = new PageLampara();
        void SeleccionAcceso(Object sender, EventArgs args)
        {
            acceso.Toogled((ImageButton)sender);
            acceso.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOn(Object sender, EventArgs eventArgs)
        {
            acceso.FocusImageButton(Accion, "BotonOnOff", (ImageButton)sender);
            //acceso.Turn(CANdata, n, "Acceso",(ImageButton)sender);
            for (int i = 0; i < CANdata.Children.Count; i++)
            {
                Console.Write(i);
                ImageButton accesoEstacionamiento = (ImageButton)CANdata.Children[i];
                if (accesoEstacionamiento.ClassId == "Acceso" && (accesoEstacionamiento.StyleId == "1" || acceso.isChildrenEqual(CANdata, "Acceso", 1)))
                {
                    string[] commands = accesoEstacionamiento.CommandParameter.ToString().Split(new char[] { ',' });
                    acceso.AccesoCochera(commands[0], commands[1], 100, 7);
                }

            }

        }
        void AccionOff(Object sender, EventArgs eventArgs)
        {
            acceso.FocusImageButton(Accion, "BotonOnOff", (ImageButton)sender);
            for (int i = 0; i < CANdata.Children.Count; i++)
            {
                ImageButton accesoEstacionamiento = (ImageButton)CANdata.Children[i];
                if (accesoEstacionamiento.ClassId == "Acceso" && (accesoEstacionamiento.StyleId == "1" || acceso.isChildrenEqual(CANdata, "Acceso", 1)))
                {
                    string[] commands = accesoEstacionamiento.CommandParameter.ToString().Split(new char[] { ',' });
                    if (commands[1] == "A")
                    {
                        var pin9 = "9";
                        acceso.AccesoCochera(commands[0], pin9, 100, 7);
                        return;
                    }
                    var pin = Convert.ToInt16(commands[1]) - 1;
                    acceso.AccesoCochera(commands[0], pin.ToString(), 100, 7);
                }

            }
        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            
            acceso.Turn(CANdata, Accion, "Acceso", (ImageButton)sender);
        }
        //Variables
        PageNavigation pageButtonNavegacion = new PageNavigation();
        //Funciones
        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {
            ImageButton img = (ImageButton)sender;
            //Navegar a la pagina
            if (await pageButtonNavegacion.Navegar(img))
            {
                img.Source = pageButtonNavegacion.lastImage;
                await Navigation.PushAsync(pageButtonNavegacion.page);
            }
        }

        void BotonBack(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 0)
                Navigation.PopAsync();
        }

        void BotonHome(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        void MenuLateral(object sender, EventArgs eventArgs)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }
    }
}
