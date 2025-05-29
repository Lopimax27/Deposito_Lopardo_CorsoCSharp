using System;


public interface IBevanda
{
    string Descrizione();
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione()
    {
        return "La bevanda è un caffè ";
    }

    public double Costo()
    {
        return 1.20;
    }
}

public class Te : IBevanda
{ 
    public string Descrizione()
    {
        return "La bevanda è un caffè ";
    }

    public double Costo()
    {
        return 1.00;
    }
}

public abstract class DecoratorBevanda : IBevanda
{
    protected IBevanda _bevanda;

    protected DecoratorBevanda(IBevanda b)
    {
        _bevanda = b;
    }

    public virtual string Descrizione()
    {
        return _bevanda.Descrizione();
    }

    public virtual double Costo()
    {
        return _bevanda.Costo();
    }
}

public class ConLatte : DecoratorBevanda
{
    private const double _costoConLatte = 0.2;
    public ConLatte(IBevanda b): base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "con latte";
    }

    public override double Costo()
    {
        return base.Costo() + _costoConLatte;
    }
}

public class ConPanna : DecoratorBevanda
{
    private const double _costoConPanna = 0.3;
    public ConPanna(IBevanda b): base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "con panna";
    }

    public override double Costo()
    {
        return base.Costo() + _costoConPanna;
    }
}

public class ConCioccolato : DecoratorBevanda
{
    private const double _costoConCioccolato = 0.5;
    public ConCioccolato(IBevanda b): base(b)
    {

    }

    public override string Descrizione()
    {
        return base.Descrizione() + "con cioccolato";
    }

    public override double Costo()
    {
        return base.Costo() + _costoConCioccolato;
    }
}

public class Bar
{
    public static void Aperto()
    {

        Console.WriteLine("Benvenuto il bar è aperto");
        bool controllo = true;
        do
        {
            Console.WriteLine("1.Scegli la bevanda\n0.Esci dal bar");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Vuoi un caffè(1) o un te(2): ");
                    int bev = int.Parse(Console.ReadLine());
                    Aggiunta(SceltaBevanda(bev));
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

    public static IBevanda SceltaBevanda(int bev)
    {
        if (bev == 1)
        {
            return new Caffe();
        }
        else if (bev == 2)
        {
            return new Te();
        }
        return null;
    }

    public static void Aggiunta(IBevanda bevanda)
    {
        Console.WriteLine("Vuoi fare un aggiunta panna, latte o cioccolato o niente (1,2,3,0)");
        int scelta = int.Parse(Console.ReadLine());

        switch (scelta)
        {
            case 1:
                IBevanda conLatte = new ConLatte(bevanda);
                Console.WriteLine(conLatte.Descrizione());
                Console.WriteLine(conLatte.Costo());
                break;
            case 2:
                IBevanda conPanna = new ConPanna(bevanda);
                Console.WriteLine(conPanna.Descrizione());
                Console.WriteLine(conPanna.Costo());
                break;
            case 3:
                IBevanda conCioccolato = new ConCioccolato(bevanda);
                Console.WriteLine(conCioccolato.Descrizione());
                Console.WriteLine(conCioccolato.Costo());
                break;
            case 0:
                Console.WriteLine(bevanda.Descrizione());
                Console.WriteLine(bevanda.Costo());
                break;
            default:
                Console.WriteLine("Non posso aggiungerlo");
                break;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Bar.Aperto();
    }

}
