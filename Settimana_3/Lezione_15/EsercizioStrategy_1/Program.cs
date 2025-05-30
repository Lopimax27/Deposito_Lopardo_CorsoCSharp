using System;

/// <summary>
/// Interfaccia strategy con metodo da implementare Calcola
/// </summary>
public interface IStrategiaOperazione
{
    double Calcola(double a, double b);
}

/// <summary>
/// Classe concreta che implementa calcola con la somma
/// </summary>
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}

/// <summary>
/// Classe concreta che implementa calcola con la sottrazione
/// </summary>
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}

/// <summary>
/// Classe concreta che implementa calcola con la moltiplicazione
/// </summary>
public class MoltiplicazioneaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}

/// <summary>
/// Classe concreta che implementa calcola con la divisione
/// </summary>
public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Non puoi dividere per zero");
            return 0;
        }
        return a / b;
    }
}

/// <summary>
/// Classe concreta calcolatrice che fa da context e imposta e poi esegue la strategia
/// </summary>
public class Calcolatrice
{
    //Campo privato strategia
    private IStrategiaOperazione _strat;

    /// <summary>
    /// Imposta la strategia
    /// </summary>
    /// <param name="strategy"></param>
    public void SetStrategy(IStrategiaOperazione strategy)
    {
        _strat = strategy;
    }

    /// <summary>
    /// Esegue l'operazione utilizzando la strategia impostata
    /// </summary>
    /// <param name="a">Primo operando</param>
    /// <param name="b">Secondo operando</param>
    public void ExecuteOperation(double a, double b)
    {
        if (_strat == null)
        {
            Console.WriteLine("Imposta una strategia prima");
            return;
        }
        double result = _strat.Calcola(a, b);
        Console.WriteLine($"Il risultato dell'operazione richiesta è {result}");
    }
}

public class Program
{
    /// <summary>
    /// Metodo principale che gestisce l'input dell'utente e l'esecuzione delle operazioni
    /// </summary>
    public static void Main()
    {
        var calcolatrice = new Calcolatrice();
        Console.Write("Inserisci il primo numero: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Che operazione vuoi effettuare ?");
        string scelta = Console.ReadLine();

        switch (scelta.ToLower())
        {
            case "somma":
                calcolatrice.SetStrategy(new SommaStrategia());
                calcolatrice.ExecuteOperation(a, b);
                break;
            case "sottrazione":
                calcolatrice.SetStrategy(new SottrazioneStrategia());
                calcolatrice.ExecuteOperation(a, b);
                break;
            case "moltiplicazione":
                calcolatrice.SetStrategy(new MoltiplicazioneaStrategia());
                calcolatrice.ExecuteOperation(a, b);
                break;
            case "divisione":
                calcolatrice.SetStrategy(new DivisioneStrategia());
                calcolatrice.ExecuteOperation(a, b);
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;

        }
    }
}