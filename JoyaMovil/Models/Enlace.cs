using System;
using System.Collections.Generic;
using System.Text;

namespace JoyaMovil.Models
{
    class Enlace
    {
        //Variables constantes
        static string canEnlace = "FF";
        static string canEscenario = "01";
        string comando;
        public string cadenaAccesoCochera(string can ,string pin, int porcentaje, int tiempo)
        {
            //01+1+can+pin+porcentaje+tiempo(7)
            comando = canEscenario + "1";
            comando += can + pin + porcentaje.ToString("D3") + tiempo.ToString("D2");
            comando += "xxx";
            return comando;
        }
        public string Lampara(string can, string pin, int percent, int time)
        {
            //FF+1+09+6+100+03+xxx
            comando = canEnlace + "1";
            comando += can + pin + percent.ToString("D3") + time.ToString("D2");
            comando += "xxx";

            return comando;
        }

        public string LamparaRGB(string can, string pin, string color)
        {
            //FF+1+68+7+xxx+xx+F1E
            comando = canEnlace + "1";
            comando += can + pin + "xxx" + "xx";
            comando += color;

            return comando;
        }
    }
}