using System;
using System.Diagnostics;
using System.Net.Mail;

public class Veicolo
{
    public int riparazioniFatte;
    private string _targa;
    public string Targa
    {
        get
        {
            return _targa;
        }
        set
        {
            _targa = value;
        }
    }

    public virtual void Ripara()
    {
        Console.WriteLine("Il veiocolo viene controllato");
    }
}

public class Auto : Veicolo
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo olio, freni e motore dell'auto.");
        riparazioniFatte++;
    }

}

public class Moto : Veicolo
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo catena, freni e gomme della moto.");
        riparazioniFatte++;
    }

    public void Ripara(string Targa)
    {
        Console.WriteLine("Riparazione della targa della moto");
        riparazioniFatte++;
    }

}

public class Camion : Veicolo
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo sospensioni, freni rinforzati e carico del camion.");
        riparazioniFatte++;
    }

    public void Ripara(string Targa)
    {
        Console.WriteLine("Riparazione della targa del camion");
        riparazioniFatte++;
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> officina = new List<Veicolo>();
        bool x = true;

        Console.WriteLine("Inserisci il tuo budget: ");
        int budget = int.Parse(Console.ReadLine());
        do
        {
            Console.WriteLine("1.Aggiungi un veicolo\n2.Ripara tutti i veicoli\n3.Ripara le targhe di camion e moto\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    officina.Add(InputVeicolo());
                    break;
                case 2:
                    Riparazione(officina, ref budget);
                    break;
                case 3:
                    RiparazioneTarga(officina, ref budget);
                    break;
                case 0:
                    x = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        } while (x);
    }

    public static Veicolo InputVeicolo()
    {
        Console.WriteLine("Inserisci la targa del veicolo: ");
        string targa = Console.ReadLine();

        Console.WriteLine("Stai portando in officina un auto, una moto o un camion (1,2,3)");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1:
                return new Auto { Targa = targa };
            case 2:
                return new Moto { Targa = targa };
            case 3:
                return new Camion { Targa = targa };
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        return null;
    }

    public static void Riparazione(List<Veicolo> gas,ref int budget)
    {
        if (budget <= 0)
        {
            Console.WriteLine("Budget terminato");
        }

        foreach (Veicolo v in gas)
        {
            if (v.riparazioniFatte <= 3)
            {
                Console.Write(v.Targa + " ");
                v.Ripara();
                budget--;
            }
            else
            {
                Console.WriteLine("Massimo di riparazioni raggiunte");
            }
        }
    }

    public static void RiparazioneTarga(List<Veicolo> gas, ref int budget)
    {
        if (budget <= 0)
        {
            Console.WriteLine("Budget terminato");
        }
        foreach (Veicolo v in gas)
        {
            if (v.riparazioniFatte > 3)
            {
                Console.WriteLine("Massimo di riparazioni raggiunte");
                return;
            }

            if (v is Camion)
            {
                Console.Write(v.Targa + " ");
                ((Camion)v).Ripara(v.Targa);
                budget--;
            }
            else if (v is Moto)
            {
                Console.Write(v.Targa + " ");
                ((Moto)v).Ripara(v.Targa);
                budget--;
            }

        }
    }
}