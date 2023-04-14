using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelApp.Model
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _description;
        private double _price;
        private int _auteurid;

        public int id { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;


                Notify("Name");
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;


                Notify("Description");
            }
        }

        public int Auteurid
        {
            get
            {
                return _auteurid;
            }
            set
            {
                _auteurid = value;
            }
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
