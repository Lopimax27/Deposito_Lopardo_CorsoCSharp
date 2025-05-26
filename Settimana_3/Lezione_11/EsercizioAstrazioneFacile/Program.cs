using System;

//Creazione classe astratta dispositivo elettronico con campo modello e metodi accendi spegni e mostra info
public abstract class DispositivoElettronico
{
    public string modello;

    public abstract void Accendi();
    public abstract void Spegni();

    public virtual void MostraInfo()
    {
        Console.WriteLine($"Modello: {modello}");
    }

}

//Creazione classe reale derivata da DispositivoElettronico
public class Computer : DispositivoElettronico
{
    public override void Accendi()
    {
        Console.WriteLine($"Il computer {modello} si avvia...");
    }
    public override void Spegni()
    {
        Console.WriteLine($"Il computer {modello} si spegne");
    }

    public Computer(string mod)
    {
        modello = mod;
    }
}

//Creazione classe reale derivata da DispositivoElettronico
public class Stampante : DispositivoElettronico
{
    public override void Accendi()
    {
        Console.WriteLine($"La stampante {modello} si accende...");
    }
    public override void Spegni()
    {
        Console.WriteLine($"La stampante {modello} va in stanby.");
    }
    public Stampante(string mod)
    {
        modello = mod;
    }
}

public class Program
{
    public static void Main()
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();

        bool x = true;//variabile booleana per controllare il menu

        do
        {
            //Visualizzazione Menu e richiesta di scelta
            Console.WriteLine("1.Aggiungi un dispositivo elettronico\n2.Visualizza i dispositivi\n3.Accendi i dispositivi\n4.Spegni i dispositivi\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            //Switch scelta 
            switch (scelta)
            {
                case 1:
                    dispositivi.Add(InputDispositivo());
                    break;
                case 2:
                    StampaD(dispositivi);
                    break;
                case 3:
                    AccendiD(dispositivi);
                    break;
                case 4:
                    SpegniD(dispositivi);
                    break;
                case 0:
                    x = false;
                    break;
            }
        } while (x);

        Console.WriteLine("Ciao Campione buon pranzo");
    }

    public static DispositivoElettronico InputDispositivo()
    {
        Console.WriteLine("Il dispositivo è un computer o una stampante(1/2)");
        int scelta = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il modello:");
        string modello = Console.ReadLine();

        if (scelta == 1)
        {
            return new Computer(modello);
        }
        else if (scelta == 2)
        {
            return new Stampante(modello);
        }
        else
        {
            Console.WriteLine("Scelta non valida!");
            return null;
        }
    }

    public static void AccendiD(List<DispositivoElettronico> dispo)
    {
        foreach (DispositivoElettronico d in dispo)
        {
            d.Accendi();
        }
    }

    public static void SpegniD(List<DispositivoElettronico> dispo)
    {
        foreach (DispositivoElettronico d in dispo)
        {
            d.Spegni();
        }
    }

    public static void StampaD(List<DispositivoElettronico> dispo)
    {
        foreach (DispositivoElettronico d in dispo)
        {
            d.MostraInfo();
        }
    }
}