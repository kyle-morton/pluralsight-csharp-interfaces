using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IPersonRepository repository;

        public MainViewModel()
        {
            repository = RepositoryFactory.GetRepository();
        }

        private IEnumerable<Person> people;
        public IEnumerable<Person> People
        {
            get { return people; }
            set
            {
                people = value;
                RaisePropertyChanged("People");
            }
        }

        public string RepositoryType
        {
            get { return repository.GetType().ToString(); }
        }

        public void FetchData()
        {
            People = repository.GetPeople();
        }

        public void ClearData()
        {
            People = new List<Person>();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
