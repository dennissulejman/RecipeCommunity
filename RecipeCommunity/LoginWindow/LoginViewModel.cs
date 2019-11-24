using RecipeCommunity.Extensions;
using RecipeCommunity.MainWindow;
using System.Windows;
using System.Windows.Input;

namespace RecipeCommunity.LoginWindow
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        public ICommand LoginUserCommand => new RelayCommand(o => LoginUser());
        public ICommand OpenSignUpWindowCommand => new RelayCommand(o => OpenSignUpWindow());

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public void LoginUser()
        {
            bool loggedIn = DbConnector.UserAuthenticationConfirmed(Username, Password);
            Password = "";

            if (loggedIn)
            {
                Username = "";
                Application.Current.Windows[0].Hide();
                var mainMenu = new MainWindow.MainWindow
                {
                    DataContext = new MainViewModel(Username)
                };
                mainMenu.ShowDialog();
                Application.Current.Windows[0].Show();
            }
        }

        public void OpenSignUpWindow()
        {
            Application.Current.Windows[0].Hide();
            Window signUpWindow = new SignUpWindow.SignUpWindow();
            signUpWindow.ShowDialog();
            Application.Current.Windows[0].Show();
        }

    }
}
