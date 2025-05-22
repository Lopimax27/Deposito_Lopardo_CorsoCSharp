using System;

public class Esercito
{
    //Definizione attributi privati nome grado e anni di servizio
    private string _nome, _grado;
    private int _anniServizio;

    //proprietà publica per ottenere e impostare Nome
    public string Nome
    {
        get
        {
            return _nome;
        }
        set
        {
            _nome = value;
        }
    }

    //proprietà pubblica Grado per ottenere e impostare il grado
    public string Grado
    {
        get
        {
            return _grado;
        }
        set
        {
            _grado = value;
        }
    }
    //proprietà pubblica Anni di Servizio per ottenere e impostare gli anni svolti e controllare il valore sia valido o stampa messaggio di errore
    public int AnniDiServizio
    {
        get
        {
            return _anniServizio;
        }
        set
        {
            if (value > 0)
            {
                _anniServizio = value;
            }
            else
            {
                Console.WriteLine("Inserisci degli anni di servizio validi");
            }
        }
    }

    /// <summary>
    /// Override del to string
    /// </summary>
    /// <returns>Otteniamo la Descrizione del Soldato in questione</returns>
    public override string ToString()
    {
        return $"Nome: {Nome} Grado: {Grado} Anni di Servizio: {AnniDiServizio}";
    }
}

public class Fante : Esercito
{
    //Definizione del attributo privato arma
    private string _arma;
    //Definizione proprietà dell'arma per ottenere e impostare il valore
    public string Arma
    {
        get
        {
            return _arma;
        }
        set
        {   
            _arma = value;
        }
    }

    /// <summary>
    /// Override del toString della classe padre esercito per aggiungere una descrizione specifica
    /// </summary>
    /// <returns>descrizione + arma</returns>
    public override string ToString()
    {
        return base.ToString() + $" Arma: {Arma}";
    }
}

public class Artigliere : Esercito
{
    //definizione attributo privato calibro
    private int _calibro;
    //definizione della proprietà calibro che verifica sia un valore valido
    public int Calibro
    {
        get
        {
            return _calibro;
        }
        set
        {
            if (value > 0)
            {
                _calibro = value;
            }
            else
            {
                Console.WriteLine("Inserisci un calibro valido");
            }
        }
    }

    /// <summary>
    /// Override del ToString padre per ottenere la descrizione base e quella specifica della classe figlia
    /// </summary>
    /// <returns>Descrizione fondamentale + calibro</returns>
    public override string ToString()
    {
        return base.ToString() + $" Calibro: {Calibro}";
    }
}

public class Program
{
    public static void Main()
    {
        //Definizione lista vuota per contenere gli aerei
        List<Esercito> schieramento = new List<Esercito>();
        bool x = true; // definizione della variabile che controlla il do while imposta a true fino a che l'utente non sceglie exit

        Console.WriteLine("Benvenuto nel Menu");

        do
        {
            //Visualizzazione del Menu
            Console.WriteLine("1.Aggiungi un Fante\n2.Aggiungi un Artigliere\n3.Visualizza tutto l'esercito\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            //switch in base alla scelta definita esegue le funzioni scelte
            switch (scelta)
            {
                case 1:
                    schieramento.Add(InputSoldatoFante());//Richiama la funzione di input per il fante
                    break;
                case 2:
                    schieramento.Add(InputSoldatoArtiglieria());//Richiama la funzione di input per l'Artiglieria
                    break;
                case 3:
                    VisualizzaEsercito(schieramento);  //Richiama la funzione per visualizzare tutto l'esercito
                    break;
                case 0:
                    x = false;//imposta x a false per uscire dal menu
                    break;
                default:
                    Console.WriteLine("Scelta non valida");//Messaggio di errore per una scelta non valida
                    break;
            }
        }
        while (x);
    }

    /// <summary>
    /// Funzione visualizza che ricevuta la lista di esercito la scorre e stampa la descrizione di ogni singolo elemento
    /// con un contatore laterale
    /// </summary>
    /// <param name="schieramento"></param>
    public static void VisualizzaEsercito(List<Esercito> schieramento)
    {
        int count = 0;
        foreach (Esercito v in schieramento)
        {
            Console.WriteLine($"[{count}] {v}");
            count++;
        }
    }

    /// <summary>
    /// Funzione che prende i dati in input per creare il fante da aggiungere alla lista
    /// </summary>
    /// <returns>Il fante con tutti gli attributi settati</returns>
    public static Esercito InputSoldatoFante()
    {
        Fante s = new Fante();
        Console.WriteLine("Inserisci il nome : ");
        s.Nome = Console.ReadLine();

        Console.WriteLine("Inserisci il grado: ");
        s.Grado = Console.ReadLine();

        Console.WriteLine("Inserisci gli anni di servizio: ");
        s.AnniDiServizio = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci l'arma: ");
        s.Arma = Console.ReadLine();

        return s;
    }

    /// <summary>
    /// Funzione che prende i dati in input per creare l'artiglieria da aggiungere all'esercito
    /// </summary>
    /// <returns>l'artiglieria con gli attributi settati</returns>
    public static Esercito InputSoldatoArtiglieria()
    {
        Artigliere s = new Artigliere();
        Console.WriteLine("Inserisci il nome : ");
        s.Nome = Console.ReadLine();

        Console.WriteLine("Inserisci il grado: ");
        s.Grado = Console.ReadLine();

        Console.WriteLine("Inserisci gli anni di servizio: ");
        s.AnniDiServizio = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il calibro: ");
        s.Calibro = int.Parse(Console.ReadLine());

        return s;
    }
}
