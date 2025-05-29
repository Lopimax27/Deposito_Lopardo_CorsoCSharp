using System;


public interface IObserver
{
    void Update(string messaggio);
}

public interface INewsAgency
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void News(string messaggio);
}

public class MobileApp : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Notification on mobile: {messaggio}");
    }
}

public class EmailClient : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Email sent: {messaggio} ");
    }
}

public class Tv : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Il presentatore dice: {messaggio} ");
    }
}

public sealed class ConcreteNewsAgency : INewsAgency
{
    private static ConcreteNewsAgency _instance;
    private List<IObserver> _observer = new List<IObserver>();

    private ConcreteNewsAgency()
    {

    }

    public static ConcreteNewsAgency Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConcreteNewsAgency();
            }
            return _instance;
        }
    }

    public void Attach(IObserver observer)
    {
        _observer.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observer.Remove(observer);
    }
    public void News(string messaggio)
    {
        foreach (var observer in _observer)
        {
            observer.Update(messaggio);
        }
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
        var agenzia1 = ConcreteNewsAgency.Instance;

        bool controllo = true;
        do
        {
            Console.WriteLine("1.Inserisci la news di oggi\n2.Dove vuoi inviare la notizia?\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci la news: ");
                    string news = Console.ReadLine();
                    agenzia1.News(news);

                    break;
                case 2:
                    agenzia1.Attach(Scelta());
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

    public static IObserver Scelta()
    {
        Console.WriteLine("Inserisci se inviare su email, tv o mobile (1,2,3): ");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1:
                return new EmailClient();
            case 2:
                return new Tv();
            case 3:
                return new MobileApp();
            default:
                Console.WriteLine("Errore");
                return null;
        }
    }


}