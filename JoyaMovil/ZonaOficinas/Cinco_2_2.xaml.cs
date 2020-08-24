using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cinco_2_2 : ContentPage
    {
        public Cinco_2_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //funcionabilidad
        PageLampara pageLampara = new PageLampara();
     

        void PlataformaOn(Object sender, EventArgs args)
        {
            pageLampara.FocusImageButton(pageAccion, "BotonOnOff", (ImageButton)sender);
            if(Motor.StyleId == "0")
            {
                pageLampara.FocoCan("37", "1", 100, 0);
            }
            else
            {
                pageLampara.FocoCan("37", "2", 100, 0);
            }
        }
        void PlataformaOff(Object sender, EventArgs args)
        {
            pageLampara.FocusImageButton(pageAccion, "BotonOnOff", (ImageButton)sender);
            pageLampara.FocoCan("37", "1", 0, 0);
            pageLampara.FocoCan("37", "2", 0, 0);
        }

        void SeleccionMotor(Object sender, EventArgs args)
        {
            pageLampara.Toogled((ImageButton)sender);
            pageLampara.FocusImageButton(pageAccion, "BotonOnOff", null);
        }
        //Navegacion
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
