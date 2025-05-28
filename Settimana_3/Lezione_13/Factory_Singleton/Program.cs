using System;

/// <summary>
/// Singleton con una lista interna che registra i veicoli presenti
/// </summary>
public sealed class RegistroVeicolo
{
    //Creazione dell'istanza 
    private static RegistroVeicolo _instance;

    //Creazione dellalista di oggetti con interfaccia veicoli 
    private List<IVeicolo> veicoliCreati;

    /// <summary>
    /// Costruttore privato che genera la lista vuota di veicoli
    /// </summary>
    private RegistroVeicolo()
    {
        veicoliCreati = new List<IVeicolo>();
    }

    /// <summary>
    /// Proprietà che genera l'istanza del singleton solo se non è stata già generata
    /// </summary>
    public static RegistroVeicolo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RegistroVeicolo();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Metodo void che prende in input un veicolo che se non è vuoto lo inserisce nella lista del registroVeicolo
    /// </summary>
    /// <param name="veicolo"></param>
    public void Registra(IVeicolo veicolo)
    {
        if (veicolo != null)
        {
            veicoliCreati.Add(veicolo);
        }
        else
        {
            Console.WriteLine("Il veicolo non è valido o è vuoto");
        }
    }

    /// <summary>
    /// Metodo che stampa tutti i veicoli nella lista del singleton RegistraVeicoli
    /// </summary>
    public void StampaTutti()
    {
        int count = 0;
        foreach (IVeicolo v in veicoliCreati)
        {
            Console.WriteLine($"[{count}]");
            v.MostraTipo();
        }
    }
}

/// <summary>
/// Intefaccia IVeicolo con i 3 metodi void Avvia MostraTipo e AssegnaTarga
/// </summary>
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
    void AssegnaTarga(string targa);
}

/// <summary>
/// Classe concreta auto con i metodi del interfaccia implementati e la targa
/// </summary>
public class ConcreteAuto : IVeicolo
{
    //Campo privato targa
    private string _targa;

    /// <summary>
    /// Proprietà per leggere il valore di targa
    /// </summary>
    public string Targa
    {
        get
        {
            return _targa;
        }
    }
    /// <summary>
    /// Metodo assegna targa implementato che imposta la targa uguale alla stringa ricevuta in input
    /// </summary>
    /// <param name="t"></param>
    public void AssegnaTarga(string t)
    {
        _targa = t;
    }

    /// <summary>
    /// Metodo implementato Avvia che stampa un messaggio
    /// </summary>
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }

    /// <summary>
    /// Metodo che stampa la descrizione del veicolo con la targa e il tipo
    /// </summary>
    public void MostraTipo()
    {
        Console.WriteLine($"Targa: {Targa} Tipo: Auto");
    }
}

/// <summary>
/// Classe concreta moto con i metodi dell'interfaccia e la targa
/// </summary>
public class ConcreteMoto : IVeicolo
{
    private string _targa;

    public string Targa
    {
        get
        {
            return _targa;
        }
    }
    public void AssegnaTarga(string t)
    {
        _targa = t;
    }
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'Moto");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Targa: {Targa} Tipo: Moto");
    }
}

/// <summary>
/// Classe concreta Camion con i metodi dell'interfaccia e la targa
/// </summary>
public class ConcreteCamion : IVeicolo
{
    private string _targa;

    public string Targa
    {
        get
        {
            return _targa;
        }
    }
    public void AssegnaTarga(string t)
    {
        _targa = t;
    }
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'Camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Targa: {Targa} Tipo: Camion");
    }
}

/// <summary>
/// Classe creatore Veicolo Factory con metodo astratto CreaVeicolo e metodo concreto Genera
/// </summary>
public abstract class VeicoloFactory
{
    //Crea veicolo prende in input una stringa con il tipo
    public abstract IVeicolo CreaVeicolo(string tipo);

    /// <summary>
    /// Metodo che genera il veicolo prendendo in input il tipo, lo crea poi assegna la targa e poi se non è nullo lo inserisce nella lista dell'istanza 
    /// </summary>
    public void Genera()
    {
        string tipo = Console.ReadLine();
        IVeicolo veicolo = CreaVeicolo(tipo);

        Console.WriteLine("Inserisci la targa: ");
        string targa = Console.ReadLine();

        veicolo.AssegnaTarga(targa);

        if (veicolo != null)
        {
            RegistroVeicolo.Instance.Registra(veicolo);
        }
    }
}

/// <summary>
/// Creatore Concreto che in base allo switch crea il veicolo concreto
/// </summary>
public class ConcreteCreator : VeicoloFactory
{
    public override IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new ConcreteAuto();
            case "moto":
                return new ConcreteMoto();
            case "camion":
                return new ConcreteCamion();
            default:
                Console.WriteLine("Il veicolo che vuoi creare è di un tipo non supportato");
                return null;
        }
    }
}

public class Program
{
    public static void Main()
    {
        bool x = true;//variabile booleane che ti fa uscire dal ciclo do 
        do
        {
            //Visualizzazione Menu
            Console.WriteLine("1.Genera un veicolo a scelta\n2.Visualizza tutti i veicoli\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());//Scelta per lo switch

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci cosa vuoi inserire (auto,camion,moto)");//scelta
                    VeicoloFactory v = new ConcreteCreator();//creazione del creatore concreto
                    v.Genera();
                    break;
                case 2:
                    RegistroVeicolo.Instance.StampaTutti();//Richiama dell'istanza che stampa tutti gli elementi della lista
                    break;
                case 0:
                    x = false;//imposta bool a false per uscire
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (x);
    }

}