namespace Pokemon;

internal class Program
{
  private static void Main()
  {
    var pokemon = new Pokemon(
      "Blaziken",
      PokemonType.Fire,
      PokemonType.Fighting,
      new[] { Blaze.GetInstance() },
      SpeedBoost.GetInstance()
    );

    var pokemon2 = new Pokemon(
      "Swampert",
      PokemonType.Water,
      PokemonType.Ground,
      new[] { Torrent.GetInstance() },
      null
    );

    ShowEnemyPokemon(pokemon);
    ShowTrainerPokemon(pokemon2);

    int move = ChooseMove(pokemon2);

    ShowEnemyPokemon(pokemon);
    ShowTrainerPokemon(pokemon2);
  }

  public static void ShowEnemyPokemon(Pokemon pokemon)
  {
    Console.WriteLine("===================      🔥🔥🔥");
    Console.WriteLine($"=     {pokemon.Name}    =      🔥🔥🔥");
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
      Console.WriteLine($"║  What will {pokemon.Name} do?                 1. Move     3. Bag   ║");
      Console.WriteLine("║                                         2. Pokemon  4. Run   ║");
      Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");

      Console.Write("Choose action: ");

      if( !int.TryParse(Console.ReadLine(), out int res) )
      {
        Console.WriteLine("Invalid input.");
        continue;
      }

      if( res < 1 || res > 4 )
      {
        Console.WriteLine("Invalid input.");
        continue;
      }

      Console.WriteLine($"{pokemon.Name} use {res}");

      return res;
    }
  }
}
