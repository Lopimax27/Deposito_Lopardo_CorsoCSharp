using System;

public class VoloAereo
{
    private int _postiOccupati, _postiLiberi;
    private string _codiceVolo="";
    public const int MaxPosti = 150;

    public int PostiOccupati
    {
        get
        {
            return _postiOccupati;
        }
    }
    public int PostiLiberi
    {
        get
        {
            return MaxPosti - PostiOccupati;
        }
    }
    public string CodiceVolo
    {
        get
        {
            return _codiceVolo;
        }
        set
        {
            _codiceVolo = value;
        }
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti >= PostiLiberi && numeroPosti < 0)
        {
            Console.WriteLine("Numero posti non valido, o più alto dei posti disponibili");
        }
        else
        {
            _postiOccupati += numeroPosti;
        }
        
    }

    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= PostiOccupati && numeroPosti > 0)
        {
            Console.WriteLine("Non posso annullare così tante prenotazioni o numero negativo, riprovare");
            return;
        }
        _postiOccupati -= numeroPosti;
    }

    public override string ToString()
    {
        return $"Volo: {CodiceVolo} Posti Occupati:{PostiOccupati} Posti Liberi: {PostiLiberi}";
    }
}

public class Program
{
    public static void Main()
    {
        //Definizione lista vuota per contenere gli aerei
        List<VoloAereo> voliPresenti = new List<VoloAereo>();
        bool x = true; // definizione della variabile che controlla il do while imposta a true fino a che l'utente non sceglie exit

        Console.WriteLine("Benvenuto nel Menu");

        do
        {
            //Visualizzazione del Menu
            Console.WriteLine("1.Aggiungi un Volo\n2.Effettua una prenotazione\n3.Annulla una prenotazione\n4.Visualizza tutti i voli\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());
            //switch in base alla scelta definita esegue le funzioni scelte
            switch (scelta)
            {
                case 1:
                    VoloAereo v = new VoloAereo();
                    Console.Write("Inserisci il codice di volo con la destinazione: ");
                    v.CodiceVolo = Console.ReadLine();
                    voliPresenti.Add(v);
                    break;
                case 2:
                    SelezionaVolo(voliPresenti, 1);
                    break;
                case 3:
                    SelezionaVolo(voliPresenti, 2);
                    break;
                case 4:
                    StampaVoli(voliPresenti);
                    break;
                case 0:
                    x = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");//Messaggio di errore per una scelta non valida
                    break;
            }
        }
        while (x);
    }


    public static void SelezionaVolo(List<VoloAereo> voliPresenti, int daje)
    {
        StampaVoli(voliPresenti);
        Console.Write("Scegli il volo: ");
        int scelta = int.Parse(Console.ReadLine());
        if (scelta < 0 && scelta > voliPresenti.Count())
        {
            Console.WriteLine("Scelta non valida non esiste questo volo");
            return;
        }
        if (daje == 1)
        {
            Console.Write("Inserisci il numeri di posti da prenotare: ");
            int posti = int.Parse(Console.ReadLine());
            voliPresenti[scelta].EffettuaPrenotazione(posti);

        }
        else if (daje == 2)
        {
            Console.Write("Inserisci il numeri di prenotazioni da annullare: ");
            int posti = int.Parse(Console.ReadLine());
            voliPresenti[scelta].AnnullaPrenotazione(posti);
        }
    }
    

    public static void StampaVoli(List<VoloAereo> voliPresenti)
    {
        int count = 0;
        foreach (VoloAereo v in voliPresenti)
        {
            Console.WriteLine($"[{count}] {v}");
            count++;
        }
    }
}