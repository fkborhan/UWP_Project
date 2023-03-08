using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MonthlyProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       public ViewModel viewModel = new ViewModel();
        public MainPage()
        {
            CreateTextFile2();
            this.DataContext = viewModel;
            this.InitializeComponent();
        }

        
        public async Task GetRecords()
        {
            var all = "";
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
                            var b = (from c in viewModel.a where c.ITEMCODE == tid.Text select c).FirstOrDefault();
                            if (b.ITEMCODE!=l[0])
                            all += $"{l[0]},{l[1]},{l[2]},{int.Parse(l[3])},{int.Parse(l[4])},{int.Parse(l[5])},{l[6]},{img}" + Environment.NewLine;
                            else
                                all += $"{tid.Text},{tfname.Text},{tlname.Text},{int.Parse(tfather.Text)},{int.Parse(tmother.Text)},{int.Parse(tclass.Text)},{taddate.Text},{img}" + Environment.NewLine;
                        }
                    }
                    StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await storageFolder.GetFileAsync("sample.txt");
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, all);
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }
        public async Task RemoveRecords()
        {
            var all = "";
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
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path+"\\"+ l[7]))
                            {
                                img = Path.Combine(ApplicationData.Current.LocalFolder.Path, l[7]);
                            }
                            else
                            {
                                img = "Images/BookBundle.jpg";
                            }
                            var b = (from c in viewModel.a where c.ITEMCODE == tid.Text select c).FirstOrDefault();
                            if (b.ITEMCODE != l[0])
                                all += $"{l[0]},{l[1]},{l[2]},{int.Parse(l[3])},{int.Parse(l[4])},{int.Parse(l[5])},{l[6]},{img}" + Environment.NewLine;                          
                        }
                    }
                    StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                        await storageFolder.GetFileAsync("sample.txt");
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, all);
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }

        private void add2(object sender, RoutedEventArgs e)
        {
            // ViewModel viewModel = new ViewModel();
            // viewModel.GetRecords();
            //Thread.Sleep(5000);
            //var b = (from c in viewModel.a where c.ITEMCODE == tid.Text select c).FirstOrDefault();
            ////string a = tmother.Text ;
            //var all = "";
            GetRecords();
            MessageDialog s = new MessageDialog("Saved");
            s.ShowAsync();
        }

        private void del2(object sender, RoutedEventArgs e)
        {
            RemoveRecords();
            MessageDialog s = new MessageDialog("Removed");
            s.ShowAsync();
            this.Frame.Navigate(typeof(BlankPage1));
        }
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
            this.Frame.Navigate(typeof(BlankPage5));
        }
        private void CreateTextFile2()
        {
            CreateTextFile();
        }
        private async Task CreateTextFile()
        {
           
            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
            if (!File.Exists(storageFolder.Path + "\\sample.txt"))
            {
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                string s = "B-001,Paradoxical Sajid,Islami Adorso o Motobad,225,200,500,2022-01-02,BookShop.JPG" + Environment.NewLine +
    "B-002,Habluder Jonnu Programming ,Programming book,150,130,100,2022-01-01,BookShop.JPG" + Environment.NewLine + "B-003, Be Smart With Mohammad,Sirate Rasul,220,190,110,2022-05-01,BookShop.JPG" + Environment.NewLine + "B-004,Spoken English,Learning English,230,200,130,2022-05-10,BookShop.JPG" + Environment.NewLine + "B-005,Bela Purabar Age,Islami Book Atto Unnoyun,240,210,100,2022-07-15,BookShop.JPG";

                await Windows.Storage.FileIO.AppendTextAsync(sampleFile, s + Environment.NewLine);
                Windows.Storage.StorageFile sampleFile2 = await storageFolder.CreateFileAsync("users.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                s = "karim,123" + Environment.NewLine +
    "rahim,456";

                await Windows.Storage.FileIO.AppendTextAsync(sampleFile2, s + Environment.NewLine);
            }
        }
    }
}
