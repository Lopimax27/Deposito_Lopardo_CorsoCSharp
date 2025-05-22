using System;

public class ContoBancario
{
    //Campo privato NON ACCESSIBILE DIRETTAMENTE DALL'ESTERNO
    private double _saldo;

    //Proprietà per accedere al saldo in modo Controllato
    public double Saldo
    {
        get
        {
            return _saldo;       //permette la lettura del saldo
        }
        set
        {
            if (value >= 0)     //solo valori validi
            {
                _saldo = value;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        ContoBancario conto = new ContoBancario();

        conto.Saldo = 1000.50;              //imposta il saldo tramite la proprietà
        Console.WriteLine(conto.Saldo);     //legge il saldo tramite la proprietà restituisce 1000.50

        conto.Saldo = -500;                 //non modifica il saldo che è negativo
        Console.WriteLine(conto.Saldo);     // rimane 1000.50
    }
}