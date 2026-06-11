namespace Pokemon;

public enum PokemonType
{
  Normal,
  Fire,
  Water,
  Grass,
  Electric,
  Ice,
  Fighting,
  Poison,
  Ground,
  Flying,
  Psychic,
  Bug,
  Rock,
  Ghost,
  Dragon,
  Dark,
  Steel,
  Fairy
}

public static class TypeChart
{
  public static readonly Dictionary<PokemonType, PokemonType[]> Weaknesses = new()
  {
    [PokemonType.Fire] = [PokemonType.Water, PokemonType.Ground, PokemonType.Rock],
    [PokemonType.Water] = [PokemonType.Grass, PokemonType.Electric],
    [PokemonType.Grass] = [PokemonType.Fire, PokemonType.Flying, PokemonType.Bug, PokemonType.Ice, PokemonType.Poison]
  };

  public static readonly Dictionary<PokemonType, PokemonType[]> Resistances = new()
  {
    [PokemonType.Fire] =
    [
      PokemonType.Fire,
      PokemonType.Grass,
      PokemonType.Ice,
      PokemonType.Bug,
      PokemonType.Steel,
      PokemonType.Fairy
    ],
    [PokemonType.Water] = [PokemonType.Fire, PokemonType.Water, PokemonType.Ice, PokemonType.Steel],
    [PokemonType.Grass] = [PokemonType.Grass, PokemonType.Water, PokemonType.Electric, PokemonType.Ground]
  };

  public static readonly Dictionary<PokemonType, PokemonType[]> Immunities = new()
  {
    [PokemonType.Normal] = [PokemonType.Ghost],
    [PokemonType.Ghost] = [PokemonType.Normal, PokemonType.Fighting],
    [PokemonType.Steel] = [PokemonType.Poison],
    [PokemonType.Fairy] = [PokemonType.Dragon],
    [PokemonType.Dark] = [PokemonType.Psychic],
    [PokemonType.Flying] = [PokemonType.Ground],
    [PokemonType.Ground] = [PokemonType.Electric]
  };

  public static double GetMultiplier(PokemonType attackType, PokemonType defenderType)
  {
    if( Immunities.TryGetValue(defenderType, out PokemonType[]? immunities) )
    {
      if( immunities.Contains(attackType) )
      {
        return 0.0;
      }
    }

    if( Weaknesses.TryGetValue(defenderType, out PokemonType[]? weaknesses) )
    {
      if( weaknesses.Contains(attackType) )
      {
        return 2.0;
      }
    }

    if( Resistances.TryGetValue(defenderType, out PokemonType[]? resistances) )
    {
      if( resistances.Contains(attackType) )
      {
        return 0.5;
      }
    }

    return 1.0;
  }
}
