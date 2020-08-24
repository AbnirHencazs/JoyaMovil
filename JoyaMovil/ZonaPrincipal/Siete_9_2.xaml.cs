using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_9_2 : ContentPage
    {
        public Siete_9_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara ventanas = new PageLampara();
        void AccionOnOff(Object sender, EventArgs args)
        {
            ventanas.Persiana(CANdata, Accion, "Ventanas", (ImageButton)sender);
        }
        void Seleccion(Object sender, EventArgs args)
        {
            ventanas.Toogled((ImageButton)sender);
            ventanas.FocusImageButton(Accion, "BotonPersiana", null);
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
