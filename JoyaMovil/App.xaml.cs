using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Com.OneSignal;
namespace JoyaMovil
{
    public partial class App : Application
    {
        //Permite la navegación desde el menú lateral
        public static MasterDetailPage MasterD { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new SensoresView();
            MainPage = new MainPage();
            //OneSignal.Current.StartInit("7af5acdb-91f8-49f6-b9d5-1994c4a29191").EndInit();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //MainPage = new login();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
