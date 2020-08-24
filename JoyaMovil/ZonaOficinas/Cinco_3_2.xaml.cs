using System;
using System.Collections.Generic;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Cinco_3_2 : ContentPage
    {
        public Cinco_3_2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        //funcionabilidad
        PageLampara motor = new PageLampara();
        void AccionOnOff(Object sender, EventArgs args)
        {
            motor.Turn(CANdata, Accion, "Motor", (ImageButton)sender);
        }
        void AccionOficina(Object sender, EventArgs args)
        {
            motor.Turn(CANoficina, AccionMOficina, "MotorOficina", (ImageButton)sender);
        }
        void SeleccionMotor(Object sender, EventArgs args)
        {
            motor.Toogled((ImageButton)sender);
            motor.FocusImageButton(Accion, "BotonOnOff", null);
        }
        void SeleccionMotorOficina(Object sender, EventArgs args)
        {
            motor.Toogled((ImageButton)sender);
            motor.FocusImageButton(AccionMOficina, "BotonMotorOficina", null);
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
