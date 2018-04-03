# C# interfaces

## Abstract Classes

- abstract classes may contain abstract members/methods.

### Abstract members/methods

- abstract members/methods may not contain a definition, only a signature.
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