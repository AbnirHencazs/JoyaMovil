using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Ocho_5_1 : ContentPage
    {
        public Ocho_5_1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara persiana = new PageLampara();
        void SeleccionPersiana(object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(Accion, "BotonPersiana", null);
        }
        void AccionPersiana(object sender, EventArgs args)
        {
            persiana.Persiana(CANdataSombra, Accion, "Sombra", (ImageButton)sender);
            persiana.Persiana(CANdataBlackOut, Accion, "BlackOut", (ImageButton)sender);
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
