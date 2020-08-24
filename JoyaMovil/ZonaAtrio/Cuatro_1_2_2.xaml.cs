using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cuatro_1_2_2 : ContentPage
    {
        public Cuatro_1_2_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Funcionabilidad

        PageLampara RGB = new PageLampara();
        void FocusRGB(Object sender, EventArgs args)
        {
            RGB.ToogledColor(colorRGB, (Button)sender);
            RGB.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void SeleccionRGB(Object sender, EventArgs args)
        {
            RGB.Toogled((ImageButton)sender);
            RGB.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            RGB.Rgb(CANdata, Accion, "RGB", (ImageButton)sender, colorRGB);
        }
        //Variables
        PageNavigation pageButtonNavegacion = new PageNavigation();
        //Funciones
        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {
            ImageButton img = (ImageButton)sender;
            //Navegar a la pagina
            if (await pageButtonNavegacion.Navegar(img))
            {
                img.Source = pageButtonNavegacion.lastImage;
                await Navigation.PushAsync(pageButtonNavegacion.page);
            }
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
