using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class BlankPage2 : Page
    {

        ViewModel viewModel = new ViewModel();
        List<Items> a2 = new List<Items>();
        public async Task<string> GetMe()
        {
            viewModel.GetRecords();
            return "1";
        }
        public BlankPage2()
        {
           Task<string> h= GetMe();
            foreach (Items i in viewModel.a)
            {
                a2.Add(new Items { ITEMCODE = i.ITEMCODE, ITEMNAME = i.ITEMNAME, CATAGORY = i.CATAGORY, PURCHASEPRICE = i.PURCHASEPRICE, SALESPRICE = i.SALESPRICE, IMAGE = i.IMAGE });
            }
            //MessageDialog m = new MessageDialog(h.Result.ToString());
            //m.ShowAsync();
            this.DataContext = viewModel;
            this.InitializeComponent();
        }
    }
}
