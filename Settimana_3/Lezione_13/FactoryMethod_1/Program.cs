using System;

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
        Console.WriteLine("Avvio dell'Moto");
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
        Console.WriteLine("Avvio dell'Camion");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

public abstract class VeicoloFactory
{
    public abstract IVeicolo CreaVeicolo(string tipo);

    public void Genera()
    {
        string tipo = Console.ReadLine();
        IVeicolo veicolo = CreaVeicolo(tipo);

        if (veicolo != null)
        {
            veicolo.Avvia();
            veicolo.MostraTipo();
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

public class MenuVeicolo
{
    List<object> veicolo = new List<object>();
    public void ScelteMenu()
    {
        bool x = true;//variabile booleane che ti fa uscire dal ciclo do 
        do
        {
            //Visualizzazione Menu
            Console.WriteLine("1.Genera un veicolo a scelta\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());//Scelta per lo switch

            switch (scelta)
            {
                case 1:
                    Input();
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
    private void Input()
    {
        Console.WriteLine("Insersci cosa vuoi inserire (auto,camion,moto)");
        VeicoloFactory v = new ConcreteCreator();
        v.Genera();
        veicolo.Add(v);
    }
}

public class Progrma
{
    public static void Main()
    {
        MenuVeicolo menu = new MenuVeicolo();

        menu.ScelteMenu();
    }
}