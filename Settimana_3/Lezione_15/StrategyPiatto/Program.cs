using System;

public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Il piatto è una pizza ";
    }

    public string Prepara()
    {
        return "Pizza in preparazione...";
    }
}

public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Il piatto è una hamburger ";
    }

    public string Prepara()
    {
        return "Hamburger in preparazione...";
    }
}

public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Il piatto è un'insalata ";
    }

    public string Prepara()
    {
        return "Insalata in preparazione...";
    }
}

public abstract class IngredientiExtra : IPiatto
{
    protected IPiatto _piatto;

    protected IngredientiExtra(IPiatto piatto)
    {
        _piatto = piatto;
    }

    public virtual string Descrizione()
    {
        return _piatto.Descrizione();
    }

    public virtual string Prepara()
    {
        return _piatto.Prepara();
    }

}

public class ConFormaggio : IngredientiExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ formaggio ";
    }
}

public class ConBacon : IngredientiExtra
{
    public ConBacon(IPiatto piatto) : base(piatto)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ bacon ";
    }
}

public class ConSalsa : IngredientiExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ salsa ";
    }
}

public static class PiattoFactory
{
    public static IPiatto Crea(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "pizza":
                return new Pizza();
            case "hamburger":
                return new Hamburger();
            case "insalata":
                return new Insalata();
            default:
                Console.WriteLine("Piatto non presente nel menu");
                return null;
        }
    }
}

public interface IPrepStrategy
{
    public string Prepara(string descrizione);
}

public class Fritto : IPrepStrategy
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} fritto";
    }
}

public class AlForno : IPrepStrategy
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} al forno";
    }
}

public class AllaGriglia : IPrepStrategy
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} alla griglia";
    }
}

public class Chef
{
    public IPrepStrategy prepStrategy;

    public void ImpostaStrategy(IPrepStrategy p)
    {
        prepStrategy = p;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        return prepStrategy.Prepara(piatto.Descrizione());
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Benvenuto cosa vuoi mangiare pizza/hamburger/insalata ?");
        string tipo = Console.ReadLine();
        var piatto = PiattoFactory.Crea(tipo);

        if (piatto == null)
        {
            return;
        }

        bool controllo = true;
        do
        {
            Console.WriteLine("Cosa vuoi aggiungere 1.Formaggio\n2.Bacon\n3.Salsa\n0.Niente");
            int add = int.Parse(Console.ReadLine());
            switch (add)
            {
                case 1:
                    piatto = new ConFormaggio(piatto);
                    break;
                case 2:
                    piatto = new ConBacon(piatto);
                    break;
                case 3:
                    piatto = new ConSalsa(piatto);
                    break;
                case 0:
                    controllo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        } while (controllo);

        Chef chef = new Chef();

        Console.WriteLine("Scegli il metodo di cottura\n1.Fritto\n2.Forno\n3.Griglia");
        int scelta = int.Parse(Console.ReadLine());

        switch (scelta)
        {
            case 1:
                chef.ImpostaStrategy(new Fritto());
                break;
            case 2:
                chef.ImpostaStrategy(new AlForno());
                break;
            case 3:
                chef.ImpostaStrategy(new AllaGriglia());
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }

        Console.WriteLine("Lo chef ha preparato il tuo ordine: ");
        Console.WriteLine(chef.PreparaPiatto(piatto));
    }
}