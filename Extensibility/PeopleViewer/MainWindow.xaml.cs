using PersonRepository.Interface;
using System.Windows;
using PersonRepository.Service;
using PersonRepository.CSV;
using PersonRepository.SQL;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData(RepositoryType.Service);
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData(RepositoryType.CSV);
        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FetchData(RepositoryType.SQL);
        }

        private void FetchData(RepositoryType type)
        {
            ClearListBox();
            IPersonRepository repo = RepositoryFactory.GetRepository(type);
            var people = repo.GetPeople();
            foreach (var person in people)
                PersonListBox.Items.Add(person);

            ShowRepositoryType(repo);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
        }

        private void ShowRepositoryType(IPersonRepository repository)
        {
            MessageBox.Show(string.Format("Repository Type:\n{0}",
                repository.GetType().ToString()));
        }
    }
}
