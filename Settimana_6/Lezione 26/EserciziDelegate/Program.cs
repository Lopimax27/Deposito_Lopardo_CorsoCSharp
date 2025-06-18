using System;

public delegate int Calcolo(int num1, int num2);
public delegate void Logger(string messaggio);

public class Program
{
    public static void Main(string[] args)
    {
        Calcolo sP = Somma;
        sP += Prodotto;

        foreach (Calcolo c in sP.GetInvocationList())
        {
            Console.WriteLine(c(10, 10));
        }

        Logger log = ConsoleLog;
        log += FileLog;
        log("Forza Napoli");
    }

    static int Somma(int num1, int num2) => num1 + num2;

    static int Prodotto(int num1, int num2) => num1 * num2;

    static void ConsoleLog(string messaggio) => Console.WriteLine($"{messaggio} su console");

    static void FileLog(string messaggio) => Console.WriteLine($"{messaggio} sul file");
}

