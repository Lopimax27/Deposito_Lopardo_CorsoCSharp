using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // Tabellina();
        // Media();
        // Fattoriale();
        //ContaCaratteri();
        //RimuoviSpazi();
        // ContaVocali();
        // Password();
        // StringaModifier();
    }

    static void Tabellina()
    {
        int numero;
        Console.Write("Inserisci un numero da 1 a 10, per ottenerne la tabellina: ");
        numero = int.Parse(Console.ReadLine());
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine($"{numero}*{i}={numero * i}");
        }
    }

    static void Media()
    {
        int conto, numero, somma = 0;
        double media;
        Console.Write("Quanti numeri vuoi inserire? ");
        conto = int.Parse(Console.ReadLine());
        for (int i = 0; i < conto; i++)
        {
            Console.Write("Inserisci il numero: ");
            numero = int.Parse(Console.ReadLine());
            somma += numero;
        }
        media = (double)somma / conto;
        Console.WriteLine($"La media e' {media}");
    }

    static void Fattoriale()
    {
        int numero, fattoriale = 1;
        Console.Write("Inserisci un numero intero positivo: ");
        if (int.TryParse(Console.ReadLine(), out numero) && numero > 0)
        {
            for (int i = 1; i <= numero; i++)
            {
                fattoriale *= i;
            }
            Console.WriteLine($"Il fattoriale e' {fattoriale}");
        }
        else
        {
            Console.WriteLine("Errore input non valido!");
        }
    }

    static void ContaCaratteri()
    {
        int conteggio = 0;

        Console.Write("Inserisci una frase: ");
        string? frase = Console.ReadLine();

        foreach (char carattere in frase)
        {
            if (char.IsDigit(carattere))
            {
                conteggio++;
            }
        }

        Console.WriteLine($"Nella frase inserita ci sono {conteggio} caratteri numerici!");
    }

    static void RimuoviSpazi()
    {
        Console.WriteLine("Inserisci una frase: ");
        string? frase = Console.ReadLine();
        string fraseSenzaSpazi = "";
        foreach (char carattere in frase)
        {
            if (!char.IsWhiteSpace(carattere))
            {
                fraseSenzaSpazi += carattere;
            }
        }
        Console.WriteLine($"Ecco la tua nuova frase senza spaziature {fraseSenzaSpazi}");
    }

    static void ContaVocali()
    {
        int conteggio = 0;

        Console.Write("Inserisci una stringa: ");
        string? stringa = Console.ReadLine().ToLower();
        string vocali = "aeiou";

        foreach (char carattere in stringa)
        {
            if (vocali.Contains(carattere))
            {
                conteggio++;
            }
        }
        Console.WriteLine($"Le vocali sono {conteggio}");
    }

    static void Password()
    {
        bool sbagliata = true, controlloM = false, controlloD = false;
        do
        {
            Console.WriteLine("Inserisci una password valida: ");
            string? password = Console.ReadLine();
            if (password.Length <= 8 || password.StartsWith(" ") || password.EndsWith(" "))
            {
                Console.WriteLine("La password è piu corta di 8 caratteri, oppure inzia o finisce con uno spazio");
                continue;
            }

            foreach (char carattere in password)
            {
                if (char.IsUpper(carattere))
                {
                    controlloM = true;
                }
                else if (char.IsDigit(carattere))
                {
                    controlloD = true;
                }
            }
            if (controlloM && controlloD)
            {
                sbagliata = false;
            }
            else
            {
                Console.WriteLine("La password non e' valida");
            }
        } while (sbagliata);

        Console.WriteLine("La password e' valida.");
    }

    static void StringaModifier()
    {
        int contaParole = 0, lettere = 0, spazi = 0, punteggiatura = 0;

        Console.WriteLine("Inserisci una stringa: ");
        string? stringa = Console.ReadLine();

        foreach (char carattere in stringa)
        {
            if (char.IsLetter(carattere))
            {
                lettere++;
            }
            else if (char.IsWhiteSpace(carattere))
            {
                spazi++;
            }
            else if (char.IsPunctuation(carattere))
            {
                punteggiatura++;
            }
        }
        string[] parole = stringa.Split(' ');

        contaParole = parole.Length;

        Console.WriteLine($"La tua stringa ha {lettere} lettere, {spazi} spazi, {punteggiatura} punteggiature, {contaParole} parole");

    }

}