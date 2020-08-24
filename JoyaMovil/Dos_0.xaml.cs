using System;
using System.Collections.Generic;
using System.Threading;
using JoyaMovil.Models;
using JoyaMovil.ViewModel;

using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Dos_0 : ContentPage
    {
        public Dos_0()
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
            SelecResidencia.IsVisible = false;
            SelecPaisaje.IsVisible = false;
            BanerPaisaje.IsVisible = false;
            BanerResidencia.IsVisible = false;
        }

        PageNavigation pageButtonNavegacion = new PageNavigation();

        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {
            SelecPaisaje.IsVisible = true;
            BanerPaisaje.IsVisible = true;
            ImageButton img = (ImageButton)sender;
           
            //Navegar a la pagina
            if (await pageButtonNavegacion.Navegar(img))
            {
                img.Source = pageButtonNavegacion.lastImage;
                SelecPaisaje.IsVisible = false;
                BanerPaisaje.IsVisible = false;
                await Navigation.PushAsync(pageButtonNavegacion.page);
            }
            
        }

        async void BotonNavegacionRes(object sender, EventArgs eventArgs)
        {
           
            //Navegar a la pagina
            if(login.sesionUsuario.NivelUsuario != TipoUsuario.Invitado)
            {
                SelecResidencia.IsVisible = true;
                BanerResidencia.IsVisible = true;
                ImageButton img = (ImageButton)sender;
                if (await pageButtonNavegacion.Navegar(img))
                {
                    img.Source = pageButtonNavegacion.lastImage;
                    SelecResidencia.IsVisible = false;
                    BanerResidencia.IsVisible = false;
                    await Navigation.PushAsync(pageButtonNavegacion.page);
                }
            }
            else
            {
                SelecResidencia.IsVisible = true;
                BanerResidencia.IsVisible = true;
                ImageButton img = (ImageButton)sender;
                if (await pageButtonNavegacion.Navegar(img))
                {
                    img.Source = pageButtonNavegacion.lastImage;
                    SelecResidencia.IsVisible = false;
                    BanerResidencia.IsVisible = false;
                    pageButtonNavegacion.page = new Seis_11();
                    await Navigation.PushAsync(pageButtonNavegacion.page);
                }
                //await DisplayAlert("Error", "Nivel de autorización no superado.\nSi cree que esto es un error contacte al administrador.", "OK");
            }
        }

        void MenuLateral(object sender, EventArgs eventArgs)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }
    }

}
