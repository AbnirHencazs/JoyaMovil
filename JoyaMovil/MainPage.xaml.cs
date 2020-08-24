using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Detalle();
            this.Detail = new NavigationPage(new login());

            App.MasterD = this;
        }
    }
}
