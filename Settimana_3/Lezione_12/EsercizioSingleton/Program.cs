using System;

public sealed class Logger
{
    private static Logger _instance;

    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"{DateTime.Now} {messaggio}");
    }
}

public class Program
{
    public static void Main()
    {
        Logger log1 = Logger.GetInstance();
        Logger log2 = Logger.GetInstance();

        log1.ScriviMessaggio("Forza Napoli");
        log2.ScriviMessaggio("Abbiamo vinto lo scudetto");

        Console.WriteLine(log2 == log1);
        Console.WriteLine(log1.GetHashCode() == log2.GetHashCode());
    }
}