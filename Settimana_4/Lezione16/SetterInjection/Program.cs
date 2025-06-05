using System;

public class Program
{
    public static void Main(string[] args)
    {
        var stampante = new Printer();
        ILogger logger = new ConcreteLogger();

        Console.WriteLine("-----IMPOSTO LA STAMPANTE-----");
        stampante.log = logger;

        Console.WriteLine("Inserisci il messaggio da stampare:");
        string? messaggio = Console.ReadLine();

        stampante.Print(messaggio);


        var file = new FileUploader();

        Console.WriteLine("Dove vuoi salvare il file su disco(1) o simulato(2): ");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1:
                file.storage = new DiskStorage();
                break;
            case 2:
                file.storage = new SimulateStorage();
                break;
        }
        file.Salva();
    }
}