namespace Pokemon;

public interface IPokemon
{
  string Name { get; }
  PokemonType PrimaryType { get; set; }
  PokemonType? SecondaryType { get; set; }
  IReadOnlyList<IAbility> Abilities { get; }
  IAbility? HiddenAbility { get; }
  double Health { get; set; }
  void Attack(Pokemon targetPokemon, PokemonType attackType, int damage);
}

public class Pokemon : IPokemon
{
  public Pokemon(string name, int health, PokemonType primaryType, PokemonType? secondaryType,
    IReadOnlyList<IAbility> abilities,
    IAbility? hiddenAbility)
  {
    Name = name;
    Health = health;

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
  public double Health { get; set; }

  public void Attack(Pokemon targetPokemon, PokemonType attackType, int damage)
  {
    double multiplier = TypeChart.GetMultiplier(attackType, targetPokemon.PrimaryType);
    double totalDamage = damage * multiplier;

    targetPokemon.Health -= totalDamage;

    switch( multiplier )
    {
      case <= 0.0:
        Console.WriteLine("It doesn't affect the opposing pokemon...");
        break;
      
      case >= 4.0:
        Console.WriteLine("It's extremely effective!");
        break;

      case >= 2.0:
        Console.WriteLine("It's super effective!");
        break;

      case < 1.0:
        Console.WriteLine("It's not very effective...");
        break;

      default:
        Console.WriteLine("It's effective...");
        break;
    }
  }
}
