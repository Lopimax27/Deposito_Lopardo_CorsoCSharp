using System;

class Program
{
    public static string nome ;
    public static int numero, baseP, esponente;
    static void Main(string[] args)
    {
        Console.Write("Inserisci il tuo nome:");
        nome = Console.ReadLine();

        Console.WriteLine($"{StampaSaluto(nome)}");

        Console.Write("Inserisci un numero: ");
        numero = int.Parse(Console.ReadLine());
        VerificaPari(numero);

        Console.Write("Inserisci la base: ");
        baseP = int.Parse(Console.ReadLine());
        Console.WriteLine($"Inserisci l'esponente: ");
        esponente = int.Parse(Console.ReadLine());
        Console.WriteLine($"La potenza calcolata vale {CalcolaPotenza(baseP,esponente)}");
        
    }

    public static string StampaSaluto(string nomeUtente)
    {
        string Saluto = $"Ciao {nomeUtente}, forza napoli sempre! ";
        return Saluto;
    }

    private static bool VerificaPari(int num)
    {
        if (num % 2 == 0 || num == 0)
        {
            Console.WriteLine($"Il numero {num} è pari");
            return true;
        }
        else
        {
            Console.WriteLine($"Il numero {num} è dispari");
            return false;
        }
    }

    private static int CalcolaPotenza(int baseNum, int esponente)
    {
        int potenza = 1;
        for (int i = 0; i < esponente; i++)
        {
            potenza *= baseNum;
        }
        return potenza;
    }


}