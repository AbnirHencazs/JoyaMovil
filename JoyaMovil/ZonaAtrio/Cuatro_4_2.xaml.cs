using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cuatro_4_2 : ContentPage
    {
        public Cuatro_4_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara rgb = new PageLampara();
        void FocusRGB(object sender, EventArgs args)
        {
            rgb.ToogledColor(colorRGB, (Button)sender);
            rgb.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void Seleccion(Object sender, EventArgs args)
        {
            rgb.Toogled((ImageButton)sender);
            rgb.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOnOff(object sender, EventArgs args)
        {
            rgb.Rgb(CANdata, Accion, "RGB", (ImageButton)sender, colorRGB);
        }
        //Variables
        PageNavigation pageButtonNavegacion = new PageNavigation();
        //funciones
        async void BotonNavegacion(object sender, EventArgs args)
        {
            ImageButton img = (ImageButton)sender;
            //Navegar a la pagina
            if (await pageButtonNavegacion.Navegar(img))
            {
                img.Source = pageButtonNavegacion.lastImage;
                await Navigation.PushAsync(pageButtonNavegacion.page);
            }
        }

        void BotonBack(object sender, EventArgs args)
        {
            if (Navigation.NavigationStack.Count > 0)
                Navigation.PopAsync();
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
