﻿using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cinco_1 : ContentPage
    {
        public Cinco_1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //Funcionabilidad
        PageLampara dimmer = new PageLampara();
        void AccionOnOff(Object sender, EventArgs args)
        {
            dimmer.Turn(CANdata, Accion, "Dimeable", (ImageButton)sender);
        }
        void Seleccion(object sender, EventArgs args)
        {
            dimmer.Toogled((ImageButton)sender);
            dimmer.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void AccionSlider(Object sender, EventArgs args)
        {
            dimmer.Dimmer(CANdata, "Dimeable", (Slider)sender);
            dimmer.FocusImageButton(Accion, "BotonOnOff", null);
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
