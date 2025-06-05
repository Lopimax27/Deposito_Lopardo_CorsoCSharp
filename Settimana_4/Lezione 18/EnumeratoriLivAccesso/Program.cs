using System;

public enum LivelloAccesso
{
    Ospite,
    Utente,
    Amministratore
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Inserisci il tuo livello di Accesso");
        int lv = int.Parse(Console.ReadLine());
        StampaPrivilegi(lv);
    }

    public static void StampaPrivilegi(int  lv)
    {
        switch (lv)
        {
            case (int)LivelloAccesso.Ospite:
                Console.WriteLine("Sei ospite ma non hai accesso a niente.");
                break;
            case (int)LivelloAccesso.Utente:
                Console.WriteLine("Ciao sei un utente puoi modificare qualcosa ma non tutti");
                break;
            case (int)LivelloAccesso.Amministratore:
                Console.WriteLine("Ciao sei il top amministratore napoletano puoi fare tutto capo");
                break;
        }
    }
}