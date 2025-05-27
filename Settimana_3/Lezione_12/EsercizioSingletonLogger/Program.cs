using System;

public sealed class Logger
{
    private static Logger _instance;

    private List<string> listaLog;
    private string _utente, _password;

    private Logger()
    {
        listaLog = new List<string>();
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void CreaUtEPsw(string utente, string password)
    {
        _utente = utente;
        _password = password;
    }
    public void Log(string message)
    {
        listaLog.Add(message);
    }

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
        Logger log1 = Logger.GetInstance();

        Console.WriteLine("Inserisci il nome utente:");
        string utente = Console.ReadLine();

        Console.WriteLine("Inserisci la password:");
        string password = Console.ReadLine();
        log1.CreaUtEPsw(utente, password);

        Console.WriteLine("Inserisci il messaggio del log1: ");
        log1.Log(Console.ReadLine());

        Logger log2 = Logger.GetInstance();
        Console.WriteLine("Inserisci messaggio del log2: ");
        log2.Log(Console.ReadLine());

        log1.MostraLog();
        log2.MostraLog();

        Console.WriteLine(log1 == log2);

    }

}
