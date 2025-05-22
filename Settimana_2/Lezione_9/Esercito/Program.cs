using System;

public class Esercito
{
    private string _nome, _grado;
    private int _anniServizio;

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

    public override string ToString()
    {
        return $"Nome: {Nome} Grado: {Grado} Anni di Servizio: {AnniDiServizio}";
    }
}

public class Fante : Esercito
{
    private string _arma;
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

    public override string ToString()
    {
        return base.ToString() + $" Arma: {Arma}";
    }
}

public class Artigliere : Esercito
{
    private int _calibro;
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
            Console.WriteLine("1.Aggiungi un Fante\n2.Aggiungi un Artigliere\n2.Visualizza tutto l'esercito\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());
            //switch in base alla scelta definita esegue le funzioni scelte
            switch (scelta)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 4:
                    VisualizzaEsercito(schieramento);
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

    public static void VisualizzaEsercito(List<Esercito> schieramento)
    {
        int count = 0;
        foreach (Esercito v in schieramento)
        {
            Console.WriteLine($"[{count}] {v}");
            count++;
        }
    }
}
