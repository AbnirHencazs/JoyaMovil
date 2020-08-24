using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using JoyaMovil.Models;


namespace JoyaMovil.ViewModel
{
    public class PageNavigation : ContentPage
    {
        public Page page;
        public string lastImage = "";

        public PageNavigation()
        {
           
        }

        public async Task<bool> Navegar(ImageButton imageButton)
        {
            //string imageOrignal = imageButton.Source.ToString();
            string[] items = imageButton.CommandParameter.ToString().Split(new char[] { ',' });
            //validar contenido
            if (items.Length < 3)
            {
                await DisplayAlert("Navegacion", "Se requiere imagen y pagina de navegacion", "OK");
                return false;
            }
            //Navegamos
            lastImage = items[0];
            page = NavegarPagina(items[2]);
            //Si pagina existe navegaremos
            if (page != null)
            {
                imageButton.Source = items[1];
                await Task.Delay(Settings.delayPage);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*************************************************************************/
        Page NavegarPagina(string pageName)
        {
           
            switch (pageName)
            {
                case "Dos_0":
                    return new Dos_0();
                case "Dos_1":
                    return new Dos_1();
                case "Dos_2":
                    return new Dos_2();
                case "Tres_0":
                    return new Tres_0();
                case "Tres_1":
                    return new Tres_1();
                case "Tres_1_1":
                    return new Tres_1_1();
                case "Tres_2":
                    return new Tres_2();
                case "Tres_2_1":
                    return new Tres_2_1();
                case "Tres_2_1_1":
                    return new Tres_2_1_1();
                case "Tres_2_1_2":
                    return new Tres_2_1_2();
                case "Tres_2_2":
                    return new Tres_2_2();
                case "Tres_2_2_1":
                    return new Tres_2_2_1();
                case "Tres_2_2_2":
                    return new Tres_2_2_2();
                case "Tres_2_3":
                    return new Tres_2_3();
                case "Tres_2_3_1":
                    return new Tres_2_3_1();
                case "Tres_2_3_2":
                    return new Tres_2_3_2();
                case "Tres_3":
                    return new Tres_3();
                case "Tres_3_1":
                    return new Tres_3_1();
                case "Tres_3_2":
                    return new Tres_3_2();
                case "Tres_3_2_1":
                    return new Tres_3_2_1();
                case "Tres_3_2_2":
                    return new Tres_3_2_2();
                case "Tres_4":
                    return new Tres_4();
                case "Tres_4_1":
                    return new Tres_4_1();
                case "Tres_4_2":
                    return new Tres_4_2();
                case "Tres_4_2_1":
                    return new Tres_4_2_1();
                case "Tres_5":
                    return new Tres_5();
                
                case "Cuatro_0":
                    return new Cuatro_0();
                case "Cuatro_1":
                    return new Cuatro_1();
                case "Cuatro_1_1":
                    return new Cuatro_1_1();
                case "Cuatro_1_2":
                    return new Cuatro_1_2();
                case "Cuatro_1_2_1":
                    return new Cuatro_1_2_1();
                case "Cuatro_1_2_2":
                    return new Cuatro_1_2_2();
                case "Cuatro_1_2_3":
                    return new Cuatro_1_2_3();
                case "Cuatro_2":
                    return new Cuatro_2();
                case "Cuatro_2_1":
                    return new Cuatro_2_1();
                case "Cuatro_2_2":
                    return new Cuatro_2_2();
                case "Cuatro_2_2_1":
                    return new Cuatro_2_2_1();
                case "Cuatro_2_2_2":
                    return new Cuatro_2_2_2();
                case "Cuatro_3":
                    return new Cuatro_3_1();
                case "Cuatro_3_1":
                    return new Cuatro_3_1();
                case "Cuatro_4":
                    return new Cuatro_4();
                case "Cuatro_4_1":
                    return new Cuatro_4_1();
                case "Cuatro_4_2":
                    return new Cuatro_4_2();
                case "Cinco_0":
                    return new Cinco_0();
                case "Cinco_1":
                    return new Cinco_1();
                case "Cinco_2":
                    return new Cinco_2();
                case "Cinco_2_1":
                    return new Cinco_2_1();
                case "Cinco_2_1_1":
                    return new Cinco_2_1_1();
                case "Cinco_2_1_2":
                    return new Cinco_2_1_2();
                case "Cinco_2_1_3":
                    return new Cinco_2_1_3();
                case "Cinco_2_2":
                    return new Cinco_2_2();
                case "Cinco_3":
                    return new Cinco_3();
                case "Cinco_3_1":
                    return new Cinco_3_1();
                case "Cinco_3_1_1":
                    return new Cinco_3_1_1();
                case "Cinco_3_1_2":
                    return new Cinco_3_1_2();
                case "Cinco_3_2":
                    return new Cinco_3_2();
                case "SensoresView":
                    return new SensoresView();
                case "Cinco_4_1":
                    return new Cinco_4_1();
                case "Cinco_5":
                    return new Cinco_5();
                case "Cinco_6":
                    return new Cinco_6();
                case "Cinco_7":
                    return new Cinco_7();
                case "Cinco_8":
                    return new Cinco_8();
                case "Seis_0":
                    return new Seis_0();
                case "Seis_1":
                    return new Seis_1();
                case "Seis_1_1":
                    return new Seis_1_1();
                case "Seis_1_2":
                    return new Seis_1_2();
                case "Seis_2":
                    return new Seis_2();
                case "Seis_2_1":
                    return new Seis_2_1();
                case "Seis_2_2":
                    return new Seis_2_2();
                case "Seis_2_3":
                    return new Seis_2_3();
                case "Seis_3":
                    return new Seis_3();
                case "Seis_4":
                    return new Seis_4();
                case "Seis_4_1":
                    return new Seis_4_1();
                case "Seis_4_1_1":
                    return new Seis_4_1_1();
                case "Seis_4_1_2":
                    return new Seis_4_1_2(); 
                case "Seis_5":
                    return new Seis_5();
                case "Seis_5_1":
                    return new Seis_5_1();
                case "Seis_5_1_1":
                    return new Seis_5_1_1();
                case "Seis_5_1_2":
                    return new Seis_5_1_2();
                case "Seis_5_2":
                    return new Seis_5_2();
                case "Seis_6":
                    return new Seis_6();
                case "Seis_7":
                    return new Seis_7();
                case "Seis_7_1":
                    return new Seis_7_1();
                case "Seis_7_2":
                    return new Seis_7_2();
                case "Seis_7_3":
                    return new Seis_7_3();
                case "Seis_8":
                    return new Seis_8();
                case "Seis_8_1":
                    return new Seis_8_1();
                case "Seis_8_1_1":
                    return new Seis_8_1_1();
                case "Seis_8_1_2":
                    return new Seis_8_1_2();
                case "Seis_8_2":
                    return new Seis_8_2();
                case "Seis_9":
                    return new Seis_9();
                case "Seis_9_1":
                    return new Seis_9_1();
                case "Seis_9_1_1":
                    return new Seis_9_1_1();
                case "Seis_9_1_2":
                    return new Seis_9_1_2();
                case "Seis_9_2":
                    return new Seis_9_2();
                case "Seis_10":
                    return new Seis_10();
                case "Seis_10_1":
                    return new Seis_10_1();
                case "Seis_10_1_1":
                    return new Seis_10_1_1();
                case "Seis_10_1_2":
                    return new Seis_10_1_2();
                case "Seis_10_2":
                    return new Seis_10_2();
                case "Seis_10_3":
                    return new Seis_10_3();
                case "Seis_10_4":
                    return new Seis_10_4();
                case "Seis_11":
                    return new Seis_11();
                case "Seis_11_1":
                    return new Seis_11_1();
                case "Seis_11_1_1":
                    return new Seis_11_1_1();
                case "Seis_11_1_2":
                    return new Seis_11_1_2();
                case "Seis_11_2":
                    return new Seis_11_2();
                case "Seis_12":
                    return new Seis_12();
                case "Seis_12_1":
                    return new Seis_12_1();
                case "Seis_12_1_1":
                    return new Seis_12_1_1();
                case "Seis_12_1_2":
                    return new Seis_12_1_2();
                case "Seis_12_2":
                    return new Seis_12_2();
                case "Seis_13":
                    return new Seis_13();
                case "Seis_14":
                    return new Seis_14();
                case "Siete_0":
                    return new Siete_0();
                case "Siete_1":
                    return new Siete_1();
                case "Siete_1_1":
                    return new Siete_1_1();
                case "Siete_1_2":
                    return new Siete_1_2();
                case "Siete_2":
                    return new Siete_2();
                case "Siete_2_1":
                    return new Siete_2_1();
                case "Siete_2_1_1":
                    return new Siete_2_1_1();
                case "Siete_2_1_2":
                    return new Siete_2_1_2();
                case "Siete_2_1_3":
                    return new Siete_2_1_3();
                case "Siete_2_2":
                    return new Siete_2_2();
                case "Siete_3":
                    return new Siete_3();
                case "Siete_3_1":
                    return new Siete_3_1();
                case "Siete_3_2":
                    return new Siete_3_2();
                case "Siete_4":
                    return new Siete_4();
                case "Siete_5":
                    return new Siete_5();
                case "Siete_5_1":
                    return new Siete_5_1();
                case "Siete_5_2":
                    return new Siete_5_2();
                case "Siete_6":
                    return new Siete_6();
                case "Siete_6_1":
                    return new Siete_6_1();
                case "Siete_6_1_1":
                    return new Siete_6_1_1();
                case "Siete_6_1_2":
                    return new Siete_6_1_2();
                case "Siete_6_2":
                    return new Siete_6_2();
                case "Siete_6_3":
                    return new Siete_6_3();
                case "Siete_6_4":
                    return new Siete_6_4();
                case "Siete_7":
                    return new Siete_7();
                case "Siete_8":
                    return new Siete_8();
                case "Siete_8_1":
                    return new Siete_8_1();
                case "Siete_8_2":
                    return new Siete_8_2();
                case "Siete_8_3":
                    return new Siete_8_3();
                case "Siete_9":
                    return new Siete_9();
                case "Siete_9_1":
                    return new Siete_9_1();
                case "Siete_9_2":
                    return new Siete_9_2();
                case "Siete_10":
                    return new Siete_10();
                case "Siete_10_1":
                    return new Siete_10_1();
                case "Siete_10_1_1":
                    return new Siete_10_1_1();
                case "Siete_10_1_2":
                    return new Siete_10_1_2();
                case "Siete_10_1_3":
                    return new Siete_10_1_3();
                case "Siete_10_2":
                    return new Siete_10_2();
                case "Ocho_0":
                    return new Ocho_0();
                case "Ocho_1":
                    return new Ocho_1();
                case "Ocho_1_1":
                    return new Ocho_1_1();
                case "Ocho_1_2":
                    return new Ocho_1_2();
                case "Ocho_1_3":
                    return new Ocho_1_3();
                case "Ocho_2":
                    return new Ocho_2();
                case "Ocho_3":
                    return new Ocho_3();
                case "Ocho_3_1":
                    return new Ocho_3_1();
                case "Ocho_3_1_1":
                    return new Ocho_3_1_1();
                case "Ocho_3_1_2":
                    return new Ocho_3_1_2();
                case "Ocho_3_2":
                    return new Ocho_3_2();
                case "Ocho_4":
                    return new Ocho_4();
                case "Ocho_4_1":
                    return new Ocho_4_1();
                case "Ocho_4_2":
                    return new Ocho_4_2();
                case "Ocho_4_3":
                    return new Ocho_4_3();
                case "Ocho_5":
                    return new Ocho_5();
                case "Ocho_5_1":
                    return new Ocho_5_1();
                case "Ocho_5_2":
                    return new Ocho_5_2();
                case "Ocho_6":
                    return new Ocho_6();
                case "Ocho_6_1":
                    return new Ocho_6_1();
                case "Ocho_6_2":
                    return new Ocho_6_2();
                case "Ocho_6_3":
                    return new Ocho_6_3();
                case "Ocho_7":
                    return new Ocho_7();
                case "Ocho_8":
                    return new Ocho_8();
                case "Ocho_9":
                    return new Ocho_9();
                case "Ocho_9_1":
                    return new Ocho_9_1();
                case "Ocho_9_2":
                    return new Ocho_9_2();
                default:
                    DisplayAlert("Navegacion", "La pagina '" + pageName + "' no esta disponible", "OK");
                    break;
            }
            return null;
        }
        /*************************************************************************/

    }
}

