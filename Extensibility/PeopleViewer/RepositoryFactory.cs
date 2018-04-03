using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(RepositoryType type)
        {
            IPersonRepository repo = null;
            switch(type)
            {
                case RepositoryType.Service:
                    repo = new ServiceRepository();
                    break;
                case RepositoryType.CSV:
                    repo = new CSVRepository();
                    break;
                case RepositoryType.SQL:
                    repo = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repo type");
            }
            return repo;
        }

    }
    public enum RepositoryType
    {
        Service,
        CSV,
        SQL
    }
}
