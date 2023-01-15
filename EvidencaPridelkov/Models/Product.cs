using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.Models
{
    public class Product : INotifyPropertyChanged
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
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string unit;

        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));

            }
        }

        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private double sold_quantity;

        public double Sold_quantity
        {
            get { return sold_quantity; }
            set
            {
                sold_quantity = value;
                OnPropertyChanged(nameof(Sold_quantity));
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private double? min_qt_limit;

        public double? Min_qt_limit
        {
            get { return min_qt_limit; }
            set
            {
                min_qt_limit = value;
                OnPropertyChanged(nameof(Min_qt_limit));
            }
        }

        public Product() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
