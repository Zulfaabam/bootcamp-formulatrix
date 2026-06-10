namespace Pokemon;

public interface IAbility
{
  string Name { get; }
  string Description { get; }
}

public class Blaze : IAbility
{
  private static Blaze? _instance;
  private Blaze() { }
  public string Name => "Blaze";
  public string Description => "Power up fire type move when the pokemon health is low";

  public static Blaze GetInstance()
  {
    _instance ??= new Blaze();

    return _instance;
  }
}

public class Overgrow : IAbility
{
  private static Overgrow? _instance;
  private Overgrow() { }
  public string Name => "Overgrow";
  public string Description => "Power up grass type move when the pokemon health is low";

  public static Overgrow GetInstance()
  {
    _instance ??= new Overgrow();

    return _instance;
  }
}

public class Torrent : IAbility
{
  private static Torrent? _instance;
  private Torrent() { }
  public string Name => "Torrent";
  public string Description => "Power up water type move when the pokemon health is low";

  public static Torrent GetInstance()
  {
    _instance ??= new Torrent();

    return _instance;
  }
}

public class SpeedBoost : IAbility
{
  private static SpeedBoost? _instance;
  private SpeedBoost() { }
  public string Name => "Speed Boost";
  public string Description => "Increase the pokemon speed by one stage in the end of the turn";

  public static SpeedBoost GetInstance()
  {
    _instance ??= new SpeedBoost();

    return _instance;
  }
}
