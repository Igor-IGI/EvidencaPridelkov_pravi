using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.Models
{
    public class Notes : INotifyPropertyChanged
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

        private string header;

        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public Notes() { }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
