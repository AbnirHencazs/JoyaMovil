using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Ocho_1_3 : ContentPage
    {
        public Ocho_1_3()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara extractor = new PageLampara();

        void SeleccionExtractor(Object sender, EventArgs args)
        {
            extractor.Toogled((ImageButton)sender);
            extractor.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            extractor.Turn(CANdata, Accion, "Extractor", (ImageButton)sender);
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
