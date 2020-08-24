using System;
namespace JoyaMovil.Models
{
    public class Settings
    {
        //Local
        static public string dominioLocal = "http://192.168.1.99/";
        //static public string dominioLocal = "";
        public static string dominioNube = "http://c68d9ab.online-server.cloud/";

        static public string urlMovil = dominioLocal + "Joya/pagesMovilApp/database_movil.php";
        static public string urlSensores = dominioNube + "Joya/pagesMovilApp/Sensores.php";
        static public string urlNip = dominioNube + "Joya/pagesNip/gestorNip.php";
        static public string urlLogin = dominioNube + "Joya/login/gestorLogin.php";
        static public string urlWebSocket = "ws://192.168.1.80:8085";
        //static public string urlWebSocket = "";
        //Tiempo entre envio de websocket
        static public int delaySendWS = 10;
        //Tiempo para envio de instrucciones persianas
        static public int delayPersianaWS = 1000;
        //Tiempo para la navegacion
        static public int delayPage = 300;
        //Tiempo entre instrucciones pde apagon
        static public int delayApagon = 300;
        //Login
        static public string contraseñaSuperUsuario = "Love";
        static public string usernameSuperUsuario = "Admon";
        static public string contraseñaUsuario = "Honey";
        static public string usernameUsuario = "Reside";
        static public string contraseñaInvitado = "Happy";
        static public string usernameInvitado = "Invitado";
        //Biometricos
        static public string entradaOficinas = "Entrada oficinas";
        static public string entradaOficinasRampa = "Entrada oficinas rampa";
        static public string privado = "Privado";
    }
}
