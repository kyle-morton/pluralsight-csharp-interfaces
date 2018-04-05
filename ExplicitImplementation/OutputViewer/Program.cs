using Library;
using System;

namespace OutputViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardCatalog standardCatalog = new StandardCatalog();
            ISaveable savableStandard = new StandardCatalog();
            IPersistable persistableStandard = new StandardCatalog();

            Console.WriteLine("Standard Implementation\n");
            Console.WriteLine("Concrete Class:  {0}", standardCatalog.Save());
            Console.WriteLine("ISaveable:       {0}", savableStandard.Save());
            Console.WriteLine("IPersistable:    {0}", persistableStandard.Save());
            Console.WriteLine();

            Console.WriteLine("Concrete Class:        {0}", standardCatalog.Save());
            Console.WriteLine("(ISaveable)Catalog:    {0}", ((ISaveable)standardCatalog).Save());
            Console.WriteLine("(IPersistable)Catalog: {0}", ((IPersistable)standardCatalog).Save());
            Console.WriteLine();

            Console.WriteLine("================================================");

            ExplicitCatalog explicitCatalog = new ExplicitCatalog();
            ISaveable saveable = new ExplicitCatalog();
            IPersistable persistable = new ExplicitCatalog();

            Console.WriteLine("Explicit Implementation\n");
            Console.WriteLine("Concrete Class:  {0}", explicitCatalog.Save());
            Console.WriteLine("ISaveable:       {0}", saveable.Save());
            Console.WriteLine("IPersistable:    {0}", persistable.Save());
            Console.WriteLine();

            Console.WriteLine("Concrete Class:      {0}", explicitCatalog.Save());
            Console.WriteLine("(ISaveable)Catalog:    {0}", ((ISaveable)explicitCatalog).Save());
            Console.WriteLine("(IPersistable)Catalog: {0}", ((IPersistable)explicitCatalog).Save());
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
