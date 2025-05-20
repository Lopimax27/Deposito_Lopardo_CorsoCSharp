using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        /* Raddoppia
            int numero = 0;

            Console.Write("Inserisci un numero:");
            numero = int.Parse(Console.ReadLine());
            Console.WriteLine($"Il numero è {numero}");
            Raddoppia(ref numero);
            Console.WriteLine($"Il numero raddopiato è {numero} ");

            int giorno, mese, anno;*/

        /*  AggiornaData
            Console.WriteLine($"Inserisci il giorno: ");
            giorno = int.Parse(Console.ReadLine());
            Console.Write($"Inserisci il mese: ");
            mese = int.Parse(Console.ReadLine());
            Console.Write($"Inserisci l'anno: ");
            anno = int.Parse(Console.ReadLine());
            AggiornaData(ref giorno, ref mese, ref anno);
            Console.WriteLine($"Ecco la tua data aggiornata {giorno}/{mese}/{anno}");*/

        // DivisioneConResto
        double risultatoDivisione, risultatoResto;

        Console.Write("Inserisci il dividendo: ");
        double div = double.Parse(Console.ReadLine());
        Console.Write("Inserisci il divisore: ");
        double dis = double.Parse(Console.ReadLine());
        DivisioneConResto(div, dis, out risultatoDivisione, out risultatoResto);
        Console.WriteLine($"La divisione vale {risultatoDivisione} e il resto vale {risultatoResto}");

        //AnalizzaParola
        int numVocali, numConsonanti, numSpazi;
        Console.Write("Inserisci la stringa da analizzare: ");
        string? frase = Console.ReadLine();
        AnalizzaParola(frase, out numVocali, out numConsonanti, out numSpazi);
        Console.WriteLine($"Le vocali sono {numVocali}, le consonanti sono {numConsonanti}, gli spazi sono {numSpazi}");
        
    }

    private static void Raddoppia(ref int valore)
    {
        valore *= 2;
    }

    private static void AggiornaData(ref int g, ref int m, ref int a)
    {
        if (g > 30)
        {
            m++;
            g = 1;
        }
        if (m > 12)
        {
            a++;
            m = 1;
        }
    }

    private static void DivisioneConResto(double dividendo, double divisore, out double quoziente, out double resto)
    {
        quoziente = dividendo / divisore;
        resto = dividendo % divisore;
    }

    private static void AnalizzaParola(string stringa, out int nV, out int nC, out int nS)
    {
        nV = 0;
        nC = 0;
        nS = 0; 
        string vocali = "aeiou";

        foreach (char c in stringa)
        {
            if (vocali.Contains(c))
            {
                nV++;
            }
            else if (char.IsWhiteSpace(c))
            {
                nS++;
            }
            else if (char.IsLetter(c))
            {
                nC++;
            }
        }
    }
}