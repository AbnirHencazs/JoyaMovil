using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Ocho_3_2 : ContentPage
    {
        public Ocho_3_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara persiana = new PageLampara();

        void SeleccionPersiana(Object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(Accion, "BotonAccionPersiana", null);
        }
        void AccionPersiana(Object sender, EventArgs args)
        {
            persiana.Persiana(CANdata, Accion, "Persiana", (ImageButton)sender);
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
