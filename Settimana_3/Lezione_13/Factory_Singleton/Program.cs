using System;

public sealed class RegistroVeicolo
{
    private static RegistroVeicolo _instance;

    private List<IVeicolo> veicoliCreati;

    private RegistroVeicolo()
    {
        veicoliCreati = new List<IVeicolo>();
    }

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
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
    void AssegnaTarga(string targa);
}

public class ConcreteAuto : IVeicolo
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
        Console.WriteLine("Avvio dell'auto");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Targa: {Targa} Tipo: Auto");
    }
}

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

public abstract class VeicoloFactory
{
    public abstract IVeicolo CreaVeicolo(string tipo);

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
                    Console.WriteLine("Inserisci cosa vuoi inserire (auto,camion,moto)");
                    VeicoloFactory v = new ConcreteCreator();
                    v.Genera();
                    break;
                case 2:
                    RegistroVeicolo.Instance.StampaTutti();
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