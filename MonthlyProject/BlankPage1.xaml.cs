using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
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
    
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            StorageFolder appFolder = ApplicationData.Current.LocalFolder;

            // Print the folder's path to the Visual Studio Output window.
            MessageDialog s=new MessageDialog(appFolder.Name + " folder path: " + appFolder.Path);
            s.ShowAsync();
            add3();
            this.InitializeComponent();
        }

        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void add2(object sender, RoutedEventArgs e)
        {
            DisplayInformation displayInfo = DisplayInformation.GetForCurrentView();
            if(displayInfo.CurrentOrientation== DisplayOrientations.Landscape)
                add4(1);
            else
                add4(0);
            MessageDialog a = new MessageDialog("Saved");
            a.ShowAsync();
        }
        private async Task add3()
        {
            StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
           StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.FailIfExists);
        }
        private async Task add4(int i=0)
        {
            string s = "";
            if (i==1)
             s= $"{tid.Text},{tfname.Text},{tlname.Text},{tfather.Text},{tmother.Text},{tclass.Text},{taddate.Date.Year+"-"+ taddate.Date.Month+"-"+ taddate.Date.Day},{file.Name}";
            else
             s = $"{cid.Text},{cfname.Text},{clname.Text},{cfather.Text},{cmother.Text},{cclass.Text},{caddate.Date.Year + "-" + caddate.Date.Month + "-" + caddate.Date.Day},{file.Name}";
            StorageFolder storageFolder =
    ApplicationData.Current.LocalFolder;
            StorageFile sampleFile =
                await storageFolder.GetFileAsync("sample.txt");
            await Windows.Storage.FileIO.AppendTextAsync(sampleFile,s+ Environment.NewLine );
        }
        StorageFile file;
        private async void upload(object sender, RoutedEventArgs e)
        {
           
            try
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.Thumbnail;
                openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                openPicker.FileTypeFilter.Add(".jpg");
                file = await openPicker.PickSingleFileAsync();
                if (file != null)
                {
                    
                    await file.CopyAsync(ApplicationData.Current.LocalFolder,file.Name,NameCollisionOption.ReplaceExisting);
                   
                    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    var image = new BitmapImage();
                    image.SetSource(stream);
                    img.Source = image;
                    img.Stretch = Stretch.UniformToFill;
                    cimg.Source = image;
                    cimg.Stretch = Stretch.UniformToFill;
                   
                }
            }
            catch (Exception ex)
            {

            }
        }
        
    }
}
