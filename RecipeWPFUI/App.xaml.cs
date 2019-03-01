using RecipeWPFUI.ViewModel;
using RecipeWPFUI.Views;
using System.Windows;

namespace RecipeWPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            Window login = new LoginView();
            login.Show();
        }
    }
}
