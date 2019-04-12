using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RecipeWPFUI.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            LoginButtonClick = new RelayCommand(o => LoginButtonClicked("LoginButton"));
            SignUpButtonClick = new RelayCommand(o => SignUpButtonClicked("SignUpButton"));
        }

        RecipeContext db = new RecipeContext();

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginButtonClick { get; set; }
        public ICommand SignUpButtonClick { get; set; }

        public void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public void LoginButtonClicked(object sender)
        {
            bool loggedIn = false;
            if (db.Users.Any(u => u.Username == Username) && PasswordHasher.UserGetHashedPassword(ref db, Username, Password == Password))
            {
                UserHelper.LoginUser(ref db, Username, Password);
                loggedIn = true;
            }
            

            while (loggedIn)
            {
                Application.Current.Windows[0].Hide();                
                Window mainMenu = new MainWindow();
                mainMenu.ShowDialog();
                Application.Current.Windows[0].Show();
            }

            
        }

        public void SignUpButtonClicked(object sender)
        {
            Application.Current.Windows[0].Hide();
            Window signUpWindow = new Views.SignUpView();
            signUpWindow.ShowDialog();
            Application.Current.Windows[0].Show();
        }

    }
}
