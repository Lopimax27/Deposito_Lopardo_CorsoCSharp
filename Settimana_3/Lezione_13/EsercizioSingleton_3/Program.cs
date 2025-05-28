using System;

//Creazione classe Singleton COnfigurazioneSistema
public sealed class ConfigurazioneSistema
{
    //Creazione dell'istanza statica
    private static ConfigurazioneSistema _instance;
    //Creazione del Dizionario privato
    private Dictionary<string, string> chiave_valore;

    /// <summary>
    /// Costruttore private che crea un nuovo dizionario e lo imposta a chiave valore
    /// </summary>
    private ConfigurazioneSistema()
    {
        chiave_valore = new Dictionary<string, string>();
    }

    /// <summary>
    /// Proprietà per accedere all'istanza e crearne una se non presente
    /// </summary>
    public static ConfigurazioneSistema Instance
    {
        get
        {
            if (_instance == null)//Verifica se l'istanza sia nulla
            {
                _instance = new ConfigurazioneSistema();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Metodo che imposta i valori del dizionario se non sono già presenti altrimenti aggiorna il valore
    /// </summary>
    /// <param name="chiave"></param>
    /// <param name="valore"></param>
    public void Imposta(string chiave, string valore)
    {
        if (chiave_valore.ContainsKey(chiave))//Controlla che la chiave sia presente nel dizionario
        {
            chiave_valore[chiave] = valore;
        }
        else
        {
            chiave_valore.Add(chiave, valore);
        }
    }

    /// <summary>
    /// Metodo di lettura delle chiavi nella configurazione
    /// </summary>
    /// <param name="chiave"></param>
    /// <returns>il valore della chiave</returns>
    public string Leggi(string chiave)
    {
        if (chiave_valore.ContainsKey(chiave))//Controlla che la chiave sia presente nel dizionario
        {
            return chiave;
        }
        else
        {
            Console.WriteLine("Chiave non trovata");
            return null;
        }
    }

    /// <summary>
    /// Funzione stampa tutte le configurazione nel dizionario chiave e anche valore
    /// </summary>
    public void StampaTutte()
    {
        foreach (object s in chiave_valore)
        {
            Console.WriteLine(s);
        }
    }
}
public class Modulo
{
    /// <summary>
    /// Metodo config che ti porta nel menu per impostare, leggere l'istanza della configurazione di sistema
    /// </summary>
    public void Config()
    {
        Console.WriteLine("Benvenuto nel Modulo A");
        bool x = true;//variabile booleane che ti fa uscire dal ciclo do 
        do
        {
            //Visualizzazione Menu
            Console.WriteLine("1.Inserisci chiave e valore da aggiungere alla configurazione\n2.Cerca e leggi un valore della chiave richiesto\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());//Scelta per lo switch
            switch (scelta)
            {
                case 1:
                    InputKV();//Richiamo Funzione di input
                    break;
                case 2:
                    Console.WriteLine("Inserisci la chiave da cercare: "); // MEssaggio per ricevere la chiave
                    string chiave = Console.ReadLine(); //variabile chiave da mettere nella funzione leggi
                    ConfigurazioneSistema.Instance.Leggi(chiave);
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

    /// <summary>
    /// Funzione per prendere in input chiave e valore e le salve grazie ad imposta
    /// </summary>
    protected void InputKV()
    {
        Console.WriteLine("Inserisci la chiave: ");
        string chiave = Console.ReadLine();

        Console.WriteLine("Inserisci il valore: ");
        string value = Console.ReadLine();

        ConfigurazioneSistema.Instance.Imposta(chiave, value);
    }
}

//classe derivata moduloA
public class ModuloA : Modulo
{

}

//Classe derivata moduloB
public class ModuloB : Modulo
{

}


public class Program
{
    public static void Main()
    {
        //Variabili moduloA e moduloB
        ModuloA a = new ModuloA();
        ModuloB b = new ModuloB();

        //Richiamo funzioni config
        a.Config();
        b.Config();

        //Stampa tutte le configurazionnni
        ConfigurazioneSistema.Instance.StampaTutte();
    }

}