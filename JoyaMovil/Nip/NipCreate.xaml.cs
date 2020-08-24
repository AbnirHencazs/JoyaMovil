using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Newtonsoft;
using Newtonsoft.Json;
//Clases
using JoyaMovil.Models;


namespace JoyaMovil.Nip
{
    public partial class NipCreate : ContentPage
    {
        //Variables
        public class NipJson
        {
            public string nip { get; set; }
            public string door { get; set; }
            public bool mark { get; set; }
        }
        public NipCreate()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Inicializar objetos
            nip.Text = "";
        }

        /*********************************************************************************/
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Mostrar cargando
            loading.IsRunning = true;

            //Met odo al aparecer
            Http http = new Http();
            http.post(Settings.urlNip, "getListDoor", (response) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    fondoNegro.IsVisible = false;
                    List<Puertas> puertas = new List<Puertas>();
                    puertas = JsonConvert.DeserializeObject<List<Puertas>>(response);
                    //Rellenar campos
                    string[] doorNames = new string[puertas.Count];
                    for (int i = 0; i < puertas.Count; i++)
                        doorNames[i] = puertas[i].nameDoor;
                    
                    listDoor.ItemsSource = doorNames;
                    loading.IsRunning = false;
                });
            });
        }

        public void GenerarNip(object sender, EventArgs ev)
        {
            Random rand = new Random();
            string aleatorio = rand.Next(1000, 9999).ToString("D4");
            nip.Text = aleatorio;
        }

        public void RegistrarNip(object sender, EventArgs ev)
        {
            int nipValue;
            //Validar campos
            if (nip.Text.Length != 4)
            {
                DisplayAlert("Error", "El nip debe contener 4 digitos", "OK");
                return;
            }
            else if (listDoor.SelectedItem == null)
            {
                DisplayAlert("Error", "Seleccione el Biometrico de Acceso", "OK");
                return;
            }
            else if (Int32.TryParse(nip.Text, out nipValue))
            {
                if (nipValue < 1000)
                {
                    DisplayAlert("Error", "El nip no puede iniciar con ceros", "OK");
                    return;
                }
            }

            //Bloquear campos
            btnRegistrar.IsEnabled = false;
            loading.IsRunning = true;

            //Construimos la cadena a postear
            NipJson nipJson = new NipJson();
            nipJson.nip = nip.Text;
            nipJson.door = listDoor.SelectedItem.ToString();
            //Algoritmo para evitar registro de NIP en biometricos especificos a usuarios sin la elevación maxima.
            if((nipJson.door == Settings.entradaOficinas ||
                nipJson.door == Settings.entradaOficinasRampa ||
                nipJson.door == Settings.privado) &&
               (login.sesionUsuario.NivelUsuario == TipoUsuario.Usuario))
            {
                DisplayAlert("Error", "Nivel de autorización no superado.\nSi cree que esto es un error contacte al administrador.", "OK");
                return;
            }
            nipJson.mark = false;
            string message = "NIPEVENT=" + JsonConvert.SerializeObject(nipJson);

            //Postear el dato
            Http http = new Http();
            http.post(Settings.urlNip, message, (response) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Success", response, "OK");
                    //Restablecer controles
                    btnRegistrar.IsEnabled = true;
                    loading.IsRunning = false;
                    nip.Text = "";
                    listDoor.SelectedIndex = -1;
                });
            }, (response) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error", response, "OK");
                    //Restablecer controles
                    btnRegistrar.IsEnabled = true;
                    loading.IsRunning = false;
                });
            });
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
    }
}
