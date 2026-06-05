// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MovingSnake movingSnake = new MovingSnake();

movingSnake.Play();

public class MovingSnake
{
    public static string Snake { get; set; }
    private static System.Timers.Timer Timer { get; set; }

    public void Play()
    {
        Snake = "      ===========================>        ";
        
        Timer = new System.Timers.Timer();
        Timer.Interval = 1000;
        Timer.Enabled = true;
        Timer.Elapsed += OnTimedEvent;
        
        Console.WriteLine("Press enter key to exit...");
        Console.ReadLine();
    }
        
    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        string newSnake = Snake[^1] + Snake[..^1];
            
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(newSnake);
        Console.WriteLine();
        Console.WriteLine();

        Snake = newSnake;
    }  
}
