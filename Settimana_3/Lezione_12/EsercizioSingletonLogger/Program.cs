using System;

//Creazione del singleton Logger
public sealed class Logger
{
    //Creazione dell'istanza
    private static Logger _instance;

    //Campi del logger utente password e lista dei messaggi dell'utente
    private List<string> listaLog;
    private string _utente, _password;

    //Costruttore che inizializza la lista vuota
    private Logger()
    {
        listaLog = new List<string>();
    }

    /// <summary>
    /// Metodo logger che controlla se l'instanza è nulla nel caso la crea 
    /// </summary>
    /// <returns>e la ritorna</returns>
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    /// <summary>
    /// Metodo void per creare e impostare la password e il nome utente che non sono leggibili dall'esterno e neanche impostabili se non attraverso questo metodo
    /// </summary>
    /// <param name="utente"></param>
    /// <param name="password"></param>
    public void CreaUtEPsw(string utente, string password)
    {
        _utente = utente;
        _password = password;
    }
    /// <summary>
    /// Metodo che aggiunge alla lista il messaggio dato dall'utente e lo salva
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
        listaLog.Add(message);
    }

    /// <summary>
    /// Metodo void che stampa tutti gli elementi della lista
    /// </summary>
    public void MostraLog()
    {
        foreach (string m in listaLog)
        {
            Console.Write("-");
            Console.WriteLine(m);
        }
    }
}

public class Program
{
    public static void Main()
    {
        //Primo richiamo di get instance viene creato il primo logger
        Logger log1 = Logger.GetInstance();

        //imposto l'utente e la password
        Console.WriteLine("Inserisci il nome utente:");
        string utente = Console.ReadLine();

        Console.WriteLine("Inserisci la password:");
        string password = Console.ReadLine();
        log1.CreaUtEPsw(utente, password);

        //Prende in input i due messaggi
        Console.WriteLine("Inserisci il messaggio del log1: ");
        log1.Log(Console.ReadLine());

        Logger log2 = Logger.GetInstance();
        Console.WriteLine("Inserisci messaggio del log2: ");
        log2.Log(Console.ReadLine());

        //Utilizza mostralog sulle due variabili per verificare che in realtà sono la stessa cosa e hanno la stessa lista
        log1.MostraLog();
        log2.MostraLog();

        //Esegue il controllo booleano
        Console.WriteLine(log1 == log2);

    }

}
