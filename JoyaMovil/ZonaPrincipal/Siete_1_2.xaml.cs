using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_1_2 : ContentPage
    {
        public Siete_1_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Funcionabilidad
        PageLampara rgb = new PageLampara();

        void FocusRGB(Object sender, EventArgs args)
        {
            rgb.ToogledColor(colorRGB, (Button)sender);
            rgb.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void Seleccion(Object sender, EventArgs args)
        {
            rgb.Toogled((ImageButton)sender);
            rgb.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void RGB(Object sender, EventArgs args)
        {
            rgb.Rgb(CANdata, Accion, "RGB", (ImageButton)sender, colorRGB);
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
