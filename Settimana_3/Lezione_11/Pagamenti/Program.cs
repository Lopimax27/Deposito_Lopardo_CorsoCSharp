using System;

//Creazione interfaccia pagamenti
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

//Classe per pagamento con carta
public class PagamentoCarta : IPagamento
{
    //campo privato circuito della carta
    private string _circuito;
    public string Circuito
    {
        get
        {
            return _circuito;
        }
        set
        {
            _circuito = value;
        }
    }

    /// <summary>
    /// Esegui pagamento personalizzato per la classe con carta
    /// </summary>
    /// <param name="importo"></param>
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta (Circuito: {Circuito})");
    }

    /// <summary>
    /// Stampa una descrizione del metodo dell'oggetto richiamato
    /// </summary>
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito");
    }
}

//Classe con pagamento in contanti
public class PagamentoContanti : IPagamento
{
    /// <summary>
    /// Pagamento personalizzato per i contanti
    /// </summary>
    /// <param name="importo"></param>
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti");
    }

    /// <summary>
    /// Stampa descrizione del metodo dell'oggetto richiamato 
    /// </summary>
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti");
    }
}

//Classe per pagamento con paypal
public class PagamentoPayPal : IPagamento
{
    //campo privato email utente che è accessibile grazie alla proprietà
    private string _emailUtente;

    public string EmailUtente
    {
        get
        {
            return _emailUtente;
        }
        set
        {
            value = _emailUtente;
        }
    }

    /// <summary>
    /// Metodo personalizzato per il pagamento con paypal che stampo quanto viene pagato e la mail
    /// </summary>
    /// <param name="importo"></param>
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite paypal da {EmailUtente}");
    }

    /// <summary>
    /// Stampa il metodo per il pagamento in paypal
    /// </summary>
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal");
    }
}

public class Program
{
    public static void Main()
    {
        List<IPagamento> pagamenti = new List<IPagamento>();

        bool x = true;//variabile booleana per controllare il menu

        do
        {
            //Visualizzazione Menu e richiesta di scelta
            Console.WriteLine("1.Aggiungi un metodo di pagamento\n2.Visualizza i metodi disponibili\n3.Effettua un pagamento\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            //Switch scelta 
            switch (scelta)
            {
                case 1:
                    InputPagamenti(ref pagamenti);
                    break;
                case 2:
                    Stampa(pagamenti);
                    break;
                case 3:
                    SelezionaPagamento(pagamenti);
                    break;
                case 0:
                    x = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida campione");
                    break;
            }
        } while (x);
    }

    /// <summary>
    /// Funzione di input dei pagamenti che chiede quale metodo vogliamo aggiungere e richiama le funzioni per creare il pagamento richiesto
    /// </summary>
    /// <param name="pagamenti"></param>
    public static void InputPagamenti(ref List<IPagamento> pagamenti)
    {
        Console.WriteLine("Inserisci il metodo di pagamento: (1 Carta, 2 Contanti, 3 Paypal)");
        int sceltaM = int.Parse(Console.ReadLine());//SCelta del metodo da inserire

        //Switch scelta 
        switch (sceltaM)
        {
            case 1:
                pagamenti.Add(PCa());//Pagamento con carta
                break;
            case 2:
                pagamenti.Add(PCo());//Pagamento con contanti
                break;
            case 3:
                pagamenti.Add(PyP());//Pagamento con paypal
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
    }
    /// <summary>
    /// Funzione che crea il pagamento con carta e chiede il circuito
    /// </summary>
    /// <returns>un nuovo pagamento con carta definito</returns>
    public static PagamentoCarta PCa()
    {
        PagamentoCarta pCa = new PagamentoCarta();

        Console.WriteLine("Inserisci il circuito della tua carta");
        pCa.Circuito = Console.ReadLine();

        return pCa;
    }

    /// <summary>
    /// Crea pagamento in contanti 
    /// </summary>
    /// <returns>nuovo ogetto pagamento in contanti</returns>
    public static PagamentoContanti PCo()
    {
        PagamentoContanti pCo = new PagamentoContanti();
        return pCo;
    }

    /// <summary>
    /// Crea il pagamento paypal e richiede la mail
    /// </summary>
    /// <returns>un nuovo oggetto pagamento con paypal definito </returns>
    public static PagamentoPayPal PyP()
    {
        PagamentoPayPal pyP = new PagamentoPayPal();

        Console.WriteLine("Inserisci la mail del tuo paypal");
        pyP.EmailUtente = Console.ReadLine();

        return pyP;
    }

    /// <summary>
    /// Stampai pagamenti disponibili
    /// </summary>
    /// <param name="pagamenti"></param>
    public static void Stampa(List<IPagamento> pagamenti)
    {
        int count = 0;
        foreach (IPagamento p in pagamenti)
        {
            Console.Write($"[{count}]");
            p.MostraMetodo();
            count++;
        }
    }

    /// <summary>
    /// Scegli
    /// </summary>
    /// <param name="pagamenti"></param>
    public static void SelezionaPagamento(List<IPagamento> pagamenti)
    {
        Stampa(pagamenti);

        Console.WriteLine("Inserisci il metodo da utilizzare");
        int scelta = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci l'importo");
        decimal importo = decimal.Parse(Console.ReadLine());

        pagamenti[scelta].EseguiPagamento(importo);
    }
}
