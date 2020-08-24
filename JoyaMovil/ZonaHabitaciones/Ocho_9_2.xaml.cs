using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Ocho_9_2 : ContentPage
    {
        public Ocho_9_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara luminaria = new PageLampara();
        void SeleccionLuminaria(Object sender, EventArgs args)
        {
            luminaria.Toogled((ImageButton)sender);
            luminaria.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            luminaria.Turn(CANdata, Accion, "Luminaria", (ImageButton)sender);
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
