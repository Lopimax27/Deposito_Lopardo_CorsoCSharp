using System;
using System.Dynamic;

public class Operatore
{
    //Def campi privati nome e turno
    private string _nome;
    private string _turno;

    //Proprietà nome con get e set di default
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
    //Proprietà Turno con get e set controllati
    public string Turno
    {
        get
        {
            return _turno;
        }
        set
        {
            //controllo se il valore di turno è valido se si lo setta
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")
            {
                _turno = value;
            }
            else
            {
                Console.WriteLine("Turno inserito non valido");
            }
        }
    }

    /// <summary>
    /// Metodo virtual che stampa messaggio generico per la classe base
    /// </summary>
    public virtual void EseguiCompito()
    {
        Console.WriteLine("Operatore generico in servizio");
    }

    /// <summary>
    /// Override del metodo toString della classe object 
    /// </summary>
    /// <returns>Descrizione nome e turno dell' operatore</returns>
    public override string ToString()
    {
        return $"Nome: {Nome}, Turno: {Turno}";
    }
}

public class OperatoreEmergenza : Operatore
{
    //campo privato livello di urgenza
    private int _lvDiUrgenza;

    // proprietà per accedere e impostare i vari livelli di urgenza con controllo
    public int LvDiUrgenza
    {
        get
        {
            return _lvDiUrgenza;
        }
        set
        {
            if (_lvDiUrgenza >= 1 && _lvDiUrgenza <= 5)
            {
                _lvDiUrgenza = value;
            }
            else
            {
                Console.WriteLine("Livello di urgenza non valido");
            }
        }
    }

    /// <summary>
    /// Compito specifico per op emergenza
    /// </summary>
    public override void EseguiCompito()
    {
        Console.WriteLine($"Gestione emergenza di livello {LvDiUrgenza}");
    }

    /// <summary>
    /// Override del To string che usa base e aggiunge il tipo
    /// </summary>
    /// <returns>Descrizione completa dell' operatore</returns>
    public override string ToString()
    {
        return base.ToString() + "Tipo: Emergenza";
    }
}

public class OperatoreSicurezza : Operatore
{
    //proprietà pubblica
    public string areaSorvegliata;

    /// <summary>
    /// Compito per operatore sicurezza
    /// </summary>
    public override void EseguiCompito()
    {
        Console.WriteLine($"Sorveglianza dell' area {areaSorvegliata}");
    }
    /// <summary>
    /// Override del tostring() per stampare anche il tipo
    /// </summary>
    /// <returns>Descrizione completa + il tipo di operatore</returns>
    public override string ToString()
    {
        return base.ToString() + "Tipo: Sicurezza";
    }
}

public class OperatoreLogistica : Operatore
{
    //campo privato numero di consegne
    private int _numeroConsegne;

    //Proprietà dei numeri di consegne con il get e il set controllato
    public int NumeroConsegne
    {
        get
        {
            return NumeroConsegne;
        }
        set
        {
            if (NumeroConsegne >= 0)
            {
                _numeroConsegne = value;
            }
        }
    }

    /// <summary>
    /// Compito specifico per operatori logistici
    /// </summary>
    public override void EseguiCompito()
    {
        Console.WriteLine($"Coordinamento di {NumeroConsegne} consegne");
    }

    /// <summary>
    /// override del toString() che sfrutta il base e aggiunge il tipo
    /// </summary>
    /// <returns>Descrizione completa con nome turno e tipo</returns>
    public override string ToString()
    {
        return base.ToString() + "Tipo: Logistica";
    }
}

public class Program
{
    public static void Main()
    {
        //generazione della lista operatori
        List<Operatore> operatori = new List<Operatore>();
        bool x = true;//variabile booleana true fino all'uscita richiesta dall'utente

        do
        {
            //Visualizzazione del Menu
            Console.WriteLine("1.Aggiungi un operatore\n2.Visualizza tutti gli operatori\n3.Esegui il compito di tutti gli operatori\n0.Uscire");
            int scelta = int.Parse(Console.ReadLine());//scelta per lo switch

            switch (scelta)
            {
                case 1:
                    operatori.Add(InputOperatore());//richiama in input i valori e li aggiunge agli operatori
                    break;
                case 2:
                    VisualizzaOperatori(operatori);//Visualizzazione di tutti gli operatori presenti nella lista
                    break;
                case 3:
                    MetodoOperatori(operatori);//Stampa del metodo di tutti gli operatori presenti nella lista
                    break;
                case 0:
                    x = false;//imposto x a false per uscire
                    break;
                default:
                    Console.WriteLine("Scelta non valida");//messaggio di default
                    break;
            }
        } while (x);
    }

    /// <summary>
    /// Funzione che prende in input il nome turno e a seconda del tipo anche il lv o l'area o il num di consegne
    /// </summary>
    /// <returns>L'operatore in base alla scelta fatta</returns>
    public static Operatore InputOperatore()
    {
        Console.WriteLine("Inserisci il nome del Operatore: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Inserisci il turno dell'Operatore (giorno/notte): ");
        string turno = Console.ReadLine();

        Console.WriteLine("L'operatore è uno di Emergenza,Sicurezza o Logistica (1,2,3)");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1://Emergenza
                OperatoreEmergenza op1 = new OperatoreEmergenza { Nome = nome, Turno = turno };
                Console.WriteLine("Inserisci il livello di urgenza: ");
                op1.LvDiUrgenza = int.Parse(Console.ReadLine());
                return op1;
            case 2://Sicurezza
                OperatoreSicurezza op2 = new OperatoreSicurezza { Nome = nome, Turno = turno };
                op2.areaSorvegliata = Console.ReadLine();
                return op2;
            case 3://Logistica
                OperatoreLogistica op3 = new OperatoreLogistica { Nome = nome, Turno = turno };
                op3.NumeroConsegne = int.Parse(Console.ReadLine());
                return op3;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        return null;
    }

    /// <summary>
    /// Visualizza tutti gli operatori presenti con un contatore
    /// </summary>
    /// <param name="op"></param>
    public static void VisualizzaOperatori(List<Operatore> op)
    {
        int count = 1;
        foreach (Operatore o in op)
        {
            Console.WriteLine($"{count}: {o}");
            count++;
        }
    }

    /// <summary>
    /// Richiamo e stampa tutti i metodi degli operatori della lista inserita
    /// </summary>
    /// <param name="op"></param>
    public static void MetodoOperatori(List<Operatore> op)
    {
        int count = 1;
        foreach (Operatore o in op)
        {
            Console.Write($"{count}: ");
            o.EseguiCompito();
        }
    }
}
