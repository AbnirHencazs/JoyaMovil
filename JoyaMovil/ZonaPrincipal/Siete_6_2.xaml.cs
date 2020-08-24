using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_6_2 : ContentPage
    {
        public Siete_6_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        PageLampara persiana = new PageLampara();
        void AccionToldo(Object sender, EventArgs args)
        {
            persiana.Persiana(CANtoldo, accionToldo, "Toldo", (ImageButton)sender);
        }
        void AccionCubierta(Object sender, EventArgs args)
        {
            persiana.Persiana(CANcubierta, accionCubierta, "Cubierta", (ImageButton)sender);
        }
        
        void SeleccionToldo(Object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(accionToldo, "BotonToldo", null);
        }
        void SeleccionCubierta(Object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(accionCubierta, "BotonCubierta", null);
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
