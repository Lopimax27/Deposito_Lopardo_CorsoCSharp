using System;

public class Program
{
    public static void Main()
    {
        //definizione di array nomi e voti
        int[] voti = new int[5];
        string[] nomi = new string[5];

        //Ciclo che assegna un valore di nome e voto ad ogni iterazione ad ogni elemento degli array
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Inserisci il tuo nome: ");
            nomi[i] = Console.ReadLine();
            Console.Write($"Inserisici il voto di {nomi[i]}: ");
            voti[i] = int.Parse(Console.ReadLine());
        }

        //Ciclo per Stampare Nome:Voto
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{nomi[i]}:{voti[i]}");
        }

        //Stampa grazie ad Average, Max e Min stampa i valori con piccola descrizione
        Console.WriteLine($"La media vale {voti.Average()}, il valore max {voti.Max()}, il valore min {voti.Min()}");
    }

}