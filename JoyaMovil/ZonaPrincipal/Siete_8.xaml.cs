using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Siete_8 : ContentPage
    {
        public Siete_8()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Navegacion
        PageNavigation navegacion = new PageNavigation();
        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {

            ImageButton img = (ImageButton)sender;
            //Navegar a la pagina
            if (await navegacion.Navegar(img))
            {
                img.Source = navegacion.lastImage;
                await Navigation.PushAsync(navegacion.page);
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
