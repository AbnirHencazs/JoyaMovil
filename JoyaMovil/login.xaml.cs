using System;
using System.Collections.Generic;
using System.Threading;
using JoyaMovil.Models;
using JoyaMovil.ViewModel;
using Newtonsoft;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace JoyaMovil
{

    public partial class login : ContentPage
    {
        /*public class loginJson
        {
            public string usr { get; set; }
            public string pwd { get; set; }
        }*/
        public login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        
        public static Usuario sesionUsuario;
        PageNavigation pageButtonNavegacion = new PageNavigation();

        async void BotonNavegacion(object sender, EventArgs eventArgs)
        {
            var usuario = loginUser.Text;
            var password = loginPassword.Text;
            /*loginJson datosLogin = new loginJson();
            datosLogin.usr = loginUser.Text;
            datosLogin.pwd = loginPassword.Text;
            string mensaje = "doLogin=" + JsonConvert.SerializeObject(datosLogin);
            Http http = new Http();
            
            http.post(Settings.urlLogin, mensaje, (response) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Success", response, "OK");
                    //Restablecer controles 
                });
            }, (response) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error", response, "OK");
                    
                });
            });*/
            ImageButton img = (ImageButton)sender;
            //Navegar a la pagina
            if (usuario == Settings.usernameSuperUsuario && password == Settings.contraseñaSuperUsuario)
            {
                sesionUsuario = new Usuario("Super Usuario", Settings.contraseñaSuperUsuario, TipoUsuario.Superusuario);

                Navigation.InsertPageBefore(new Dos_0(), this);
                if (await pageButtonNavegacion.Navegar(img))
                {
                    img.Source = pageButtonNavegacion.lastImage;
                    await Navigation.PushAsync(pageButtonNavegacion.page);
                }
            }
            else if (usuario == Settings.usernameUsuario && password == Settings.contraseñaUsuario)
            {
                sesionUsuario = new Usuario("Residente", Settings.contraseñaUsuario, TipoUsuario.Usuario);
                Navigation.InsertPageBefore(new Dos_0(), this);
                if (await pageButtonNavegacion.Navegar(img))
                    if (await pageButtonNavegacion.Navegar(img))
                    {
                        img.Source = pageButtonNavegacion.lastImage;
                        await Navigation.PushAsync(pageButtonNavegacion.page);
                    }
            }
            else if (usuario == Settings.usernameInvitado && password == Settings.contraseñaInvitado) 
            {
                sesionUsuario = new Usuario("Invitado", Settings.contraseñaInvitado, TipoUsuario.Invitado);
                Navigation.InsertPageBefore(new Dos_0(), this);
                if (await pageButtonNavegacion.Navegar(img))
                    if (await pageButtonNavegacion.Navegar(img))
                {
                    img.Source = pageButtonNavegacion.lastImage;
                    await Navigation.PushAsync(pageButtonNavegacion.page);
                }
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrecto", "OK");
            }
        }
    }

}