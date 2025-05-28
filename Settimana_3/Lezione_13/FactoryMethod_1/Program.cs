using System;
using System.Collections.Generic;

public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

public class ConcreteAuto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

public class ConcreteMoto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio della moto");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

public class ConcreteCamion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio del camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

public static class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
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

    public static void Genera()
    {
        Console.WriteLine("Inserisci il tipo di veicolo da creare (auto, camion, moto):");
        string tipo = Console.ReadLine();
        IVeicolo veicolo = CreaVeicolo(tipo);

        if (veicolo != null)
        {
            veicolo.Avvia();
            veicolo.MostraTipo();
        }
    }
}

public class MenuVeicolo
{
    List<IVeicolo> veicoli = new List<IVeicolo>();

    public void ScelteMenu()
    {
        bool attivo = true;
        do
        {
            Console.WriteLine("1. Genera un veicolo a scelta\n0. Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Input();
                    break;
                case 0:
                    attivo = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (attivo);
    }

    private void Input()
    {
        VeicoloFactory.Genera();
    }
}

public class Program
{
    public static void Main()
    {
        MenuVeicolo menu = new MenuVeicolo();
        menu.ScelteMenu();
    }
}
