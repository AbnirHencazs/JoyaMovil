using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_10_1_3 : ContentPage
    {
        public Siete_10_1_3()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara luminaria = new PageLampara();
        void AccionOnOff(Object sender, EventArgs args)
        {
            luminaria.Turn(CANdata, Accion, "Luminaria", (ImageButton)sender);
        }
        void BotonBack(object sender, EventArgs args)
        {
            if (Navigation.NavigationStack.Count > 0)
                Navigation.PopAsync();
        }
        void Seleccion(Object sender, EventArgs args)
        {
            luminaria.Toogled((ImageButton)sender);
            luminaria.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void BotonHome(object sender, EventArgs args)
        {
            Navigation.PopToRootAsync();
        }
        void MenuLateral(object sender, EventArgs eventArgs)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }
    }
}
