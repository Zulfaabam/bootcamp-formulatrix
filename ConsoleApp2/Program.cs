// SensorTemperatureLogger

using System.Timers;

Console.Clear();

SensorTemperatureLogger sensorTemperatureLogger = new SensorTemperatureLogger();

sensorTemperatureLogger.Log();

public class SensorTemperatureLogger
{
    private static System.Timers.Timer _timer;
    private int Temperature { get; set; }

    public void Log()
    {
        Console.Write("Initial temperature: ");
        
        Temperature = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Temperature: " + Temperature);
        
        _timer = new System.Timers.Timer();
        _timer.Interval = 1000;

        _timer.Elapsed += OnTimedEvent;
        
        _timer.AutoReset = true;

        // Start the timer
        _timer.Enabled = true;
        
        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();
    }
    
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        DateTime time = e.SignalTime;
        
        Console.WriteLine($"[{time:G}]: {Temperature} °C", e.SignalTime);
    }
}
