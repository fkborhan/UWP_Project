using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MonthlyProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            StorageFolder appFolder = ApplicationData.Current.LocalFolder;
            loc2.Text = "Path: " + appFolder.Path;
            loc1.Text = "Path: " + appFolder.Path;
            CreateTextFile2();




        }
        private void login(object sender, RoutedEventArgs e)
        {
            bool isInLandscapeMode =
 Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation ==
 Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape;
            if(!isInLandscapeMode)
            GetRecords();
            else
               GetRecordLanscapes();
        }
        public async Task GetRecords()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if(l[0]==user.Text && l[1] == pass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error1.Text = "Invalid User Name or Password. Please try again .....";
                }   

            }
            catch (Exception)
            {

            }

        }
        public async Task GetRecordLanscapes()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if (l[0] == tuser.Text && l[1] == tpass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error2.Text = "Invalid User Name or Password. Please try again .....";
                }

            }
            catch (Exception)
            {

            }

        }
        private void CreateTextFile2()
        {
            CreateTextFile();
        }
        private async Task CreateTextFile()
        {

            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
    //        if (!File.Exists(storageFolder.Path + "\\sample.txt"))
    //        {
    //            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
    //            string s = "B-001,Paradoxical Sajid,Islami Adorso o Motobad,225,200,500,2022-01-02,BookShop.JPG" + Environment.NewLine +
    //"B-002,Habluder Jonnu Programming ,Programming book,150,130,100,2022-01-01,BookShop.JPG" + Environment.NewLine + "B-003, Be Smart With Mohammad  ,Sirate Rasul,220,190,110,2022-05-01,BookShop.JPG" + Environment.NewLine + "B-004,  Spoken English  ,Learning English,230,200,130,2022-05-10,BookShop.JPG" + Environment.NewLine + "B-005, Bela Purabar Age,Islami Book Atto Unnoyun,240,210,100,2022-07-15,BookShop.JPG";

    //            await Windows.Storage.FileIO.AppendTextAsync(sampleFile, s + Environment.NewLine);
    //        }
            if (!File.Exists(storageFolder.Path + "\\users.txt"))
            {
                Windows.Storage.StorageFile sampleFile2 = await storageFolder.CreateFileAsync("users.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                var s = "forkan,123" + Environment.NewLine ;

                await Windows.Storage.FileIO.AppendTextAsync(sampleFile2, s + Environment.NewLine);
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
