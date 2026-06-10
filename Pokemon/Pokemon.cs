namespace Pokemon;

public interface IPokemon
{
  string Name { get; }
  PokemonType PrimaryType { get; set; }
  PokemonType? SecondaryType { get; set; }
  IReadOnlyList<IAbility> Abilities { get; }
  IAbility? HiddenAbility { get; }
}

public class Pokemon : IPokemon
{
  public Pokemon(string name, PokemonType primaryType, PokemonType? secondaryType, IReadOnlyList<IAbility> abilities,
    IAbility? hiddenAbility)
  {
    Name = name;

    PrimaryType = primaryType;
    if( secondaryType != null )
    {
      SecondaryType = secondaryType;
    }

    Abilities = abilities;
    if( hiddenAbility != null )
    {
      HiddenAbility = hiddenAbility;
    }
  }

  public string Name { get; }
  public PokemonType PrimaryType { get; set; }
  public PokemonType? SecondaryType { get; set; }
  public IReadOnlyList<IAbility> Abilities { get; }
  public IAbility? HiddenAbility { get; }
}
