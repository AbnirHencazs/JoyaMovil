using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_6_4 : ContentPage
    {
        public Siete_6_4()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara ventana = new PageLampara();
        void AccionPersiana(Object sender, EventArgs args)
        {
            ventana.Persiana(CANdata, Accion, "Ventana", (ImageButton)sender);
        }
        void Seleccion(Object sender, EventArgs args)
        {
            ventana.Toogled((ImageButton)sender);
            ventana.FocusImageButton(Accion, "BotonPersiana", null);
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
