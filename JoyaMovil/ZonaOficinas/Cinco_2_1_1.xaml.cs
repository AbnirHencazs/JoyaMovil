using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cinco_2_1_1 : ContentPage
    {
        public Cinco_2_1_1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageLampara dimmer = new PageLampara();

        void SeleccionDimeable(Object sender, EventArgs args)
        {
            dimmer.Toogled((ImageButton)sender);
            dimmer.FocusImageButton(pageAccion, "BotonOnOff", null);

        }
        void AccionOnOff(Object sender, EventArgs args)
        {
            dimmer.Turn(page, pageAccion, "Dimeable", (ImageButton)sender);
        }
        void AccionSlider(Object sender, EventArgs args)
        {
            dimmer.Dimmer(page,"Dimeable",(Slider)sender);
            dimmer.FocusImageButton(pageAccion, "BotonOnOff", null);
        }

        PageNavigation pageButtonNavegacion = new PageNavigation();


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
