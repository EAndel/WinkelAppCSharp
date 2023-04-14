using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelApp.Model
{
    public class Auteur : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstname;
        private string _lastname;
        private int _phonenumber;
        private string _email;
        private ObservableCollection<Item> _items;

        public int id { get; set; }
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;

                Notify("Firstname");
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;

                Notify("Lastname");
            }
        }

        public int Phonenumber
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                _phonenumber = value;


                Notify("Phonenumber");
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;


                Notify("Email");
            }
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;


                Notify("Items");
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
