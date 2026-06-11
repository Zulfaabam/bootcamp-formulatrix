namespace Pokemon;

internal class Program
{
  private static void Main()
  {
    var pokemon = new Pokemon(
      "Blaziken",
      120,
      PokemonType.Fire,
      PokemonType.Fighting,
      new[] { Blaze.GetInstance() },
      SpeedBoost.GetInstance()
    );

    var pokemon2 = new Pokemon(
      "Swampert",
      125,
      PokemonType.Water,
      PokemonType.Ground,
      new[] { Torrent.GetInstance() },
      null
    );

    while( pokemon.Health > 0 && pokemon2.Health > 0 )
    {
      ShowEnemyPokemon(pokemon);
      ShowTrainerPokemon(pokemon2);

      int move = ChooseMove(pokemon2);

      // run
      if( move == 2 )
      {
        Console.WriteLine("The trainer run...");
        return;
      }

      // attack
      if( move == 1 )
      {
        pokemon2.Attack(pokemon, PokemonType.Water, 30);
      }

      int enemyMove = EnemyMove(pokemon);

      if( enemyMove == 1 )
      {
        pokemon.Attack(pokemon2, PokemonType.Fire, 40);
      }
    }
    
    string winner = pokemon.Health > 0 ? pokemon.Name : pokemon2.Name;
    
    Console.WriteLine($"\n{winner} is the winner!");
  }

  public static void ShowEnemyPokemon(Pokemon pokemon)
  {
    Console.WriteLine("===================      🔥🔥🔥");
    Console.WriteLine($"=     {pokemon.Name}    =      🔥🔥🔥");
    Console.WriteLine($"=      HP: {pokemon.Health}     =      🔥🔥🔥");
    Console.WriteLine("===================      🔥🔥🔥");
    // Console.WriteLine(
    //   $"Types: {pokemon.PrimaryType} {( pokemon.SecondaryType != null ? "/ " + pokemon.SecondaryType : "" )}");
    // Console.Write("Abilities: ");
    // foreach( IAbility ability in pokemon.Abilities )
    // {
    //   Console.Write($"{ability.Name} - {ability.Description}");
    // }

    Console.WriteLine("\n");
  }

  public static void ShowTrainerPokemon(Pokemon pokemon)
  {
    Console.WriteLine("                         💦💦💦         ===================");
    Console.WriteLine($"                         💦💦💦         =     {pokemon.Name}    =");
    Console.WriteLine($"                         💦💦💦         =      HP: {pokemon.Health}    =");
    Console.WriteLine("                         💦💦💦         ===================");

    // Console.WriteLine(
    //   $"Types: {pokemon.PrimaryType} {( pokemon.SecondaryType != null ? "/ " + pokemon.SecondaryType : "" )}");
    // Console.Write("Abilities: ");
    // foreach( IAbility ability in pokemon.Abilities )
    // {
    //   Console.Write($"{ability.Name} - {ability.Description}");
    // }
  }

  public static int ChooseMove(Pokemon pokemon)
  {
    while( true )
    {
      Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
      Console.WriteLine($"║  What will {pokemon.Name} do?                 1. Attack            ║");
      Console.WriteLine("║                                         2. Run               ║");
      Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

      Console.Write("Choose action: ");

      if( !int.TryParse(Console.ReadLine(), out int res) )
      {
        Console.WriteLine("Invalid input.");
        continue;
      }

      if( res < 1 || res > 2 )
      {
        Console.WriteLine("Invalid input.");
        continue;
      }

      Console.WriteLine($"{pokemon.Name} use {res}");

      return res;
    }
  }

  public static int EnemyMove(Pokemon pokemon)
  {
    Console.WriteLine($"\n{pokemon.Name} attack!");

    return 1;
  }
}
