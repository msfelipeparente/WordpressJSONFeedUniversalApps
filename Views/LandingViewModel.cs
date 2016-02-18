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
using Windows.Data.Json;
using Newtonsoft.Json.Linq;

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

        
                public async void LoadData()
        {
            Uri geturi = new Uri("http://www.meu-smartphone.com/api/get_recent_posts/");
            HttpClient client = new HttpClient();
            HttpResponseMessage responseGet = await client.GetAsync(geturi);
            string response = await responseGet.Content.ReadAsStringAsync();

        
            }

            //Posts post1 = JsonConvert.DeserializeObject<Posts>(response);
            /* JsonArray post1 = JsonValue.Parse(response).GetArray();

             /*   foreach (Post post in post1.posts)
                {
                    string date = post.date;
                    DateTime dt = Convert.ToDateTime(date);
                    string dtString = dt.ToString("dd MMM yyyy HH:mm:ss").ToUpper();

                    int dateMax = 12;

                    dtString = dtString.ToString().Substring(0, dateMax);
                    this.Items.Add(new ItemViewModel() { LineOne = post.title, LineTwo = dtString, Thumbnail = post.thumbnail, ID = post.id });


                }
             for (uint i = 0; i < post1.Count; i++)
             {
                 string title = post1.GetObjectAt(i).GetNamedString("title");
                 string thumbnail = post1.GetObjectAt(i).GetNamedString("thumbnail");
                 string date = post1.GetObjectAt(i).GetNamedString("date");
                 string id = post1.GetObjectAt(i).GetNamedString("id");
                 var chan = new Post
                 {
                     title = title,
                     date = date,
                     thumbnail = thumbnail,
                     id = id,
                 };
                 Items.Add(new ItemViewModel(chan));
             };*/

        }

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

