using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class InicioSesion : ContentPage
    {
        public InicioSesion()
        {
            InitializeComponent();
            BotonEntrar_.IsVisible = false;
            txtUsuario.Focus();
        }

        void CambiaImagenBotonEntrar(object sender, EventArgs args)
        {
            if (BotonEntrar.IsVisible == true)
            {
                BotonEntrar.IsVisible = false;
                BotonEntrar_.IsVisible = true;
            }
            else
            {
                BotonEntrar.IsVisible = true;
                BotonEntrar_.IsVisible = false;
            }
        }
    }
}
