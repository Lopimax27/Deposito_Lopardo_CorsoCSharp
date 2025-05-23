using System;

public class Veicolo
{
    public string marca, modello;
    public int annoImmatricolazione;

    public Veicolo(string ma, string mo, int a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
    }

    public virtual void StampaInfo()
    {
        Console.Write($"Marca: {marca} Modello: {modello} AnnoImmatricolazione:{annoImmatricolazione}");
    }
}

public class AutoAziendale : Veicolo
{
    public string targa;
    public bool usoPrivato;

    public AutoAziendale(string ma, string mo, int a, string ta, bool usP)
    : base(ma, mo, a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
        targa = ta;
        usoPrivato = usP;
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.Write($"Targa: {targa} UsoPrivato: {usoPrivato}");
    }
}

public class FurgoneAziendale : Veicolo
{
    public int capacitàCarico;

    public FurgoneAziendale(string ma, string mo, int a, int cC)
    : base(ma, mo, a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
        capacitàCarico = cC;
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.Write($"Capacità Carico: {capacitàCarico} kg ");
    }
}

public class Program
{
    public static void Main()
    {
        List<Veicolo> veicoliAzienda = new List<Veicolo>();
        bool x = true; // booleane che rimane true fino all'input dell'utente per uscire dal programma.

        do
        {
            Console.WriteLine("1.Aggiungi un auto al garage dell'azienda\n2.Aggiungi un furgone\n3.Visualizza i veicoli aziendali\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    veicoliAzienda.Add(InputVeicolo(1));
                    break;
                case 2:
                    veicoliAzienda.Add(InputVeicolo(2));
                    break;
                case 3:
                    VisualizzaGarage(veicoliAzienda);
                    break;
                case 0:
                    x = false;
                    break;
            }

        } while (x);

    }

    public static Veicolo InputVeicolo(int scelta)
    {
        Console.Write("Inserisci la marca del veicolo: ");
        string marca = Console.ReadLine();

        Console.Write("Inserisci il modello del veicolo: ");
        string modello = Console.ReadLine();

        Console.Write("Inserisci l'anno di immatricolazione: ");
        int anno = int.Parse(Console.ReadLine());
        bool privato;

        if (scelta == 1)
        {
            Console.WriteLine("Inserisci la targa: ");
            string targa = Console.ReadLine();
            Console.WriteLine("è per uso privato?");
            string uso = Console.ReadLine();
            if (uso == "s")
            {
                privato = true;
            }
            else
            {
                privato = false;
            }
            return new AutoAziendale(marca, modello, anno, targa, privato);
        }
        else if (scelta == 2)
        {
            Console.Write("Inserisci la capacità di carico: ");
            int carico = int.Parse(Console.ReadLine());
            return new FurgoneAziendale(marca, modello, anno, carico);
        }

        return null;
    }

    public static void VisualizzaGarage(List<Veicolo> veicoli)
    {
        foreach (Veicolo v in veicoli)
        {
            v.StampaInfo();
        }
    }
}
