using System;
namespace JoyaMovil.Models
{
    public class Sensor:NotificationObject
    {
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string estado;
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }

        private string recursoGrafico;
        public string RecursoGrafico
        {
            get
            {
                return recursoGrafico;
            }
            set
            {
                recursoGrafico = value;
                OnPropertyChanged();
            }
        }
    }
}
