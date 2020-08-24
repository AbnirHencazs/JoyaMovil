using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cuatro_2_1 : ContentPage
    {
        public Cuatro_2_1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //Funcionabilidad
        PageLampara motor = new PageLampara();
        void AccionOnOff(Object sender, EventArgs args)
        {
            motor.Turn(CANdata, Accion, "Motor", (ImageButton)sender);
        }

        void Seleccion(Object sender, EventArgs args)
        {
            motor.Toogled((ImageButton)sender);
            motor.FocusImageButton(Accion, "BotonOnOff", null);
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
