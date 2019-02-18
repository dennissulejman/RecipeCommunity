using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RecipeWPFUI.ViewModel
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        RecipeContext db = new RecipeContext();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
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

        public void LoadCuisines()
        {
            var cuisines = new ObservableCollection<Cuisine>();

            List<Cuisine> allCuisines = db.Cuisines.Select(c => c).ToList();
            allCuisines.ForEach(c => cuisines.Add(c));
         
            Cuisines = cuisines;
        }

        public void LoadDishes()
        {
            //var joinedIngredients = db.Ingredients.Join(db.Dishes,
            //                     ingredient => ingredient.DishId,
            //                     dish => dish.DishId,
            //                     (ingredient, dish) => ingredient).ToList();

            var dishes = new ObservableCollection<Dish>();
            var allIngredients = db.Ingredients.Select(i => i).ToList();
            var allDishes = db.Dishes.Where(d => d.Ingredients.Any(i => i.DishId == d.DishId)).ToList();           
            allIngredients.ForEach(i => allDishes.ForEach(d => d.Ingredients.Add(i)));
            allDishes.ForEach(d => dishes.Add(d));           
            _view = new ListCollectionView(dishes);
        }

        private ListCollectionView _view;
        public ICollectionView View
        {
            get { return _view; }
        }
        
        private string _SearchForDishesFromIngredient;
        public string SearchForDishesFromIngredient           
        {            
            get { return _SearchForDishesFromIngredient; }
            set
            {
                _SearchForDishesFromIngredient = value;
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
                            return dish.Ingredients.Any(i => i.Name.ToUpper().Contains(value.ToUpper()) && dish.DishId == i.DishId);
                        }
                    };
                }
            }
        }
    }
}
