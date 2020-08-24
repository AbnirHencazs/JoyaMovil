using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Seis_11 : ContentPage
    {
        public Seis_11()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Navegacion
        PageNavigation navegacion = new PageNavigation();
        async void BotonNavegacion(Object sender, EventArgs args)
        {
            ImageButton img = (ImageButton)sender;
            if(sender == navFogata && login.sesionUsuario.NivelUsuario == Models.TipoUsuario.Invitado)
            {
                await DisplayAlert("Error", "Nivel de autorización no superado.\nSi cree que esto es un error contacte al administrador.", "OK");
                
            }
            else if(sender == navFogata && login.sesionUsuario.NivelUsuario == Models.TipoUsuario.Usuario)
            {
                await DisplayAlert("Error", "Nivel de autorización no superado.\nSi cree que esto es un error contacte al administrador.", "OK");
            }
            else
            {
                if (await navegacion.Navegar(img))
                {
                    img.Source = navegacion.lastImage;
                    await Navigation.PushAsync(navegacion.page);
                }
            }
            
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
