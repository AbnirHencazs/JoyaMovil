using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JoyaMovil.Models;
using JoyaMovil.ViewModel;
using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class Detalle : ContentPage
    {
        public Detalle()
        {
            InitializeComponent();
        }

        private ObservableCollection<Dispositivo> dispositivos;
        public ObservableCollection<Dispositivo> Dispositivos
        {
            get
            {
                return dispositivos;
            }
            set
            {
                dispositivos = value;
                OnPropertyChanged();
            }
        }
        
        PageLampara apagarTodo = new PageLampara();
        private async void btnNavNIP_Clicked(System.Object sender, System.EventArgs e)
        {
            if(login.sesionUsuario == null)
            {
                await DisplayAlert("Error","Inicie sesión","Aceptar");
            }
            else if (login.sesionUsuario.NivelUsuario == TipoUsuario.loggedOut)
            {
                await DisplayAlert("Error", "Inicie sesión.", "OK");
            }
            else if (login.sesionUsuario.NivelUsuario != TipoUsuario.Superusuario)
            {
                await DisplayAlert("Error", "Permisos insuficientes. Contacte a su administrador", "OK");
            }

            if(login.sesionUsuario.NivelUsuario == TipoUsuario.Superusuario)
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new Nip.NipCreate());
            }
            
        }
        private  void btnApagarTodo_Clicked(Object sender, EventArgs e)
        {
            
            if(login.sesionUsuario == null)
            {
                DisplayAlert("Error", "Inicie sesión", "Aceptar");
            }
            else if(login.sesionUsuario.NivelUsuario == TipoUsuario.loggedOut)
            {
                DisplayAlert("Error", "Inicie Sesión", "Aceptar");
            }
            else
            {
                btnApagarTodo.IsEnabled = false;
                loading.IsRunning = true;
                EnviarApagon();
                
            }
        }
        private async void EnviarApagon()
        {
            Dispositivos = new ObservableCollection<Dispositivo>();
            //Zona Área Común - Entrada
            agregarDispositivo("03", "4", 0, 0);
            agregarDispositivo("30", "7", 0, 0);
            agregarDispositivo("80", "5", 0, 0);
            agregarDispositivo("07", "4", 0, 0);
            agregarDispositivo("80", "6", 0, 0);
            //Zona Área Común - Espejo agua
            agregarDispositivo("03", "3", 0, 0);
            agregarDispositivo("27", "3", 0, 0);
            agregarDispositivo("32", "2", 0, 0);
            agregarDispositivo("27", "2", 0, 0);
            agregarDispositivo("2A", "4", 0, 0);
            agregarDispositivo("79", "9", 0, 0);
            agregarDispositivo("37", "4", 0, 0);
            //zona Área Común - Vestibulo
            agregarDispositivo("28", "4", 0, 0);
            agregarDispositivo("09", "9", 0, 0);
            agregarDispositivo("03", "5", 0, 0);
            //zona Área Común - Soplador
            agregarDispositivo("22", "3", 0, 0);
            agregarDispositivo("09", "9", 0, 0);
            agregarDispositivo("1E", "2");
            //zona Área Común - Comedor
            agregarDispositivo("21", "4", 0, 0);
            agregarDispositivo("21", "2", 0, 0);
            agregarDispositivo("20", "3", 0, 0);
            agregarDispositivo("20", "2", 0, 0);
            agregarDispositivo("20", "7", 0, 0);
            //zona Área Común - Sala TV
            agregarDispositivo("0C", "2", 0, 0);
            agregarDispositivo("09", "8", 0, 0);
            //zona Área Común - Jardín
            agregarDispositivo("0D", "6", 0, 0);
            agregarDispositivo("0C", "9", 0, 0);
            agregarDispositivo("0C", "1", 0, 0);
            agregarDispositivo("1D", "6", 0, 0);
            agregarDispositivo("0B", "1");
            //zona Área Común - Cocina
            agregarDispositivo("14", "3", 0, 0);
            agregarDispositivo("13", "3", 0, 0);
            agregarDispositivo("0A", "2", 0, 0);
            agregarDispositivo("1D", "2", 0, 0);
            agregarDispositivo("1D", "3", 0, 0);
            agregarDispositivo("1D", "4", 0, 0);
            agregarDispositivo("1F", "2", 0, 0);
            agregarDispositivo("1D", "5", 0, 0);
            agregarDispositivo("1D", "1", 0, 0);
            //zona Área Común - Estancia
            agregarDispositivo("21", "1", 0, 0);
            agregarDispositivo("21", "5", 0, 0);
            agregarDispositivo("23", "5", 0, 0);
            agregarDispositivo("20", "5", 0, 0);
            agregarDispositivo("20", "6", 0, 0);
            agregarDispositivo("20", "1", 0, 0);
            //zona Área Común - Desayunador
            agregarDispositivo("19", "1", 0, 0);
            agregarDispositivo("71", "7", 0, 0);
            agregarDispositivo("15", "2", 0, 0);
            agregarDispositivo("62", "1");
            agregarDispositivo("1F", "8", 0, 0);
            //zona Área Común - Terraza Lounge
            agregarDispositivo("21", "6", 0, 0);
            agregarDispositivo("23", "1", 0, 0);
            agregarDispositivo("60", "1");
            //zona Área Común - Bar
            agregarDispositivo("38", "6", 0, 0);
            agregarDispositivo("38", "4", 0, 0);
            agregarDispositivo("38", "A", 0, 0);
            agregarDispositivo("38", "7", 0, 0);
            agregarDispositivo("38", "1", 0, 0);
            agregarDispositivo("39", "2", 0, 0);
            agregarDispositivo("38", "5", 0, 0);
            agregarDispositivo("39", "1", 0, 0);
            agregarDispositivo("3C", "1");
            agregarDispositivo("38", "2", 0, 0);
            agregarDispositivo("38", "8", 0, 0);
            //zona Área Común - Escaleras
            agregarDispositivo("22", "1", 0, 0);
            agregarDispositivo("23", "4", 0, 0);
            agregarDispositivo("22", "5", 0, 0);
            agregarDispositivo("23", "3", 0, 0);
            agregarDispositivo("23", "2", 0, 0);
            agregarDispositivo("23", "6", 0, 0);
            agregarDispositivo("23", "5", 0, 0);
            //zona Área Común - Tocador
            agregarDispositivo("28", "1", 0, 0);
            agregarDispositivo("26", "1", 0, 0);
            agregarDispositivo("27", "1", 0, 0);
            //zona Principal - Domo acuatico
            agregarDispositivo("19", "7", 0, 0);
            agregarDispositivo("61", "1");
            //zona Principal - habitación
            agregarDispositivo("71", "2", 0, 0);
            agregarDispositivo("13", "2", 0, 0);
            agregarDispositivo("16", "1");
            //zona Principal - Vestidor
            agregarDispositivo("71", "3", 0, 0);
            agregarDispositivo("1F", "7", 0, 0);
            agregarDispositivo("1F", "6", 0, 0);
            agregarDispositivo("1D", "9", 0, 0);
            agregarDispositivo("1D", "8", 0, 0);
            agregarDispositivo("1D", "A", 0, 0);
            agregarDispositivo("1F", "1", 0, 0);
            //zona Principal - Privado
            agregarDispositivo("71", "5", 0, 0);
            agregarDispositivo("15", "3", 0, 0);
            //zona Principal - Gimnasio
            agregarDispositivo("71", "9", 0, 0);
            agregarDispositivo("71", "A", 0, 0);
            //zona Principal - Carril de nado
            agregarDispositivo("71", "6", 0, 0);
            agregarDispositivo("1F", "9", 0, 0);
            agregarDispositivo("78", "3", 0, 0);
            //zona Principal - Vapor
            agregarDispositivo("13", "8", 0, 0);
            //zona Principal - Baño
            agregarDispositivo("19", "4", 0, 0);
            agregarDispositivo("19", "6", 0, 0);
            agregarDispositivo("71", "1", 0, 0);
            agregarDispositivo("71", "8", 0, 0);
            agregarDispositivo("13", "5", 0, 0);
            agregarDispositivo("12", "1");
            agregarDispositivo("70", "8", 0, 0);
            //zona Principal - Jacuzzi
            agregarDispositivo("19", "3", 0, 0);
            agregarDispositivo("71", "4", 0, 0);
            agregarDispositivo("14", "2", 0, 0);
            agregarDispositivo("15", "1", 0, 0);
            agregarDispositivo("13", "6", 0, 0);
            //zona Principal - Jardin contemplativo
            agregarDispositivo("07", "6", 0, 0);
            agregarDispositivo("61", "1");
            agregarDispositivo("79", "1", 0, 0);
            //zona Habitaciones - Jardin interior
            agregarDispositivo("0D", "6", 0, 0);
            agregarDispositivo("0C", "9", 0, 0);
            agregarDispositivo("0C", "1", 0, 0);
            agregarDispositivo("0B", "1");
            agregarDispositivo("1D", "6", 0, 0);
            //zona Habitaciones - Alharaca
            agregarDispositivo("0C", "7", 0, 0);
            agregarDispositivo("0D", "5", 0, 0);
            agregarDispositivo("09", "1", 0, 0);
            agregarDispositivo("09", "2", 0, 0);
            agregarDispositivo("70", "6", 0, 0);
            //zona Habitaciones - Nefelibata
            agregarDispositivo("0C", "8", 0, 0);
            agregarDispositivo("09", "3", 0, 0);
            agregarDispositivo("0C", "A", 0, 0);
            agregarDispositivo("0D", "2", 0, 0);
            agregarDispositivo("09", "4", 0, 0);
            agregarDispositivo("0A", "A", 0, 0);
            //zona Habitaciones - Quimerica
            agregarDispositivo("0C", "4", 0, 0);
            agregarDispositivo("0D", "4", 0, 0);
            //zona Habitaciones - Nefelibata
            agregarDispositivo("0C", "6", 0, 0);
            agregarDispositivo("09", "6", 0, 0);
            //zona Habitaciones - Vesanica
            agregarDispositivo("0D", "1", 0, 0);
            agregarDispositivo("0C", "3", 0, 0);
            agregarDispositivo("0A", "8", 0, 0);
            agregarDispositivo("09", "5", 0, 0);
            //zona Habitaciones - Andador
            agregarDispositivo("0D", "4", 0, 0);
            agregarDispositivo("09", "2", 0, 0);
            agregarDispositivo("09", "3", 0, 0);
            //zona Habitaciones - Tocador
            agregarDispositivo("09", "7", 0, 0);
            agregarDispositivo("0D", "3", 0, 0);
            agregarDispositivo("0D", "8", 0, 0);
            agregarDispositivo("0A", "7", 0, 0);
            //zona Habitaciones - Pergola
            agregarDispositivo("0C", "5", 0, 0);
            agregarDispositivo("0D", "7", 0, 0);
            agregarDispositivo("70", "1", 0, 0);
            agregarDispositivo("70", "5", 0, 0);
            //zona - Oficinas
            agregarDispositivo("34", "4", 0, 0);
            agregarDispositivo("32", "3", 0, 0);
            agregarDispositivo("72", "1");
            agregarDispositivo("37", "3", 0, 0);
            agregarDispositivo("37", "1", 0, 0);
            agregarDispositivo("37", "2", 0, 0);
            agregarDispositivo("63", "1");
            agregarDispositivo("63", "2");
            agregarDispositivo("34", "7", 0, 0);
            agregarDispositivo("37", "4", 0, 0);
            agregarDispositivo("33", "3", 0, 0);
            agregarDispositivo("34", "6", 0, 0);
            agregarDispositivo("33", "1", 0, 0);
            //zona Oficinas - Oficina
            agregarDispositivo("34", "1", 0, 0);
            agregarDispositivo("33", "2", 0, 0);
            //zona Oficinas - Vestibulo
            agregarDispositivo("34", "2", 0, 0);
            //zona Oficinas - Vestibulo
            agregarDispositivo("34", "5", 0, 0);
            agregarDispositivo("32", "1", 0, 0);
            //zona Oficinas - Escalera
            agregarDispositivo("32", "2", 0, 0);
            agregarDispositivo("32", "4", 0, 0);
            agregarDispositivo("32", "5", 0, 0);
            //zona Atrio - Estacionamiento
            agregarDispositivo("03", "7", 0, 0);
            agregarDispositivo("0A", "1", 0, 0);
            agregarDispositivo("02", "3", 0, 0);
            agregarDispositivo("08", "2", 0, 0);
            agregarDispositivo("07", "3", 0, 0);
            agregarDispositivo("07", "A", 0, 0);
            agregarDispositivo("07", "9", 0, 0);
            //zona Atrio - Fuente
            agregarDispositivo("07", "5", 0, 0);
            agregarDispositivo("F1", "1");
            agregarDispositivo("03", "6", 0, 0);
            agregarDispositivo("80", "4", 0, 0);
            //zona Atrio - Frutales
            agregarDispositivo("07", "1", 0, 0);
            //zona Atrio - Tropicales
            agregarDispositivo("2A", "3", 0, 0);
            agregarDispositivo("18", "1");
            //zona Villas - Escaleras
            agregarDispositivo("2C", "2", 0, 0);
            agregarDispositivo("2E", "8", 0, 0);
            //zona Villas - Jardines
            agregarDispositivo("2D", "1");
            agregarDispositivo("30", "4", 0, 0);
            agregarDispositivo("2D", "1");
            agregarDispositivo("30", "5", 0, 0);
            agregarDispositivo("2D", "2");
            agregarDispositivo("30", "6", 0, 0);
            //zona Villas - Estancia
            agregarDispositivo("2E", "7", 0, 0);
            agregarDispositivo("2E", "2", 0, 0);
            //zona Villas - Habitaciones
            agregarDispositivo("2E", "5", 0, 0);
            //zona Villas - Tocador
            agregarDispositivo("2E", "6", 0, 0);
            agregarDispositivo("2E", "1", 0, 0);
            agregarDispositivo("2E", "3", 0, 0);
            agregarDispositivo("2C", "1", 0, 0);
            bool apagado = await apagarTodo.apagon(Dispositivos);
            if (apagado)
            {
                loading.IsRunning = false;
                btnApagarTodo.IsEnabled = true;
                await DisplayAlert("Apagar todo", "Completado", "Aceptar");
            }
        }
        private void agregarDispositivo(string can, string pin, int porcentaje = 1, int tiempo = 1)
        {
            Dispositivos.Add(new Dispositivo() { Can = can, Pin = pin, Porcentaje = porcentaje, Tiempo = tiempo });
        }
        private async void btnLogout_Clicked(System.Object sender, System.EventArgs e)
        {
            login.sesionUsuario.NivelUsuario = Models.TipoUsuario.loggedOut;
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new login());
        }
    }
}
