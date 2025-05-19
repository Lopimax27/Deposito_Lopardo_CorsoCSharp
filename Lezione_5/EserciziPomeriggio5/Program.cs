using System;

class Program
{
    public static bool riuscito1, riuscito2;
    static void Main(string[] args)
    {
        // EsercizioSomma();
        // EsercizioAnalizza();
        EsercizioTry1();
        EsercizioDivisione();
        Inserisci5Numeri();
    }

    static void EsercizioSomma()
    {
        int num1 = 10, num2 = 3, num3 = 10;
        double num4 = 2.7, num5 = 7.2;

        Console.WriteLine(Somma(num1, num2));
        Console.WriteLine(Somma(num1, num2, num3));
        Console.WriteLine(Somma(num4, num5));
    }

    static void EsercizioAnalizza()
    {
        Console.Write("Inserisci il testo:");
        string? testo = Console.ReadLine();
        Console.WriteLine($"Il testo contiene {Analizza(testo)} caratteri");

        Console.Write("Inserisci un carattere");
        char carattere = char.Parse(Console.ReadLine());
        Console.WriteLine($"Il testo contiene {Analizza(testo, carattere)} {carattere}");

        Console.Write("Vuoi contare le vocali ? (Scrivi s per Si e qualsiasi altro carattere per No )");
        char risposta = char.Parse(Console.ReadLine());
        bool contaVocali = risposta == 's' ? true : false;
        string si = contaVocali ? "vocali" : "consonanti";
        Console.WriteLine($"Il testo contiene {Analizza(testo, contaVocali)} {si}");
    }

    static void EsercizioTry1()
    {
        int num1 = 0, num2 = 0;
        Console.WriteLine("Inserisci il primo numero");
        TryCatchNumeri(ref num1,out riuscito1);
        Console.WriteLine("Inserisci il secondo numero: ");
        TryCatchNumeri(ref num2,out riuscito2);
    }

    static void EsercizioDivisione()
    {
        int num1 = 0, num2 = 0;
        Console.WriteLine("Inserisci il primo numero");
        TryCatchNumeri(ref num1, out riuscito1);
        Console.WriteLine("Inserisci il secondo numero: ");
        TryCatchNumeri(ref num2, out riuscito2);
        DivisionePerZero(num1, num2, riuscito1, riuscito2);
    }

    static double Somma(double a, double b)
    {
        double somma = a + b;
        return somma;
    }
    static int Somma(int a, int b, int c = 0)
    {
        int somma = a + b + c;
        return somma;
    }

    static int Analizza(string testo)
    {
        int count = 0;
        foreach (char c in testo)
        {
            if (!char.IsWhiteSpace(c))
            {
                count++;
            }
        }
        return count;
    }

    static int Analizza(string testo, char carattere)
    {
        int count = 0;
        foreach (char c in testo)
        {
            if (c == carattere)
            {
                count++;
            }
        }
        return count;
    }

    static int Analizza(string testo, bool contaVocali)
    {
        int countV = 0, countC = 0;
        string vocali = "aeiou";

        foreach (char c in testo.ToLower())
        {
            if (vocali.Contains(c))
            {
                countV++;
            }
            else if (char.IsLetter(c))
            {
                countC++;
            }
        }

        if (contaVocali)
        {
            return countV;
        }
        else
        {
            return countC;
        }
    }

    static void TryCatchNumeri(ref int num1,out bool riuscito)
    {
        riuscito=true;
        try
        {
            num1 = int.Parse(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            riuscito = false;
        }
    }

    static void DivisionePerZero(int num1, int num2,bool riuscito1, bool riuscito2)
    {
        try
        {
            int divisione = num1 / num2;
            Console.WriteLine($"La divisione vale {divisione}");
        }
        catch (DivideByZeroException ex)
        {
            if (riuscito1 && riuscito2)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void Inserisci5Numeri()
    {
        int num1 = 0,somma=0;
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Inserisci il primo numero: ");
            TryCatchNumeri(ref num1, out riuscito1);
            somma += num1;
        }
        Console.WriteLine($"La somma dei numeri è {somma}");
    }
}