using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using RecipeLibrary;
using RecipeCommunity.Extensions;
using System.Drawing;

namespace RecipeCommunity.RecipeUserControl
{
    public class RecipeViewModel : BaseViewModel
    {
        public RecipeViewModel()
        {
            LoadDishes();
            LoadCuisines();
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
            Cuisines = DbConnector.GetCuisines();
        }

        public void LoadDishes()
        {
            Dishes = DbConnector.GetDishes();
            FilteredDishesView = new ListCollectionView(Dishes); 
        }

        private ICollectionView _filteredDishesView;
        public ICollectionView FilteredDishesView
        {
            get 
            {
                return _filteredDishesView; 
            }
            set
            {
                _filteredDishesView = value;
                OnPropertyChanged();
            }
        }

        private string _searchForDishesFromIngredient;
        public string SearchForDishesFromIngredient
        {
            get 
            {
                return _searchForDishesFromIngredient ?? "Search here."; 
            }
            set
            {
                _searchForDishesFromIngredient = value;
                if (string.IsNullOrEmpty(value))
                {
                    FilteredDishesView.Filter = null;
                }
                else
                {
                    FilteredDishesView.Filter = item =>
                    {
                        {
                            var dish = (Dish)item;
                            foreach (var ingredient in Ingredients.Where(x => x.Name.ToUpper().Contains(value.ToUpper())).ToList())
                            {
                                if (DishIngredientLists.Where(x => x.DishId == dish.DishId).Any(x => x.IngredientId == ingredient.IngredientId))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            return false;
                        }
                    };
                }
                OnPropertyChanged();
            }
        }

        private Image _selectedDishImage;
        public Image SelectedDishImage
        {
            get 
            {
                return _selectedDishImage; 
            }
            set 
            {
                _selectedDishImage = value;
                OnPropertyChanged();
            }
        }

        private Dish _selectedDish;
        public Dish SelectedDish
        {
            get { return _selectedDish; }
            set
            {
                _selectedDish = value;
                if (_selectedDish != null)
                {
                    SelectedDishImage = HelperMethods.ByteArrayToImage(SelectedDish.Picture);
                }
                else
                {
                    SelectedDishImage = null;
                }
                OnPropertyChanged();
            }
        }

        private Cuisine _selectedCuisine;
        public Cuisine SelectedCuisine
        {
            get 
            {
                return _selectedCuisine; 
            }
            set
            {
                _selectedCuisine = value;
                FilteredDishesView.Filter = item =>
                {
                    {
                        var cuisine = (Cuisine)item;
                        if (Dishes.Where(d => d.CuisineId == cuisine.CuisineId).ToList().Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                };
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Cuisine> _cuisines;
        public ObservableCollection<Cuisine> Cuisines
        {
            get 
            {
                return _cuisines; 
            }
            set 
            {
                _cuisines = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Dish> _dishes;
        public ObservableCollection<Dish> Dishes
        {
            get
            {
                return _dishes;
            }
            set
            {
                _dishes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DishIngredientList> _dishIngredientLists;
        public ObservableCollection<DishIngredientList> DishIngredientLists
        {
            get
            {
                return _dishIngredientLists;
            }
            set
            {
                _dishIngredientLists = value;
                OnPropertyChanged();
            }
        }
    }
}
