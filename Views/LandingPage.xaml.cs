<<<<<<< HEAD
﻿using NavigationMenu.ViewModels;
=======
using NavigationMenu.ViewModels;
>>>>>>> origin/master
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NavigationMenuSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        private ObservableCollection<ItemViewModel> Items;

        public LandingPage()
        {
            this.InitializeComponent();

            Items = new ObservableCollection<ItemViewModel>();

            LoadData();
            /*
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
               
            }*/
        }


        public async void LoadData()
        {
            Uri geturi = new Uri("http://tnwindows.com.br/api/get_recent_posts/");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            string response = await responseGet.Content.ReadAsStringAsync();
            Posts post1 = JsonConvert.DeserializeObject<Posts>(response);
            if (post1.posts != null && post1.posts.Count > 0)
            {
                foreach (Post post in post1.posts)
                {
                    string date = post.date;
                    DateTime dt = Convert.ToDateTime(date);
                    string dtString = dt.ToString("dd MMM yyyy HH:mm:ss").ToUpper();

                    int dateMax = 12;

                    dtString = dtString.ToString().Substring(0, dateMax);
                    this.Items.Add(new ItemViewModel() { LineOne = post.title, LineTwo = dtString, Thumbnail = post.thumbnail, ID = post.id });

<<<<<<< HEAD

=======
>>>>>>> origin/master
                }

            }
        }
    }
}

