using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cinco_2 : ContentPage
    {
        public Cinco_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        PageNavigation pageButtonNavegacion = new PageNavigation();

        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {

            ImageButton img = (ImageButton)sender;
            if(sender == navPlataforma && login.sesionUsuario.NivelUsuario == Models.TipoUsuario.Usuario)
            {
                await DisplayAlert("Error", "Nivel de autorización no superado.\nSi cree que esto es un error contacte al administrador.", "OK");
            }
            else
            {
                //Navegar a la pagina
                if (await pageButtonNavegacion.Navegar(img))
                {
                    img.Source = pageButtonNavegacion.lastImage;
                    await Navigation.PushAsync(pageButtonNavegacion.page);
                }
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
