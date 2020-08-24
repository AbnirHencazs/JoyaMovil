using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Seis_9_2 : ContentPage
    {
        public Seis_9_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Funcionabilidad
        PageLampara persiana = new PageLampara();

        void SeleccionPersiana(Object sender, EventArgs args)
        {
            persiana.Toogled((ImageButton)sender);
            persiana.FocusImageButton(pageAccion, "BotonAccionPersiana", null);
        }
        void AccionPersiana(Object sender, EventArgs args)
        {
            persiana.Persiana(page, pageAccion, "Persiana", (ImageButton)sender);
        }
        //Navegacion
        PageNavigation navegacion = new PageNavigation();
        async void BotonNavegacion(Object sender, EventArgs args)
        {
            ImageButton img = (ImageButton)sender;
            if (await navegacion.Navegar(img))
            {
                img.Source = navegacion.lastImage;
                await Navigation.PushAsync(navegacion.page);
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
