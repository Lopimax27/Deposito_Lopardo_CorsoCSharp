using System;

public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string nomeUtente);
}

public class GestoreCreazioneUtente : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string nomeUtente)
    {
        foreach (var observer in _observers)
        {
            observer.NotificaCreazione(nomeUtente);
        }
    }

    public Utente CreaUtente(string nome)
    {
        Utente u=UserFactory.Crea(nome);
        Notify(nome);
        return u;
    }
}

public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}

public class Utente
{
    private string _nome;
    public string Nome
    {
        get
        {
            return _nome;
        }
        set
        {
            _nome = value;
        }
    }
    public Utente(string ut)
    {
        Nome = ut;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}";
    }
}

public class ModuloLog:IObserver
{
    public void NotificaCreazione(string nome)
    {
        Console.WriteLine($"Utente {nome} creato nel modulo log");
    }
}

public class ModuloMarketLog : IObserver
{
    public void NotificaCreazione(string nome)
    {
        Console.WriteLine($"Utente {nome} creato nel modulo market");
    }
}

public class Program
{
    public static void Main()
    {
        Menu.SceltaMenu();
    }
}

public class Menu
{
    public static void SceltaMenu()
    {
        List<Utente> utenti = new List<Utente>();
        var gUC = new GestoreCreazioneUtente();
        var log = new ModuloLog();
        var logMarket = new ModuloMarketLog();
        bool controllo = true;
        do
        {
            Console.WriteLine("1.Crea l'utente\n2.Stampa gli utenti creati\n3.Premilo per ricevere le notifiche\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il nome dell'utente da creare: ");
                    string nome = Console.ReadLine();
                    utenti.Add(gUC.CreaUtente(nome));
                    break;
                case 2:
                    Stampa(utenti);
                    break;
                case 3:
                    gUC.Attach(logMarket);
                    gUC.Attach(log);
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

    public static void Stampa(List<Utente> utenti)
    {
        foreach (Utente u in utenti)
        {
            Console.WriteLine(u);
        }
    }
}