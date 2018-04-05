using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public class StandardCatalog : ISaveable, IPersistable
    {
        public void Load()
        {
        }

        public string Save()
        {
            return "Catalog Save";
        }
    }

    public class ExplicitCatalog : ISaveable, IPersistable
    {
        public string Save()
        {
            return "Catalog Save";
        }

        string ISaveable.Save()
        {
            return "ISavable Save";
        }
        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    public class Catalog : ISaveable, IVoidSavable
    {
        public string Save()
        {
            throw new NotImplementedException();
        }

        void IVoidSavable.Save()
        {
            throw new NotImplementedException();
        }
    }

    public class EnumerableCatalog : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            //our code 
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //call class instances method implementation
            return this.GetEnumerator();
        }
    }

}
