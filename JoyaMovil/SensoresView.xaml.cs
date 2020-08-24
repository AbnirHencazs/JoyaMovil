using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace JoyaMovil
{
    public partial class SensoresView : ContentPage
    {
        public SensoresView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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
        void MenuLateral(object sender, EventArgs eventArgs)
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = true;
        }
    }
}
