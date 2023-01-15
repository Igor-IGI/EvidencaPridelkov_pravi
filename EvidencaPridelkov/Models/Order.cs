using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.Models
{
    public class Order : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private DateTime date = DateTime.Now;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private Product ordered_product;

        public Product Ordered_product
        {
            get { return ordered_product; }
            set
            {
                ordered_product = value;
                OnPropertyChanged(nameof(Ordered_product));
            }
        }

        [JsonIgnore]
        public string Product_name
        {
            get
            {
                return ordered_product.Name;
            }
        }

        [JsonIgnore]
        public string Product_unit
        {
            get
            {
                return ordered_product.Unit;
            }
        }

        [JsonIgnore]
        public double Product_price
        {
            get
            {
                return ordered_product.Price;
            }
        }

        private double amount;

        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }


        [JsonIgnore]
        public double Total_price
        {
            get { return amount * Product_price; }
        }


        public Order() { }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
