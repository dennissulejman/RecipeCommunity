using RecipeLibrary;
using System.Collections.ObjectModel;
using System.Linq;

namespace RecipeCommunity.Extensions
{
    public static class DbConnector
    {
        public static ObservableCollection<Cuisine> GetCuisines()
        {
            using var db = new RecipeContext();
            return new ObservableCollection<Cuisine>(db.Cuisines);
        }

        public static ObservableCollection<Dish> GetDishes()
        {
            using var db = new RecipeContext();
            return new ObservableCollection<Dish>(db.Dishes);
        }

        public static bool UserAuthenticationConfirmed(string username, string password)
        {
            using var db = new RecipeContext();
            if (username != null)
            {
                var usersHashedPassword = db.Users.Where(x => x.Username == username).FirstOrDefault().Password;
                return PasswordHasher.IsPasswordCorrect(username, usersHashedPassword);
            }
            else
            {
                return false;
            }
        }
    }
}
