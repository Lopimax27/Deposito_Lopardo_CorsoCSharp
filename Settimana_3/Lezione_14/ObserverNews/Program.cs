using System;
using System.Collections.Generic; // Necessario per usare List<T>

/// <summary>
/// Interfaccia  observer con metodo da implementare update
/// </summary>
public interface IObserver
{
    void Update(string messaggio);
}

/// <summary>
/// Interfaccia NewsAgency con metodi attach detach e news
/// </summary>
public interface INewsAgency
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void News(string messaggio);
}

/// <summary>
/// Classe concreta dell'observer mobile
/// </summary>
public class MobileApp : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Notification on mobile: {messaggio}");
    }
}

/// <summary>
/// Classe concreta del observer email
/// </summary>
public class EmailClient : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Email sent: {messaggio} ");
    }
}

/// <summary>
/// Classe concreta dell'observer di tv
/// </summary>
public class Tv : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Il presentatore dice: {messaggio} ");
    }
}

/// <summary>
/// Implementazione del pattern Singleton per gestire un'unica istanza dell'agenzia di notizie.
/// Usa il pattern Observer per notificare tutti gli osservatori registrati.
/// </summary>
public sealed class ConcreteNewsAgency : INewsAgency
{
    // Istanza statica unica della classe (Singleton)
    private static ConcreteNewsAgency _instance;
    // Lista degli osservatori che riceveranno le notifiche
    private List<IObserver> _observer = new List<IObserver>();

    // Costruttore privato per impedire la creazione di istanze esterne
    private ConcreteNewsAgency()
    {

    }

    // Proprietà per accedere all'istanza unica (Singleton pattern)
    public static ConcreteNewsAgency Instance
    {
        get
        {
            // Lazy initialization: crea l'istanza solo quando necessaria
            if (_instance == null)
            {
                _instance = new ConcreteNewsAgency();
            }
            return _instance;
        }
    }

    // Aggiunge un nuovo osservatore alla lista
    public void Attach(IObserver observer)
    {
        _observer.Add(observer);
    }
    
    // Rimuove un osservatore dalla lista
    public void Detach(IObserver observer)
    {
        _observer.Remove(observer);
    }
    
    // Invia una notizia a tutti gli osservatori registrati
    public void News(string messaggio)
    {
        // Notifica tutti gli osservatori nella lista
        foreach (var observer in _observer)
        {
            observer.Update(messaggio);
        }
    }
}

/// <summary>
/// Classe principale del programma
/// </summary>
public class Program
{
    // Punto di ingresso dell'applicazione
    public static void Main()
    {
        Menu.SceltaMenu();
    }
}

/// <summary>
/// Classe che gestisce l'interfaccia utente e le interazioni con il menu
/// </summary>
public class Menu
{
    /// <summary>
    /// Metodo principale che gestisce il menu dell'applicazione
    /// </summary>
    public static void SceltaMenu()
    {
        // Ottiene l'istanza singleton dell'agenzia di notizie
        var agenzia1 = ConcreteNewsAgency.Instance;

        bool controllo = true;
        do
        {
            // Mostra le opzioni del menu all'utente
            Console.WriteLine("1.Inserisci la news di oggi\n2.Dove vuoi inviare la notizia?\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    // Permette all'utente di inserire e inviare una notizia
                    Console.WriteLine("Inserisci la news: ");
                    string news = Console.ReadLine();
                    agenzia1.News(news); // Invia la notizia a tutti gli osservatori registrati
                    break;
                    
                case 2:
                    // Permette all'utente di scegliere e aggiungere un nuovo canale di notifica
                    agenzia1.Attach(Scelta());
                    break;
                    
                case 0:
                    // Esce dal programma
                    controllo = false;
                    break;
                    
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        } while (controllo); // Continua finché l'utente non sceglie di uscire
    }

    /// <summary>
    /// Metodo che permette all'utente di scegliere il tipo di osservatore da aggiungere
    /// </summary>
    /// <returns>Un nuovo osservatore del tipo scelto dall'utente</returns>
    public static IObserver Scelta()
    {
        // Mostra le opzioni disponibili per i canali di notifica
        Console.WriteLine("Inserisci se inviare su email, tv o mobile (1,2,3): ");
        int scelta = int.Parse(Console.ReadLine());
        
        switch (scelta)
        {
            case 1:
                // Crea e restituisce un osservatore per le email
                return new EmailClient();
            case 2:
                // Crea e restituisce un osservatore per la TV
                return new Tv();
            case 3:
                // Crea e restituisce un osservatore per l'app mobile
                return new MobileApp();
            default:
                Console.WriteLine("Errore");
                return null; // Restituisce null in caso di scelta non valida
        }
    }
}