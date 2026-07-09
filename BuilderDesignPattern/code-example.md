### Gundam (Product)

```csharp

public class Gundam
{
    private readonly List<string> _parts = new();

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public string ListParts()
    {
        return "Gundam Parts:\n- " + string.Join("\n- ", _parts);
    }
}
```

### Builder

```csharp
// builder interface
public interface IGundamBuilder
{
    void Reset();

    void BuildHead();
    void BuildBody();
    void BuildArms();
    void BuildLegs();
    void BuildBackpack();
    void BuildWeapons();

    Gundam GetGundam();
}

// builders
public class AssaultBuilder : IGundamBuilder
{
    private Gundam _gundam = new();

    public void Reset() => _gundam = new Gundam();

    public void BuildHead() => _gundam.Add("Standard Head");

    public void BuildBody() => _gundam.Add("Standard Body");

    public void BuildArms()  => _gundam.Add("Standard Arms");

    public void BuildLegs() => _gundam.Add("Standard Legs");

    public void BuildBackpack() => _gundam.Add("Shield Backpack");

    public void BuildWeapons()  => _gundam.Add("Beam Rifle");

    public Gundam GetGundam()
    {
        var result = _gundam;
        Reset();
        return result;
    }
}

public class AerialBuilder : IGundamBuilder
{
    private Gundam _gundam = new();

    public void Reset() => _gundam = new Gundam();

    public void BuildHead() => _gundam.Add("Standard Head");

    public void BuildBody() => _gundam.Add("Winged Body");

    public void BuildArms() => _gundam.Add("Standard Arms");

    public void BuildLegs() => _gundam.Add("Jet Legs");

    public void BuildBackpack() => _gundam.Add("Flight Wings");

    public void BuildWeapons() => _gundam.Add("Beam Saber");

    public Gundam GetGundam()
    {
        var result = _gundam;
        Reset();
        return result;
    }
}

public class HeavyBuilder : IGundamBuilder
{
    private Gundam _gundam = new();

    public void Reset() => _gundam = new Gundam();

    public void BuildHead() => _gundam.Add("Heavy Sensor Head");

    public void BuildBody() => _gundam.Add("Heavy Armor Body");

    public void BuildArms() => _gundam.Add("Heavy Arms");

    public void BuildLegs() => _gundam.Add("Reinforced Legs");

    public void BuildBackpack() => _gundam.Add("Heavy Shield");

    public void BuildWeapons() => _gundam.Add("Bazooka");

    public Gundam GetGundam()
    {
        var result = _gundam;
        Reset();
        return result;
    }
}

```

### Director

```csharp
public class Director
{
    private IGundamBuilder _builder;

    public IGundamBuilder Builder
    {
        set => _builder = value;
    }

    public void BuildBaseModel()
    {
        _builder.BuildHead();
        _builder.BuildBody();
        _builder.BuildArms();
        _builder.BuildLegs();
    }

    public void BuildFullFeaturedModel()
    {
        BuildBaseModel();
        _builder.BuildBackpack();
        _builder.BuildWeapons();
    }
}

```

### Usage

```csharp
var director = new Director();

// Assault Gundam
var assaultBuilder = new AssaultBuilder();

director.Builder = assaultBuilder;
director.BuildFullFeaturedModel();

var assault = assaultBuilder.GetGundam();
Console.WriteLine(assault.ListParts());


// Aerial Gundam
var aerialBuilder = new AerialBuilder();

director.Builder = aerialBuilder;
director.BuildFullFeaturedModel();

var aerial = aerialBuilder.GetGundam();
Console.WriteLine(aerial.ListParts());


// Heavy Gundam
var heavyBuilder = new HeavyBuilder();

director.Builder = heavyBuilder;
director.BuildFullFeaturedModel();

var heavy = heavyBuilder.GetGundam();
Console.WriteLine(heavy.ListParts());
```

### Fluent

```csharp
public class HeavyBuilder : IGundamBuilder
{
    private Gundam _gundam = new();

    public void Reset() => _gundam = new Gundam();

    public IGundamBuilder BuildHead()
    {
        _gundam.Add("Heavy Sensor Head");
        return this;
    }

    public IGundamBuilder BuildBody()
    {
        _gundam.Add("Heavy Armor Body");
        return this;
    }

    public IGundamBuilder BuildWeapons()
    {
        _gundam.Add("Bazooka");
        return this;
    }

    public Gundam Build()
    {
        Gundam result = _gundam;
        Reset();
        return result;
    }
}
```