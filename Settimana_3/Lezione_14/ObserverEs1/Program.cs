using System;

public interface IObserver
{
    void Update(string messaggio);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string messaggio);
}

public class CentroMeteo : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private string _dati;

    public void AggiornaMeteo(string dati)
    {
        _dati = dati;
        Notify(dati);
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string dati)
    {
        foreach (var observer in _observers)
        {
            observer.Update(dati);
        }
    }
}

public class DisplayConsole : IObserver
{
    public void Update(string dati)
    {
        Console.WriteLine($"Messaggio in console: il meteo è {dati}");
    }
}

public class DisplayMobile : IObserver
{
    public void Update(string dati)
    {
        Console.WriteLine($"Messaggio per mobile: il meteo è {dati}");
    }
}

public class DisplayMirko : IObserver
{
    public void Update(string dati)
    {
        Console.WriteLine($"Messaggio per Mirko:{dati} Ma smettila di mutarmi");
    }
}


public class Program
{
    public static void Main()
    {
        var centroMeteo = new CentroMeteo();
        var console = new DisplayConsole();
        var mobile = new DisplayMobile();
        var mirko = new DisplayMirko();
        centroMeteo.Attach(console);
        centroMeteo.Attach(mobile);
        centroMeteo.Attach(mirko);

        bool controllo = true;
        do
        {
            Console.WriteLine("1.Aggiorna il Meteo di oggi\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il meteo di oggi: ");
                    string dati = Console.ReadLine();
                    centroMeteo.AggiornaMeteo(dati);
                    break;
                case 0:
                    controllo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        } while (controllo);
    }
}