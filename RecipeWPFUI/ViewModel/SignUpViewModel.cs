using Microsoft.EntityFrameworkCore;
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
    class SignUpViewModel : INotifyPropertyChanged
    {
        public SignUpViewModel()
        {
            ConfirmButtonClick = new RelayCommand(o => ConfirmButtonClicked("ConfirmButton"));
            CancelButtonClick = new RelayCommand(o => CancelButtonClicked("CancelButton"));
        }

        RecipeContext db = new RecipeContext();

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ConfirmButtonClick { get; set; }
        public ICommand CancelButtonClick { get; set; }

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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public void ConfirmButtonClicked(object sender)
        {
            if (Password == ConfirmPassword)
            {
                try
                {
                    db.Users.Add(new User
                    {
                        Username = Username,
                        Password = PasswordHasher.UserPasswordHashing(Password),
                        RecipeList = new RecipeList()
                    });
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    Console.WriteLine("Username already taken!");
                    Console.WriteLine("Press enter to try again.");
                    Console.ReadLine();
                    db.DetachAllEntities();
                    //CreateUser(ref db);
                }
            }
        }

        public void CancelButtonClicked(object sender)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title == "Create User")
                {
                    window.Close();
                    break;
                }
            }
        }

    }
}
