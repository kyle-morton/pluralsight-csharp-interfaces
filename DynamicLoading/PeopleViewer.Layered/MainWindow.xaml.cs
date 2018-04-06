using PersonRepository.Interface;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
        }

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.FetchData();
            ShowRepositoryType();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ClearData();
        }

        private void ShowRepositoryType()
        {
            MessageBox.Show(string.Format("Repository Type:\n{0}",
                viewModel.RepositoryType));
        }
    }
}
