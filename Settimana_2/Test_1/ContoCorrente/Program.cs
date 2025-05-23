using System;

public class ContoCorrente
{
    private decimal _saldo;
    private int _numeroOperazioni;

    public decimal Saldo
    {
        get
        {
            return _saldo;
        }
    }

    public int NumeroOperazioni
    {
        get
        {
            return _numeroOperazioni;
        }
    }

    public void Versa(decimal importo)
    {
        _saldo += importo;
        _numeroOperazioni++;
    }

    public void Preleva(decimal importo)
    {
        _saldo -= importo;
        _numeroOperazioni++;
    }

    public void VisualizzaSaldo()
    {
        Console.WriteLine($"Saldo disponibile:{Saldo} e numero di operazioni: {NumeroOperazioni}");
    }
}

public class Program
{
    public static void Main()
    {
        ContoCorrente mioConto = new ContoCorrente();
        bool x = true;
        do
        {
            Console.WriteLine("1.Preleva dal Conto\n2.Versa sul Conto\n3.Visualizza saldo\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci l'importo da prelevare: ");
                    decimal importo1 = decimal.Parse(Console.ReadLine());
                    mioConto.Preleva(importo1);
                    break;
                case 2:
                    Console.WriteLine("Inserisci l'importo da versare: ");
                    decimal importo2 = decimal.Parse(Console.ReadLine());
                    mioConto.Versa(importo2);
                    break;
                case 3:
                    mioConto.VisualizzaSaldo();
                    break;
                case 0:
                    x = false;
                    break;
            }

        } while (x);
    }
}