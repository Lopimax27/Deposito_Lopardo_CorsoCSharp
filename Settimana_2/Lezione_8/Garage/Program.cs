using System;


public class Veicolo
{
    //Definizione di marca e modello per tutti i veicoli
    public string marca, modello;

    public Veicolo(string ma, string mo)
    {
        marca = ma;
        modello = mo;
    }

    public virtual string StampaInfo()
    {
        return $"Il veicolo è della marca {marca} e il modello è {modello}";
    }
}

public class Auto : Veicolo
{
    public int numeroPorte;

    public Auto(string modello, string marca, int numero) : base(modello, marca)
    {
        numeroPorte = numero;
    }
    public override string StampaInfo()
    {
        return $"L'auto è della marca {marca}, del modello {modello} e ha {numeroPorte} porte";
    }
}

public class Moto : Veicolo
{
    public string tipoManubrio;

    public Moto(string modello, string marca, string tipoM) : base(modello, marca)
    {
        tipoManubrio = tipoM;
    }
    public override string StampaInfo()
    {
        return $"La moto è della marca {marca}, del modello {modello} e un manubrio di tipo {tipoManubrio}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> garage = new List<Veicolo>();
        bool controllore1 = true; //controllore resta true fino a che l'utente non richiede di uscire

        do
        {
            Console.WriteLine("Benvenuto nel tuo garage!\n1.Inserisci nuovo veicolo\n2.Visualizza tutti i veicoli nel garage\n3.Uscire dal garage");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Il veicolo che vuoi inserire è un auto? ");
                    string risposta = Console.ReadLine();
                    garage.Add(InputVeicolo(risposta));
                    break;
                case 2:
                    Console.WriteLine("Nel garage ci sono: ");
                    StampaGarage(garage);
                    break;
                case 3:
                    controllore1 = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida riprovare.");
                    break;
            }
        } while (controllore1);

        Console.WriteLine("Buona giornata alla prossima!");
    }

    public static Veicolo InputVeicolo(string risposta)
    {
        Console.WriteLine("Inserisci la marca del tuo veicolo");
        string marca = Console.ReadLine();
        Console.WriteLine("Inserisci il modello del veicolo");
        string modello = Console.ReadLine();

        if (risposta.ToLower() == "s")
        {
            Console.WriteLine("Inserisci il numero di porte del veicolo: ");
            int numeroPorte = int.Parse(Console.ReadLine());
            return new Auto(marca, modello, numeroPorte);
        }
        else
        {
            Console.WriteLine("Inserisci il tipo di manubrio: ");
            string manubrio = Console.ReadLine();
            return new Moto(marca, modello, manubrio);
        }
    }

    public static void StampaGarage(List<Veicolo> garage)
    {
        foreach (Veicolo v in garage)
        {
            Console.WriteLine(v.StampaInfo());
        }
    }
}
