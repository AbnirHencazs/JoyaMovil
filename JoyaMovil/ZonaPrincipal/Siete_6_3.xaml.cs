using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_6_3 : ContentPage
    {
        public Siete_6_3()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
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
