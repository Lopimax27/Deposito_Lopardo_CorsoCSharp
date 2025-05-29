using System;

/// <summary>
/// Interfaccia Observer con update da implementare
/// </summary>
public interface IObserver
{
    void Update(string messaggio);
}

/// <summary>
/// Interfaccia subjet con attach e detatch e notify da implementare
/// </summary>
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string messaggio);
}

/// <summary>
/// Classe concreta centro meteo che implementa attach detatch e notify
/// Crea readonly la lista di observer e salva in dati il meteo e al cambio lo richiama notify
/// </summary>
public class CentroMeteo : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private string _dati;

    /// <summary>
    /// Metodo che aggiorna il meteo e richiama Notify
    /// </summary>
    /// <param name="dati"></param>
    public void AggiornaMeteo(string dati)
    {
        _dati = dati;
        Notify(dati);
    }

    /// <summary>
    /// Attacca l'observer
    /// </summary>
    /// <param name="observer"></param>
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    /// <summary>
    /// Stacca l'observer
    /// </summary>
    /// <param name="observer"></param>
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Metodo di notifica che aggiorna l'observer
    /// </summary>
    /// <param name="dati"></param>
    public void Notify(string dati)
    {
        foreach (var observer in _observers)
        {
            observer.Update(dati);
        }
    }
}

/// <summary>
/// Classe concreta di observer che implementa l' update del display
/// </summary>
public class DisplayConsole : IObserver
{
    public void Update(string dati)
    {
        Console.WriteLine($"Messaggio in console: il meteo è {dati}");
    }
}

/// <summary>
/// Classe contreta di observer che implementa l'update mobile
/// </summary>
public class DisplayMobile : IObserver
{
    public void Update(string dati)
    {
        Console.WriteLine($"Messaggio per mobile: il meteo è {dati}");
    }
}

/// <summary>
/// Classe concreta di observer che implementa l'update di mirko
/// </summary>
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
        //Defizione centro meteo console mobile e mirko
        var centroMeteo = new CentroMeteo();
        var console = new DisplayConsole();
        var mobile = new DisplayMobile();
        var mirko = new DisplayMirko();
        centroMeteo.Attach(console);
        centroMeteo.Attach(mobile);
        centroMeteo.Attach(mirko);

        bool controllo = true; //Variabile di controllo che viene impostata a false quando l'utente vuole uscire
        do
        {
            //Menu
            Console.WriteLine("1.Aggiorna il Meteo di oggi\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)//Scelta switch
            {
                case 1:
                    //Aggiorna il dato e richiama l'aggiorna Meteo
                    Console.WriteLine("Inserisci il meteo di oggi: ");
                    string dati = Console.ReadLine();
                    centroMeteo.AggiornaMeteo(dati);
                    break;
                case 0:
                    controllo = false;//Imposta a false il bool per uscire dal menu
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        } while (controllo);
    }
}