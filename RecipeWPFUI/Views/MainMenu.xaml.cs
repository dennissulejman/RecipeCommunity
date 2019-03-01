using System.Windows;

namespace RecipeWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RecipeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            RecipeViewControl.DataContext = new ViewModel.RecipeViewModel();
        }
    }
}
