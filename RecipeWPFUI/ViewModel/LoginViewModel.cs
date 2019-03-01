using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RecipeWPFUI.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            LoginButtonClick = new RelayCommand(o => LoginButtonClicked("MainButton"));
        }

        RecipeContext db = new RecipeContext();

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginButtonClick { get; set; }

        public void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public void LoginButtonClicked(object sender)
        {
            Application.Current.Windows[0].Hide();
            Window mainMenu = new MainWindow();
            mainMenu.ShowDialog();
            Application.Current.Windows[0].Show();
        }

        public void CreateNewAccount()
        {

        }
    }
}
