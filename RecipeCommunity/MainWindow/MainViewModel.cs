using RecipeCommunity.RecipeUserControl;

namespace RecipeCommunity.MainWindow
{
    public class MainViewModel
    {
        public MainViewModel(string currentUsername)
        {
            CurrentUsername = currentUsername;
        }

        public static string CurrentUsername { get; set; }
        public RecipeViewModel RecipeViewModel => new RecipeViewModel();
    }
}
