using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> lista = GeneraLista(100000);
        lista.Add("PIPPO");
        Ricerca(lista,"PIPPO");
    }

    public static List<string> GeneraLista(int numeroelementi)
    {
        List<string> lista = new List<string>();
        Random random = new Random();

        for (int i = 0; i < numeroelementi; i++)
        {
            // Genera una stringa random di lunghezza variabile (5-10 caratteri)
            int lunghezza = random.Next(5, 11);
            string stringaRandom = "";

            for (int j = 0; j < lunghezza; j++)
            {
                // Genera caratteri alfabetici casuali (A-Z)
                char carattere = (char)random.Next('A', 'Z' + 1);
                stringaRandom += carattere;
            }

            lista.Add(stringaRandom);
        }

        return lista;
    }

    public static void Ricerca(List<string> lista, string parola)
    {
        lista.Sort();
        int maxEl = lista.Count, minEl = 0;
        int count=0;
        bool ricerca=false;
        // foreach (string elemento in lista)
        // {
        //     Console.WriteLine(elemento);
        // }

        while (!ricerca)
        {
            int metEl = (maxEl + minEl) / 2;

            Console.WriteLine(count);
            Console.WriteLine(metEl);

            if (string.Compare(parola, lista[metEl]) == 0)
            {
                ricerca = true;
                Console.WriteLine($"Parola trovata nella posizione {metEl}");
            }
            if (string.Compare(parola, lista[metEl]) < 0)
            {
                maxEl = metEl - 1;
            }
            if (string.Compare(parola, lista[metEl]) > 0)
            {
                minEl = metEl + 1;
            }
            count++;
        }
    }
}

