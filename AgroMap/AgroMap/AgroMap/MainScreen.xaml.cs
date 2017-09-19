﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgroMap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreen : MasterDetailPage
    {
        public MainScreen()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            ((ListView)sender).SelectedItem = null;

            var item = e.SelectedItem as MainScreenMenuItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            //IsPresented = false;

            //MasterPage.ListView.SelectedItem = null;


            if (item.Id == 0)
            {
                await Navigation.PushAsync(new InspectionScreen()); 
            }
            else if (item.Id == 1)
            {
                UserService.Logout();
                Navigation.InsertPageBefore(new LoginScreen(), this);
                await Navigation.PopAsync();
            }

        }
    }
}