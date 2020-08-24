using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Tres_2_1_2 : ContentPage
    {
        public Tres_2_1_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void FocoOnOff(Object sender, EventArgs args)
        {
            pageLampara.Turn(page, pageAccion, "Reflector", (ImageButton)sender);
        }
        //Funcionabilidad
        PageLampara pageLampara = new PageLampara();
        void Seleccion(Object sender, EventArgs args)
        {
            pageLampara.Toogled((ImageButton)sender);
            pageLampara.FocusImageButton(pageAccion, "BotonOnOff", null);
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
