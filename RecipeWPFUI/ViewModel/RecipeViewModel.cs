using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using RecipeWPFUI.Views;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Diagnostics;

namespace RecipeWPFUI.ViewModel
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        public RecipeViewModel()
        {
            LoadDishes();
            LoadCuisines();
        }

        RecipeContext db = new RecipeContext();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public ObservableCollection<Cuisine> Cuisines
        {
            get;
            set;
        }

        public ObservableCollection<Dish> Dishes
        {
            get;
            set;
        }

        public string DescriptionTextBox
        {
            get
            {
                return "Find dishes by choosing \n" +
                       "cuisine or search for \n" +
                       "dishes from ingredients \n" +
                       "to the right.";
            }
        }

        public void LoadCuisines()
        {
            var cuisines = new ObservableCollection<Cuisine>();
            List<Cuisine> allCuisines = db.Cuisines
                            .Include(d => d.Dishes)
                            .ToList();
            allCuisines.ForEach(c => cuisines.Add(c));
            Cuisines = cuisines;
        }

        public void LoadDishes()
        {
            var dishes = new ObservableCollection<Dish>();
            List<Dish> allDishes = db.Dishes
            .Include(d => d.DishIngredientAssemblies)
            .ThenInclude(d => d.Ingredient)
            .ToList();
            allDishes.ForEach(d => dishes.Add(d));
            _view = new ListCollectionView(dishes);
        }

        private ListCollectionView _view;
        public ICollectionView View
        {
            get { return _view; }
        }

        private string _searchForDishesFromIngredient = "Search here.";
        public string SearchForDishesFromIngredient
        {

            get { return _searchForDishesFromIngredient; }
            set
            {
                _searchForDishesFromIngredient = value;
                OnPropertyChanged("SearchForDishesFromIngredient");
                if
                    (string.IsNullOrEmpty(value))
                {
                    View.Filter = null;
                }
                else
                {
                    View.Filter = item =>
                    {
                        {
                            Dish dish = item as Dish;
                            return dish.DishIngredientAssemblies
                                    .Any(i => i.Ingredient.Name.ToUpper()
                                    .Contains(value.ToUpper()));
                        }
                    };
                }
            }
        }

        private System.Drawing.Image _dishPicture;
        private Dish _selectedDish;
        public Dish SelectedDish
        {
            get { return _selectedDish; }
            set
            {
                _selectedDish = value;
                if (_selectedDish != null)
                {
                    _dishPicture = SelectedDish.ByteArrayToImage(_selectedDish.Picture);
                }
                else
                {
                    _dishPicture = null;
                }
                OnPropertyChanged("SelectedDish");
            }
        }

        private Cuisine _selectedCuisine;
        public Cuisine SelectedCuisine
        {
            get { return _selectedCuisine; }
            set
            {
                _selectedCuisine = value;
                View.Filter = item =>
                {
                    {
                        Dish dish = item as Dish;
                        return _selectedCuisine.Dishes
                        .Any(c => c.Cuisine.Dishes
                        .Any(d => d.DishName == dish.DishName));
                    }
                };
                OnPropertyChanged("SelectedCuisine");
            }
        }

    }
}
