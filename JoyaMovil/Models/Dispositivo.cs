using System;
namespace JoyaMovil.Models
{
    public class Dispositivo:NotificationObject
    {
        private string can;
        public string Can
        {
            get
            {
                return can;
            }
            set
            {
                can = value;
                OnPropertyChanged();
            }
        }
        private string pin;
        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
                OnPropertyChanged();
            }
        }
        private int porcentaje;
        public int Porcentaje
        {
            get
            {
                return porcentaje;
            }
            set
            {
                porcentaje = value;
                OnPropertyChanged();
            }
        }
        private int tiempo;
        public int Tiempo
        {
            get
            {
                return tiempo;
            }
            set
            {
                tiempo = value;
                OnPropertyChanged();
            }
        }
    }
}
