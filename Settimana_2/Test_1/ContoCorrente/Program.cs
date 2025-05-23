using System;

public class ContoCorrente
{
    //Definizione di due campi private saldo e num operazioni
    private decimal _saldo;
    private int _numeroOperazioni;

    //Proprietà del saldo di sola lettura
    public decimal Saldo
    {
        get
        {
            return _saldo;
        }
    }

    //Proprietà del numero operazioni di sola lettura
    public int NumeroOperazioni
    {
        get
        {
            return _numeroOperazioni;
        }
    }

    /// <summary>
    /// Metodo versa che modifica il numero di operazioni e il saldo in base all'importo
    /// </summary>
    /// <param name="importo"></param>
    public void Versa(decimal importo)
    {
        _saldo += importo;
        _numeroOperazioni++;
    }

    /// <summary>
    /// Metodo preleva che modifica il numero di operazioni e il saldo in base all'importo da prelevare
    /// </summary>
    /// <param name="importo"></param>
    public void Preleva(decimal importo)
    {
        _saldo -= importo;
        _numeroOperazioni++;
    }

    /// <summary>
    /// Visualizza il saldo con il numero di operazioni
    /// </summary>
    public void VisualizzaSaldo()
    {
        Console.WriteLine($"Saldo disponibile:{Saldo} e numero di operazioni: {NumeroOperazioni}");
    }
}

public class Program
{
    public static void Main()
    {
        //creazione del conto corrente
        ContoCorrente mioConto = new ContoCorrente();
        bool x = true; // variabile booleana impostata a 3 che viene impostata a falso quando utente chiede di uscire
        do
        {
            //Visualizzazione del Menu
            Console.WriteLine("1.Preleva dal Conto\n2.Versa sul Conto\n3.Visualizza saldo\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    //Prelevare l'importo dato in input e richiama il metodo preleva
                    Console.WriteLine("Inserisci l'importo da prelevare: ");
                    decimal importo1 = decimal.Parse(Console.ReadLine());
                    mioConto.Preleva(importo1);
                    break;
                case 2:
                    //Versare l'importo ricevuto in input e richiama la funzione versa
                    Console.WriteLine("Inserisci l'importo da versare: ");
                    decimal importo2 = decimal.Parse(Console.ReadLine());
                    mioConto.Versa(importo2);
                    break;
                case 3:
                    //Visualizza il conto con le operazioni eseguite e il saldo
                    mioConto.VisualizzaSaldo();
                    break;
                case 0:
                    x = false;
                    break;
            }

        } while (x);
    }
}