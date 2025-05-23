using System;

public class Veicolo
{
    //Definizione dei campi riparazioni e targa privata
    public int riparazioniFatte;
    private string _targa;

    //proprietà della classe che prende e imposta la targa
    public string Targa
    {
        get
        {
            return _targa;
        }
        set
        {
            _targa = value;
        }
    }

    /// <summary>
    /// Messaggio di default della riparazione
    /// </summary>
    public virtual void Ripara()
    {
        Console.WriteLine("Il veiocolo viene controllato");
    }
}

public class Auto : Veicolo
{
    /// <summary>
    /// Override del metodo ripara, stampa il messaggio di riparazione e aggiorna le riparazioni eseguite
    /// </summary>
    public override void Ripara()
    {
        Console.WriteLine("Controllo olio, freni e motore dell'auto.");
        riparazioniFatte++;
    }

}

public class Moto : Veicolo
{
    /// <summary>
    /// Override del metodo ripara stampa il messaggio per le moto e aggiorna le riparazioni
    /// </summary>
    public override void Ripara()
    {
        Console.WriteLine("Controllo catena, freni e gomme della moto.");
        riparazioniFatte++;
    }

    /// <summary>
    /// Overload del metodo ripara per le moto stampa messaggio per riparare la targa e aggiorna le riparazioni
    /// </summary>
    /// <param name="Targa"></param>
    public void Ripara(string Targa)
    {
        Console.WriteLine("Riparazione della targa della moto");
        riparazioniFatte++;
    }

}

public class Camion : Veicolo
{

    /// <summary>
    /// Override metodo Ripara per il camion
    /// </summary>
    public override void Ripara()
    {
        Console.WriteLine("Controllo sospensioni, freni rinforzati e carico del camion.");
        riparazioniFatte++;
    }

    /// <summary>
    /// Overload del metodo ripara per il camion
    /// </summary>
    /// <param name="Targa"></param>
    public void Ripara(string Targa)
    {
        Console.WriteLine("Riparazione della targa del camion");
        riparazioniFatte++;
    }
}

public class Program
{
    public static void Main()
    {
        //Definizione e inzializzazione della lista di veicoli
        List<Veicolo> officina = new List<Veicolo>();
        bool x = true;//variabile booleana che rimane true fino alla richiesta di uscita dell'utente

        Console.WriteLine("Inserisci il tuo budget: ");
        int budget = int.Parse(Console.ReadLine());//budget iniziale impostato dall'utente
        do
        {
            //Menu
            Console.WriteLine("1.Aggiungi un veicolo\n2.Ripara tutti i veicoli\n3.Ripara le targhe di camion e moto\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    officina.Add(InputVeicolo());//Add alla lista il veicolo aggiunto
                    break;
                case 2:
                    Riparazione(officina, ref budget);//Esegue la riparazione su tutti i veicoli e riduce il budget
                    break;
                case 3:
                    RiparazioneTarga(officina, ref budget);//Ripara le targhe di tutte le moto e camion
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
    /// Funzione che prende in input la targa e a seconda della scelta nello switch
    /// </summary>
    /// <returns>Auto nel caso 1 e Moto nel caso 2 e Camion nel caso 3</returns>
    public static Veicolo InputVeicolo()
    {
        Console.WriteLine("Inserisci la targa del veicolo: ");
        string targa = Console.ReadLine();

        Console.WriteLine("Stai portando in officina un auto, una moto o un camion (1,2,3)");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1:
                return new Auto { Targa = targa };
            case 2:
                return new Moto { Targa = targa };
            case 3:
                return new Camion { Targa = targa };
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        return null;
    }

    /// <summary>
    /// Funzione riparazione che prende in input lista di veicolo e il ref del budget e esegue i controlli 
    /// e aggiorna i valori e effettua le riparazioni
    /// </summary>
    /// <param name="gas"></param>
    /// <param name="budget"></param>
    public static void Riparazione(List<Veicolo> gas, ref int budget)
    {
        if (budget <= 0)
        {
            Console.WriteLine("Budget terminato");
        }

        foreach (Veicolo v in gas)
        {
            if (v.riparazioniFatte <= 3)
            {
                Console.Write(v.Targa + " ");
                v.Ripara();
                budget--;
            }
            else
            {
                Console.WriteLine("Massimo di riparazioni raggiunte");
            }
        }
    }

    /// <summary>
    /// Riparazione della targa nei veicoli camion e moto della lista e aggiorna il budget e anche le riparazioni 
    /// </summary>
    /// <param name="gas"></param>
    /// <param name="budget"></param>
    public static void RiparazioneTarga(List<Veicolo> gas, ref int budget)
    {
        if (budget <= 0)
        {
            Console.WriteLine("Budget terminato");
        }
        foreach (Veicolo v in gas)
        {
            if (v.riparazioniFatte > 3)
            {
                Console.WriteLine("Massimo di riparazioni raggiunte");
                return;
            }

            if (v is Camion)
            {
                Console.Write(v.Targa + " ");
                ((Camion)v).Ripara(v.Targa);
                budget--;
            }
            else if (v is Moto)
            {
                Console.Write(v.Targa + " ");
                ((Moto)v).Ripara(v.Targa);
                budget--;
            }

        }
    }
}