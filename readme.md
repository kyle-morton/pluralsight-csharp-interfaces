# C# interfaces

__REM:__ Think of interfaces from another dev's perspective when writing them. I need methods A, B, C to do a task. 
I don't need to know (nor do I care) that methods D, E, F are used in any of these processes. It's similar to permissions,
just because something is there doesn't mean someone needs access to it.

## Abstract Classes

- abstract classes may contain abstract members/methods.
- may contain implementation code for methods that are not marked abstract.
- subclasses may only inherit <= 1 class

### Abstract members (variables, methods, etc)

- abstract members may not contain a definition, only a signature.
- compiler enforces that these are defined by any class inheriting from the abstract class.

```

public abstract class AbstractRegularPolygon 
{

    public int SideLength {get;set;}

    protected abstract decimal ComputeArea(int sideLength);

    public decimal GetArea(int sideLength) {
        return ComputeArea(sideLength);
    }

} 

```

### Virtual methods

- provide a default implmentation of a method
- can be overriden by subclasses.

```

public abstract class AbstractRegularPolygon 
{

    public int SideLength {get;set;}

    protected abstract decimal ComputeArea(int sideLength);

    public decimal GetArea(int sideLength) {
        return ComputeArea(sideLength);
    }

    public virtual DoSomething(int area) {
        Console.WriteLine("this is the default implementation of this method");
    }

} 

```

## Interfaces 

- all members must be public & are public by default

- members (variables) must also be defined in the implementing class, their syntax in the interface declaration is only a contract stating that
  the variable must exist in the implementing class

- methods lack implementation which forces any implementing class to provide definition

- classes can implement >= 1 interfaces (no limit)


##### Interfaces & Abstract members both provide compile-time checking to make sure contract is enforced

## Summary 

### Abstract class

- may contain implementation code
- a class may inherit from a single base class
- members may have access modifiers
- may contain fields, props, constructors, destructors, methods, events, & indexers

### Interfaces

- may not contain implementation code
- a class may implement 1 or more interfaces
- members automatically public
- may only contain props, methods, events, and indexers

## Best Practices

### Program to a contract (interface) rather than a concrete class

- when programming to a contract, the code using it won't know or care about the implementation details. 
- only expose those methods, etc through your interface that an outsider would need to use. Otherwise, it can be in the class itself.
- keep types as generic as possible in your interface so that you're code doesn't break on a change in another layer, by another dev, etc.

## Change happens in code

- __Concrete Classes__ - brittle/easily broken because of strong typing

- __Interfaces__ - resilient, even more so if generics are used

## Implementing interfaces in your repository

- Allows you to use different repositories, but use same type (IRepository, etc). This can be very useful when switching the location of your data (SQL vs SQLite) or mocking when developing software.

```
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
```

## Explicit Implementation 

#### When to use?
- when 2 interfaces have a method of same name/params, but different return

```

    public interface ISaveable
    {
        string Save();
    }

    public interface IVoidSavable
    {
        void Save();
    }

```

- When a different implementation is needed when concentrete/interface methods called

```

    public interface ISaveable
    {
        string Save();
    }

    public interface IPersistable
    {
        string Save();
    }

    public class ExplicitCatalog : ISaveable, IPersistable
    {
        public string Save()
        {
            return "Catalog Save";
        }

        //explicit implementation -> only called when object is cast to ISavable type
        string ISaveable.Save()
        {
            return "ISavable Save";
        }

        //explicit implementation -> only called when object is cast to IPersistable type
        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    ExplicitCatalog explicitCatalog = new ExplicitCatalog();
    ISaveable saveable = new ExplicitCatalog();
    IPersistable persistable = new ExplicitCatalog();

    Console.WriteLine("Explicit Implementation\n");
    Console.WriteLine("Concrete Class:  {0}", explicitCatalog.Save()); //Catalog Save
    Console.WriteLine("ISaveable:       {0}", saveable.Save()); //ISavable Save
    Console.WriteLine("IPersistable:    {0}", persistable.Save()); //IPersistable Save
    Console.WriteLine();

```

## Interface Inheritance

- interfaces may inherit from >= 1 interfaces

- if an interface inherits from another which has the same method name as one of the original interface's methods, then the implementing class must use __explicit implemenation__ to implement both methods (see below).

__IEnumerable< T > implements IEnumerable__
- both have a GetEnumerator() method so implementing class must explicity implement one.

```

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

```

