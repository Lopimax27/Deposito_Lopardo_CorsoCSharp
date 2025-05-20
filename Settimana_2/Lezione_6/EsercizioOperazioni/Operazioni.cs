using System;

public class Operazioni
{
    public static void Main(string[] args)
    {

        Input();

    }

    /// <summary>
    /// Svolge l'operazione di Somma tra 2 numeri interi
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>Valore della somma</returns>
    public static int Somma(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// Svolge la Moltiplicazione fra due numeri interi
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>Valore della moltiplicazione</returns>
    public static int Moltiplica(int a, int b)
    {
        return a * b;
    }

    /// <summary>
    /// Svolge la divisione tra due interi con il controllo per la divisione per 0
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>valore divisione</returns>
    public static object Divisione(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"{ex.Message}");
            return "Non valido";
        }
    }

    /// <summary>
    /// Metodo che Stampa il risultato dell'operazione data
    /// </summary>
    /// <param name="operazione"></param>
    /// <param name="risultato"></param>
    public static void StampaRisultato(string operazione, object risultato)
    {
        Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
    }

    /// <summary>
    /// Funzione di input che riceve due interi e l'intero per la scelta con controllo interno, 
    /// inoltre richiama la funzione di stampa del risultato in base alla scelta fatta dall' operatore
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static void Input()
    {
        Console.WriteLine("Inserisci il primo numero: ");
        int a = TryInputNumero();

        Console.WriteLine("Inserisci il secondo numero: ");
        int b = TryInputNumero();

        Console.WriteLine("Inserisci l'operazione che vuoi svolgere (1(somma), 2(moltiplicazione), 3(divisione)): ");
        int scelta = TryInputNumero();

        if (scelta == 1)
        {
            StampaRisultato("Somma", Somma(a, b));
        }
        else if (scelta == 2)
        {
            StampaRisultato("Moltiplicazione", Moltiplica(a, b));
        }
        else if (scelta == 3)
        {
            StampaRisultato("Divisione", Divisione(a, b));
        }
    }

    /// <summary>
    /// Metodo che controlla se in input viene inserito un numero valido
    /// </summary>
    /// <returns>Il numero se il risultato è valido, altrimenti errore</returns>
    public static int TryInputNumero()
    {
        bool controllo = false;
        int numero = 0;

        do
        {
            try
            {
                numero = int.Parse(Console.ReadLine());
                controllo = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        } while (!controllo);

        return numero;
    }
}