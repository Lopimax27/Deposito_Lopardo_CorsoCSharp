using System;

public class Persona
{
    public string Nome, Cognome;
    public int AnnoNascita;

    public Persona(string nome, string cognome, int annoDiNascita)
    {
        Nome = nome;
        Cognome = cognome;
        AnnoNascita = annoDiNascita;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Cognome: {Cognome}, Anno di Nascita: {AnnoNascita} ";
    }
}

public class Program
{
    public static void Main()
    {   
        //Ciclo che richiede l'inserimento di nome cognome anno e stampa tutto
        for (int i = 0; i < 2; i++)
        {
            Console.Write("Inserisci il nome: ");
            string nome = InputControllo();

            Console.Write("Inserisci il cognome: ");
            string cognome = InputControllo();

            Console.Write("Inserisci l'anno di nascita: ");
            int annoDiNascita = int.Parse(Console.ReadLine());

            if (i == 0)
            {
                Persona persona1 = new Persona(nome, cognome, annoDiNascita);
                Console.WriteLine(persona1);
            }
            else if (i == 1)
            {
                Persona persona2 = new Persona(nome, cognome, annoDiNascita);
                Console.WriteLine(persona2);
            }
        }
    }

    /// <summary>
    /// Controllo sulla stringa nulla
    /// </summary>
    /// <returns></returns>
    public static string InputControllo()
    {
        string parola = "";

        try
        {
            parola = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        return parola;
    }

    /// <summary>
    /// Controllo sul numero in input che non sia una stringa ma che sia convertibile in intero
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
}