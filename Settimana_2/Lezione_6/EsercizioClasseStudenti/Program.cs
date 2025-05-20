using System;

public class Studente
{
    // Definiamo le proprietà dello Studente 
    public string Nome;
    public int Matricola;
    public double MediaVoti;

    /// <summary>
    /// Costruttore che riceve e assegna le tre proprietà
    /// </summary>
    /// <param name="nome"></param>
    /// <param name="matricola"></param>
    /// <param name="mediaVoti"></param>
    public Studente(string nome, int matricola, double mediaVoti)
    {
        Nome = nome;
        Matricola = matricola;
        MediaVoti = mediaVoti;
    }
}

public class Program
{
    public static void Main()
    {
        // Definizione delll'array studente 
        Studente[] studenti = new Studente[2];

        //Ciclo che richiede nomi matricole e mediaVoti per inserire singolarmente ogni studente in un array di studenti
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Inserisci il nome dello studente: ");
            string? nome = Console.ReadLine();

            Console.WriteLine("Inserisci la matricola dello studente: ");
            int matricola = TryInputIntero();

            Console.WriteLine("Inserisci la media voti dello studente: ");
            double mediaVoti = TryInputDouble();

            studenti[i] = new Studente(nome, matricola, mediaVoti);

            StampaStudente(studenti[i], i);
        }

    }

    /// <summary>
    /// Stampa il numero dello studente nell'array con il suo nome matricola e media voti
    /// </summary>
    /// <param name="studente"></param>
    /// <param name="i"></param>
    public static void StampaStudente(Studente studente, int i)
    {
        Console.WriteLine($"Lo Studente{i + 1} si chiama {studente.Nome}, la sua matricola è {studente.Matricola} e la sua media voti è {studente.MediaVoti}");
    }

    /// <summary>
    /// Prende in input una stringa e la trasforma in numero intero altrimenti da errore
    /// </summary>
    /// <returns></returns>
    public static int TryInputIntero()
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

    /// <summary>
    /// Prende in input una stringa e la trasforma in double altrimenti da errore
    /// </summary>
    /// <returns></returns>
    public static double TryInputDouble()
    {
        bool controllo = false;
        double numero = 0;

        do
        {
            try
            {
                numero = double.Parse(Console.ReadLine());
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