using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Seis_10_2 : ContentPage
    {
        public Seis_10_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara persiana = new PageLampara();
        void SeleccionPersiana(object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(Accion, "BotonPersiana", null);
            persiana.FocusImageButton(accionToldo, "BotonToldo", null);
        }
        void AccionPersiana(object sender, EventArgs args)
        {
            persiana.Persiana(CANdataBlackOut, Accion, "Persiana", (ImageButton)sender);
            persiana.Persiana(CANdataMosquitero, Accion, "Mosquitero", (ImageButton)sender);
        }
        void AccionToldo(object sender, EventArgs args)
        {
            persiana.Persiana(CANtoldo, accionToldo, "Toldo", (ImageButton)sender);
        }
        void Seleccion(Object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(Accion, "BotonToldo", null);
        }
        void BotonBack(Object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 0)
            {
                Navigation.PopAsync();
            }
        }
        void BotonHome(Object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        void MenuLateral(object sender, EventArgs eventArgs)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }
    }
}
