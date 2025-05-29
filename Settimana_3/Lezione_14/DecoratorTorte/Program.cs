using System;

public interface ITorta
{
    string Descrizione();
}

public class TortaBase:ITorta
{
    public string Descrizione()
    {
        return "Torta base";
    }
}
public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato ";
    }
}
public class TortaVaniglia:ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia ";
    }
}
public class TortaFrutta:ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta ";
    }
}

public abstract class DecoratorTorte : ITorta
{
    protected ITorta baseTorta;

    protected DecoratorTorte(ITorta b)
    {
        baseTorta = b;
    }

    public virtual string Descrizione()
    {
        return baseTorta.Descrizione();
    }
}

public class ConPanna : DecoratorTorte
{
    public ConPanna(ITorta b) : base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ panna ";
    } 
}

public class ConFragole : DecoratorTorte
{
    public ConFragole(ITorta b) : base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ fragole ";
    }
}

public class ConGlassa : DecoratorTorte
{
    public ConGlassa(ITorta b) : base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "+ glassa";
    }
}

public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato":
                return new TortaCioccolato();
            case "vaniglia":
                return new TortaVaniglia();
            case "frutta":
                return new TortaFrutta();
            case "base":
                return new TortaBase();
            default:
                return null;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Inserisci la base torta vaniglia/cioccolato/frutta: ");
        string tipo = Console.ReadLine();
        var torta = TortaFactory.CreaTortaBase(tipo);
        if (torta == null)
        {
            torta = TortaFactory.CreaTortaBase("base");
        }

        bool controllo = true;
        do
        {
            Console.WriteLine("Cosa vuoi aggiungere panna,glassa,fragola o nulla: ");
            string aggiunta = Console.ReadLine();

            switch (aggiunta.ToLower())
            {
                case "panna":
                    torta = new ConPanna(torta);
                    break;
                case "glassa":
                    torta = new ConGlassa(torta);
                    break;
                case "fragole":
                    torta = new ConFragole(torta);
                    break;
                case "nulla":
                    controllo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        } while (controllo);

        Console.WriteLine(torta.Descrizione());
    }
}

