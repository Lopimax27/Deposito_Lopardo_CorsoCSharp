using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public interface IObserver
{
    void Update(string messaggio);
}

public class SistemaLog : IObserver
{
    public void Update(string ordine)
    {
        Console.WriteLine($"Log dell'{ordine}");
    }
}
public class SistemaMarketing : IObserver
{
    public void Update(string ordine)
    {
        Console.WriteLine($"{ordine} creato, invio promozione in corso...");
    }
}

public interface IOrdini
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string messaggio);
}
public interface IPizza
{
    string Descrizione();
    string Cottura();
}

public class Margherita : IPizza
{
    public string Descrizione()
    {
        return "Pizza margherita ";
    }

    public string Cottura()
    {
        return "Pizza in cottura...";
    }

}
public class Diavola : IPizza
{
    public string Descrizione()
    {
        return "Pizza diavola ";
    }

    public string Cottura()
    {
        return "Pizza in cottura...";
    }
}
public class Vegetariana : IPizza
{
    public string Descrizione()
    {
        return "Pizza vegetariana ";
    }

    public string Cottura()
    {
        return "Pizza in cottura...";
    }
}

public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "margherita":
                return new Margherita();
            case "diavola":
                return new Diavola();
            case "vegetariana":
                return new Vegetariana();
            default:
                Console.WriteLine("Pizza non presente nel menu");
                return null;
        }
    }
}

public abstract class IngredienteDecorator : IPizza
{
    protected IPizza _pizza;

    protected IngredienteDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public virtual string Descrizione()
    {
        return _pizza.Descrizione();
    }

    public virtual string Cottura()
    {
        return _pizza.Cottura();
    }

}

public class ConOlive : IngredienteDecorator
{
    public ConOlive(IPizza pizza) : base(pizza)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ olive ";
    }
}

public class ConMozzarellaExtra : IngredienteDecorator
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ mozzarella extra ";
    }
}

public class ConFunghi : IngredienteDecorator
{
    public ConFunghi(IPizza pizza) : base(pizza)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ funghi ";
    }
}

public interface ICotturaStrategy
{
    public string Cottura(string descrizione);
}

public class FornoElettrico : ICotturaStrategy
{
    public string Cottura(string descrizione)
    {
        return $"{descrizione} Cottura: forno elettrico";
    }
}

public class FornoLegna : ICotturaStrategy
{
    public string Cottura(string descrizione)
    {
        return $"{descrizione} Cottura: forno a legna";
    }
}

public class FornoVentilato : ICotturaStrategy
{
    public string Cottura(string descrizione)
    {
        return $"{descrizione} Cottura: forno ventilato";
    }
}

public sealed class GestoreOrdine : IOrdini
{
    private static GestoreOrdine _instance;

    private List<string> _listaOrdini;
    private List<IObserver> _observers = new List<IObserver>();

    private GestoreOrdine()
    {
        _listaOrdini = new List<string>();
    }

    public static GestoreOrdine GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GestoreOrdine();
        }
        return _instance;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    // Rimuove un osservatore dalla lista
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // Invia una notizia a tutti gli osservatori registrati
    public void Notify(string ordine)
    {
        // Notifica tutti gli osservatori nella lista
        foreach (var observer in _observers)
        {
            _listaOrdini.Add(ordine);
            observer.Update(ordine);
        }
    }

    public void StampaOrdini()
    {
        foreach (string o in _listaOrdini)
        {
            Console.WriteLine(o);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Inserisci la pizza tra diavola,margherita e vegetariana:");
        string tipo = Console.ReadLine();
        var pizza = PizzaFactory.CreaPizza(tipo);

        if (pizza == null)
        {
            return;
        }

        bool controllo = true;
        do
        {
            Console.WriteLine("Cosa vuoi aggiungere 1.Olive\n2.MozzarellaExtra\n3.Funghi\n0.Niente");
            int add = int.Parse(Console.ReadLine());
            switch (add)
            {
                case 1:
                    pizza = new ConOlive(pizza);
                    break;
                case 2:
                    pizza = new ConMozzarellaExtra(pizza);
                    break;
                case 3:
                    pizza = new ConFunghi(pizza);
                    break;
                case 0:
                    controllo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        } while (controllo);
    }
}