using System;


public class Veicolo
{
    //Definizione di marca e modello per tutti i veicoli
    public string marca, modello;

    /// <summary>
    /// Costruttore della classe Veicolo
    /// </summary>
    /// <param name="ma"></param>
    /// <param name="mo"></param>
    public Veicolo(string ma, string mo)
    {
        marca = ma;
        modello = mo;
    }

    /// <summary>
    /// Metodo di stampa della descrizione
    /// </summary>
    /// <returns></returns>
    public virtual string StampaInfo()
    {
        return $"Il veicolo è della marca {marca} e il modello è {modello}";
    }
}

public class Auto : Veicolo
{
    public int numeroPorte;//proprietà unica della classe figlio auto

    /// <summary>
    /// Costruttore della classe Auto
    /// </summary>
    /// <param name="modello"></param>
    /// <param name="marca"></param>
    /// <param name="numero"></param>
    public Auto(string modello, string marca, int numero) : base(modello, marca)
    {
        numeroPorte = numero;
    }

    /// <summary>
    /// override della funzione base di stampa nella classe padre
    /// </summary>
    /// <returns></returns>
    public override string StampaInfo()
    {
        return $"L'auto è della marca {marca}, del modello {modello} e ha {numeroPorte} porte";
    }
}

public class Moto : Veicolo
{
    //definizione proprietà unica della classe moto
    public string tipoManubrio;

    /// <summary>
    /// Costruttore della classe Moto
    /// </summary>
    /// <param name="modello"></param>
    /// <param name="marca"></param>
    /// <param name="tipoM"></param>
    public Moto(string modello, string marca, string tipoM) : base(modello, marca)
    {
        tipoManubrio = tipoM;
    }

    /// <summary>
    /// Override stampaInfo per ottenere anche il tipo di manubrio
    /// </summary>
    /// <returns></returns>
    public override string StampaInfo()
    {
        return $"La moto è della marca {marca}, del modello {modello} e un manubrio di tipo {tipoManubrio}";
    }
}

public class Program
{
    public static void Main()
    {
        //Creazione del garage come lista di veicoli
        List<Veicolo> garage = new List<Veicolo>();
        bool controllore1 = true; //controllore resta true fino a che l'utente non richiede di uscire

        do
        {
            //Visualizzo il Menu e prendo in input una scelta
            Console.WriteLine("Benvenuto nel tuo garage!\n1.Inserisci nuovo veicolo\n2.Visualizza tutti i veicoli nel garage\n3.Uscire dal garage");
            int scelta = int.Parse(Console.ReadLine());
            
            //Switch dei casi con richiamo di funzioni in base alla scelta
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Il veicolo che vuoi inserire è un auto? ");//Richiesta per riconoscere il veicolo scelto
                    string risposta = Console.ReadLine(); 
                    garage.Add(InputVeicolo(risposta));// aggiungi il veicolo alla lista garage
                    break;
                case 2:
                    Console.WriteLine($"Nel garage ci sono: {garage.Count()}");
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

    /// <summary>
    /// Funzione che prende in input le proprietà dei veicoli
    /// </summary>
    /// <param name="risposta"></param>
    /// <returns>Il veicolo da poi agigungere nella lista</returns>
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

    /// <summary>
    /// Funzione di stampa di tutta la lista
    /// </summary>
    /// <param name="garage"></param>
    public static void StampaGarage(List<Veicolo> garage)
    {
        foreach (Veicolo v in garage)
        {
            Console.WriteLine(v.StampaInfo());
        }
    }
}
