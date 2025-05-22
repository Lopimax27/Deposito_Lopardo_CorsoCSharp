using System;

public class PrenotazioneViaggio
{
    public const int maxPosti = 20;
    private int _postiPrenotati, _postiDisponibili;
    private string _destinazione;

    public string Destinazione
    {
        get
        {
            return _destinazione;
        }
        set
        {
            _destinazione=value;
        }
    }
    public int PostiPrenotati
    {
        get
        {
            return _postiPrenotati;
        }
    }
    public int PostiDisponibili
    {
        get
        {
            return maxPosti - _postiPrenotati;
        }
    }
    public void PrenotaPosti(int numero)
    {
        if (numero <= PostiDisponibili)
        {
            _postiPrenotati += numero;
        }
    }

    public void AnnullaPrenotazione(int numero)
    {
        if (numero > 0 && numero<=PostiPrenotati)
        {
            _postiPrenotati -= numero;
        }
        else
        {
            Console.WriteLine("Numero inserito non valido");
        }
    }

    public PrenotazioneViaggio(int postiP, string dest)
    {
        _postiDisponibili = maxPosti;
        _postiPrenotati = postiP;
        _destinazione = dest;
    }
    
    public override string ToString()
    {
        return $"Destinazione: {Destinazione} Posti Prenotati:{PostiPrenotati} Posti Disponibili: {PostiDisponibili}";
    }
}

public class Program
{
    public static void Main()
    {
        PrenotazioneViaggio Viaggio1 = new PrenotazioneViaggio(0, "");

        Console.Write("Inserisci la destinazione del tuo viaggio: ");
        Viaggio1.Destinazione = Console.ReadLine();

        Console.Write("Inserisci quante persone vogliono prenotare il viaggio: ");
        int numP = int.Parse(Console.ReadLine());
        Viaggio1.PrenotaPosti(numP);

        Console.Write("Quante persone vogliono annullare la prenotazione: ");
        int numA = int.Parse(Console.ReadLine());
        Viaggio1.AnnullaPrenotazione(numA);

        Console.WriteLine(Viaggio1);
    }
}