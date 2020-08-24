using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JoyaMovil.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace JoyaMovil
{
    public class SensoresViewModel:NotificationObject
    {
        private ObservableCollection<Sensor> sensores;
        public ObservableCollection<Sensor> Sensores
        {
            get { return sensores; }
            set
            {
                sensores = value;
                OnPropertyChanged();
            }
        }

        public Command CargarSensoresCommand { get; set; }

        public SensoresViewModel()
        {
            CargaSensores();
            CargarSensoresCommand = new Command(CargaSensores);
        }

        private bool cargando;
        public bool Cargando
        {
            get
            {
                return cargando;
            }
            set
            {
                cargando = value;
                OnPropertyChanged();
            }
        }

        private void CargaSensores()
        {
            Sensores = new ObservableCollection<Sensor>();

            Http http = new Http();
            http.post(Settings.urlSensores, "", (response) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    List<Sensor> sensores = new List<Sensor>();
                    
                    sensores = JsonConvert.DeserializeObject<List<Sensor>>(response);
                    foreach(Sensor sensor in sensores)
                    {
                        if(sensor.Estado == "cerrado")
                        {
                            Sensores.Add(new Sensor() { Id = sensor.Id, Nombre = sensor.Nombre, Estado = sensor.Estado, RecursoGrafico = sensor.RecursoGrafico + "_on.png"});
                        }
                        else
                        {
                            Sensores.Add(new Sensor() { Id = sensor.Id, Nombre = sensor.Nombre, Estado = sensor.Estado, RecursoGrafico = sensor.RecursoGrafico + "_off.png" });
                        }
                    }
                    Cargando = false;
                });
            });
        }
    }
}
