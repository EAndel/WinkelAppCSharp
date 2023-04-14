using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WinkelApp.Classes;
using WinkelApp.Model;

namespace WinkelApp.ViewModel
{
    public class MainWindowViewModel
    {
        public Auteur SelectedAuteur { get; set; }
        public Item SelectedItem { get; set; }
        public ObservableCollection<Auteur> AllAuteurs { get; set; }
        public ObservableCollection<Item> AllItems { get; set; }
        public ICommand AddAuteurClick { get; set; }
        public ICommand AddItemClick { get; set; }
        public ICommand UpdateClick { get; set; }
        public ICommand RemoveAuteurClick { get; set; }
        public ICommand RemoveItemClick { get; set; }

        private WinkelContext _db;

        public MainWindowViewModel()
        {
            _db = new WinkelContext();

            _db.Auteurs.Include(Auteur => Auteur.Items).Load();
            _db.Items.Load();

            AllAuteurs = _db.Auteurs.Local.ToObservableCollection();
            AllItems = _db.Items.Local.ToObservableCollection();

            AddAuteurClick = new RelayCommand(AddAuteur);
            AddItemClick = new RelayCommand(AddItem);
            UpdateClick = new RelayCommand(Update);
            RemoveAuteurClick = new RelayCommand(RemoveAuteur);
            RemoveItemClick = new RelayCommand(Removeitem);
        }

        private void AddAuteur(object a)
        {
            Auteur newAuteur = new Auteur
            {
                Firstname = "Add your firstname here!",
                Lastname = "Add your lastname here!",
                Phonenumber = 0612345678,
                Email = "Add your email here!"
            };
            
            SelectedAuteur = newAuteur;
            AllAuteurs.Add(newAuteur);
        }
        private void AddItem(object a)
        {
            if (SelectedAuteur != null)
            {
                Item newItem = new Item
                {
                    Auteurid = SelectedAuteur.id,
                    Name = "Add Item name here!",
                    Price = 0,
                    Description = "Add your description here!"
                };

                SelectedItem = newItem;
                AllItems.Add(newItem);
            }
        }
        private void Update(object a)
        {
            _db.SaveChanges();
        }
        private void RemoveAuteur(object a)
        {
            AllAuteurs.Remove(SelectedAuteur);
            _db.SaveChanges();
        }
        private void Removeitem(object a)
        {
            AllItems.Remove(SelectedItem);
            _db.SaveChanges();
        }
    }
}
