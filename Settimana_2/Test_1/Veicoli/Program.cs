using System;

public class Veicolo
{
    //Campi privati della classe base marca modello
    public string marca, modello;
    public int annoImmatricolazione;

    /// <summary>
    /// Costruttore Base predefinito
    /// </summary>
    /// <param name="ma"></param>
    /// <param name="mo"></param>
    /// <param name="a"></param>
    public Veicolo(string ma, string mo, int a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
    }

    /// <summary>
    /// Metodo Stampa info per stampare la descrizione del veicolo
    /// </summary>
    public virtual void StampaInfo()
    {
        Console.Write($"Marca: {marca} Modello: {modello} AnnoImmatricolazione:{annoImmatricolazione}");
    }
}

public class AutoAziendale : Veicolo
{
    //campi publici identificativi dell'autoaziendale
    public string targa;
    public bool usoPrivato;

    /// <summary>
    /// Costruttore personalizzato per auto aziendale
    /// </summary>
    /// <param name="ma"></param>
    /// <param name="mo"></param>
    /// <param name="a"></param>
    /// <param name="ta"></param>
    /// <param name="usP"></param>
    public AutoAziendale(string ma, string mo, int a, string ta, bool usP)
    : base(ma, mo, a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
        targa = ta;
        usoPrivato = usP;
    }

    /// <summary>
    /// Override dello stampainfo base per stampare anche targa e uso privato
    /// </summary>
    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Targa: {targa} UsoPrivato: {usoPrivato}");
    }
}

public class FurgoneAziendale : Veicolo
{
    //campo publico della capacità carico
    public int capacitàCarico;

    /// <summary>
    /// Costruttore personalizzato dei furgoni aziendali 
    /// </summary>
    /// <param name="ma"></param>
    /// <param name="mo"></param>
    /// <param name="a"></param>
    /// <param name="cC"></param>
    public FurgoneAziendale(string ma, string mo, int a, int cC)
    : base(ma, mo, a)
    {
        marca = ma;
        modello = mo;
        annoImmatricolazione = a;
        capacitàCarico = cC;
    }

    /// <summary>
    /// override dela Stampa con descrizione completa del furgone
    /// </summary>
    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Capacità Carico: {capacitàCarico} kg ");
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
            Console.WriteLine("\n1.Aggiungi un auto al garage dell'azienda\n2.Aggiungi un furgone\n3.Visualizza i veicoli aziendali\n0.Esci");
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

    /// <summary>
    /// Input Veicolo che si differenzia in base alla scelta e prende in input marca modello e anno per tutti, poi targa e uso per il caso
    /// auto aziendale e per il furgone
    /// </summary>
    /// <param name="scelta"></param>
    /// <returns></returns>
    public static Veicolo InputVeicolo(int scelta)
    {
        Console.Write("Inserisci la marca del veicolo: ");
        string marca = Console.ReadLine();

        Console.Write("Inserisci il modello del veicolo: ");
        string modello = Console.ReadLine();

        Console.Write("Inserisci l'anno di immatricolazione: ");
        int anno = int.Parse(Console.ReadLine());
        bool privato;

        if (scelta == 1)//Caso auto
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
        else if (scelta == 2)//Caso furgone
        {
            Console.Write("Inserisci la capacità di carico: ");
            int carico = int.Parse(Console.ReadLine());
            return new FurgoneAziendale(marca, modello, anno, carico);
        }

        return null;// null per non avere errori ma in realtà non necessario perchè la funzione non richiama mai delle scelte non possibili
    }

    /// <summary>
    /// Funzione Visualizza che stampa
    /// </summary>
    /// <param name="veicoli"></param>
    public static void VisualizzaGarage(List<Veicolo> veicoli)
    {
        foreach (Veicolo v in veicoli)
        {
            v.StampaInfo();
        }
    }
}
