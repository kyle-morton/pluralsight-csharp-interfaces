# C# interfaces

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


#### Interfaces & Abstract members both provide compile-time checking to make sure contract is enforced

## Abstract classes vs Interfaces

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
