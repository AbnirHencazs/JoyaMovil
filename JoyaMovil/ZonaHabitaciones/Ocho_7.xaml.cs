using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Ocho_7 : ContentPage
    {
        public Ocho_7()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara dimmer = new PageLampara();
        void SeleccionDimeable(Object sender, EventArgs args)
        {
            dimmer.Toogled((ImageButton)sender);
            dimmer.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            dimmer.Turn(CANdata, Accion, "Dimeable", (ImageButton)sender);
        }
        void AccionSlider(Object sender, EventArgs args)
        {
            dimmer.Dimmer(CANdata, "Dimeable", (Slider)sender);
            dimmer.FocusImageButton(Accion, "BotonOnOff", null);
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
