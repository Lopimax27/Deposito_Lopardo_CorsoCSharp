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
    /// 
    /// </summary>
    /// <param name="chiave"></param>
    /// <param name="valore"></param>
    public void Imposta(string chiave, string valore)
    {
        if (chiave_valore.ContainsKey(chiave))
        {
            chiave_valore[chiave] = valore;
        }
        else
        {
            chiave_valore.Add(chiave, valore);
        }
    }

    public string Leggi(string chiave)
    {
        if (chiave_valore.ContainsKey(chiave))
        {
            return chiave;
        }
        else
        {
            Console.WriteLine("Chiave non trovata");
            return null;
        }
    }

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
    public void Config()
    {
        Console.WriteLine("Benvenuto nel Modulo A");
        bool x = true;
        do
        {

            Console.WriteLine("1.Inserisci chiave e valore da aggiungere alla configurazione\n2.Cerca e leggi un valore della chiave richiesto\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    InputKV();
                    break;
                case 2:
                    Console.WriteLine("Inserisci la chiave da cercare: ");
                    string chiave = Console.ReadLine();
                    ConfigurazioneSistema.Instance.Leggi(chiave);
                    break;
                case 0:
                    x = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (x);
    }

    protected void InputKV()
    {
        Console.WriteLine("Inserisci la chiave: ");
        string chiave = Console.ReadLine();

        Console.WriteLine("Inserisci il valore: ");
        string value = Console.ReadLine();

        ConfigurazioneSistema.Instance.Imposta(chiave, value);
    }
}
public class ModuloA : Modulo
{

}

public class ModuloB : Modulo
{

}

public class Program
{
    public static void Main()
    {
        ModuloA a = new ModuloA();
        ModuloB b = new ModuloB();

        a.Config();
        b.Config();

        ConfigurazioneSistema.Instance.StampaTutte();
    }

}