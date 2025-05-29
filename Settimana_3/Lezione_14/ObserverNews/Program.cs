using System;


public interface IObserver
{
    void Update(string messaggio);
}

public class ConcreteObserver
{
    public void Update(string messaggio)
    { 
        
    }
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

public sealed class ConcreteNewsAgency : INewsAgency
{
    private static ConcreteNewsAgency _instance;
    private IObserver _observer;

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
        _observer = observer;
    }
    public void Detach(IObserver observer)
    {
        _observer = null;
    }
    public void News(string messaggio)
    {
        _observer.Update(messaggio);
    }
}

public class Program
{
    public static void Main()
    {
        var agenzia = ConcreteNewsAgency.Instance;
        var email = new EmailClient();
        var mobile = new MobileApp();

        agenzia.Attach(mobile);
        agenzia.News("Sei un campione");

        var agenzia2 = ConcreteNewsAgency.Instance;

        agenzia2.Attach(email);
        agenzia2.News("Il napoli ha vinto lo scudetto");

        Console.WriteLine(agenzia == agenzia2);
    }
}