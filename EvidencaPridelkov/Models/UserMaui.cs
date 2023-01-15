using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.Models
{
    public class UserMaui : INotifyPropertyChanged
    {
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private ObservableCollection<Product> products_list;

        public ObservableCollection<Product> Products_list
        {
            get { return products_list; }
            set
            {
                products_list = value;
                OnPropertyChanged(nameof(Products_list));
            }
        }

        private ObservableCollection<Order> orders_list;

        public ObservableCollection<Order> Orders_list
        {
            get { return orders_list; }
            set
            {
                orders_list = value;
                OnPropertyChanged(nameof(Orders_list));
            }
        }


        private ObservableCollection<Notes> notes_list;

        public ObservableCollection<Notes> Notes_list
        {
            get { return notes_list; }
            set
            {
                notes_list = value;
                OnPropertyChanged(nameof(Notes_list));
            }
        }

        public UserMaui() { }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
