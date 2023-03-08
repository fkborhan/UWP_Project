using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MonthlyProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage5 : Page
    {
        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));

        }

        private void dowork2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage4));
        }
        private void dowork3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        public BlankPage5()
        {
            this.InitializeComponent();
            
            PopulateProjects();

        }

        private void PopulateProjects()
        {
            //List<Items> Projects = new List<Items>();
            GetRecords();
            
            
        }
        public async Task GetRecords()
        {

            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("sample.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 6)
                        {
                            var img = "";
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + l[7]))
                            {
                                img = Path.Combine(ApplicationData.Current.LocalFolder.Path, l[7]);
                            }
                            else
                            {
                                img = "Images/BookBundle.jpg";
                            }
                            Collection.Add(new Items() { ITEMCODE = l[0], ITEMNAME = l[1], CATAGORY = l[2], PURCHASEPRICE = int.Parse(l[3]), SALESPRICE = int.Parse(l[4]), QTY = int.Parse(l[5]), EXPIREDATE = l[6], IMAGE = img });
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }
        public ObservableCollection<Items> Activities { get; set; }
        List<Items> collection = new List<Items>();

        protected override void OnNavigatedTo(NavigationEventArgs e)

        {
           //GetRecords();
            BlankPage5 messageData = new BlankPage5();

            ItemListView.ItemsSource = messageData.Collection;

            ItemListView.SelectedIndex = 0;

        }

        public List<Items> Collection

        {

            get

            {

                return this.collection;

            }

        }
    }
    public class Item

    {

        private string _Title;

        public string Title

        {

            get

            {

                return this._Title;

            }

            set

            {

                this._Title = value;

            }

        }

        private string _Price;

        public string Price

        {

            get

            {

                return this._Price;

            }

            set

            {

                this._Price = value;

            }

        }

        private ImageSource _Image;

        public ImageSource Image

        {

            get

            {

                return this._Image;

            }

            set

            {

                this._Image = value;

            }

        }

        public void SetImage(Uri baseUri, String path)

        {

            Image = new BitmapImage(new Uri(baseUri, path));

        }

        private string _Link;

        public string Link

        {

            get

            {

                return this._Link;

            }

            set

            {

                this._Link = value;

            }

        }

        private string _Category;

        public string Category

        {

            get

            {

                return this._Category;

            }

            set

            {

                this._Category = value;

            }

        }

        private string _Description;

        public string Description

        {

            get

            {

                return this._Description;

            }

            set

            {

                this._Description = value;

            }

        }

        private string _Content;

        public string Content

        {

            get

            {

                return this._Content;

            }

            set

            {

                this._Content = value;

            }

        }

    }


}
