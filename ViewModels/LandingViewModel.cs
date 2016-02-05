using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Globalization;
using NavigationMenuSample.Views;
using System.Net.Http;
using Newtonsoft.Json;
using NavigationMenu.ViewModels;

namespace NavigationMenu.ViewModels
{
    public class LandingViewModel 
    {
        public LandingViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";


        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /*
               public async void LoadData()
               {    Uri geturi = new Uri("http://tnwindows.com.br/api/get_recent_posts/");
                   HttpClient client = new HttpClient();
                   HttpResponseMessage responseGet = await client.GetAsync(geturi);
                   string response = await responseGet.Content.ReadAsStringAsync();
                   textBox.Text = Convert.ToString(response)
                   var post = JsonConvert.DeserializeObject<Post>(response);

                   Items.Add(new ItemViewModel() { LineOne = post.title, LineTwo = post.content, Thumbnail = post.thumbnail, ID = post.id });


               }*/
    }


    [DataContract]
    public class Post
    {
        [DataMember]
        public string id;
        [DataMember]
        public string type;
        [DataMember]
        public string slug;
        [DataMember]
        public string title;
        [DataMember]
        public string content;
        [DataMember]
        public string excerpt;
        [DataMember]
        public string thumbnail;
        [DataMember]
        public string date;
    }

    [DataContract]
    public class Posts
    {
        [DataMember]
        public int count;
        [DataMember]
        public int count_total;
        [DataMember]
        public List<Post> posts;
    }
}

