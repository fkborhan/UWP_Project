using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyProject
{
    public class Items : INotifyPropertyChanged
    {
        public string ITEMCODE { get; set; }
        public string _itemName;
        public string ITEMNAME
        {
            get => this._itemName;
            set
            {
                this._itemName = value;
                this.OnPropertyChanged(nameof(ITEMNAME));
            }
        }
        public string _catagory;
        public string CATAGORY
        {
            get => this._catagory;
            set
            {
                this._catagory = value;
                this.OnPropertyChanged(nameof(CATAGORY));
            }
        }
        public double _purchasePrice;
        public double PURCHASEPRICE
        {
            get => this._purchasePrice;
            set
            {
                this._purchasePrice = value;
                this.OnPropertyChanged(nameof(PURCHASEPRICE));
            }
        }
        public double _salesPrice;
        public double SALESPRICE
        {
            get => this._salesPrice;
            set
            {
                this._salesPrice = value;
                this.OnPropertyChanged(nameof(SALESPRICE));
            }
        }

        public double _qty;
        public double QTY
        {
            get => this._qty;
            set
            {
                this._qty = value;
                this.OnPropertyChanged(nameof(QTY));
            }
        }
        public string _expireDate;
        public string EXPIREDATE
        {
            get => this._expireDate;
            set
            {
                this._expireDate = value;
                this.OnPropertyChanged(nameof(EXPIREDATE));
            }
        }
        public string _image;
        public string IMAGE
        {
            get => this._image;
            set
            {
                this._image = value;
                this.OnPropertyChanged(nameof(IMAGE));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
