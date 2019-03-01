using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeWPFUI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new ViewModel.LoginViewModel();
        }
    }
}
