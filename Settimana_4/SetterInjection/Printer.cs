/// <summary>
/// Interfaccia Ilogger con metodo astratto Log
/// </summary>
public interface ILogger
{
    void Log(string messaggio);
}

/// <summary>
/// Implementa il log con un messaggio ricevuto in input e la stampa in corso
/// </summary>
public class ConcreteLogger : ILogger
{
    public void Log(string m)
    {
        Console.WriteLine("-----STAMPA IN CORSO-----");
        Console.WriteLine(m);
    }
}


/// <summary>
/// Classe che ha una proprietà ILogger con get e set e funzione print che verifica se log è stato settato Stampa messaggio di errore se non viene settato
/// altrimenti stampa su console il messaggio di print
/// </summary>
public class Printer
{
    public ILogger log { get; set; }

    public void Print(string messaggio)
    {
        if (log == null)
        {
            Console.WriteLine("Stampante non collegata");
            return;
        }

        log.Log(messaggio);
    }
}