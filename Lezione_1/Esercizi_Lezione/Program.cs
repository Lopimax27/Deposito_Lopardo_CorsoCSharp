using System;

class Program
{
    
    static void Main(string[] args){
        //PrimoEsercizio();
        //SecondoEsercizio();
        //TerzoEsercizio();
        //QuartoEsercizio();
        //QuintoEsercizio();
        //SestoEsercizio();
        //SettimoEsercizio();
        //OttavoEsercizio();
        //NonoEsercizio();
        //DecimoEsercizio();
        UndicesimoEsercizio();
    }
    static void PrimoEsercizio()
    {
        int numero1=3;
        int numero2=10;
        int somma=numero1+numero2;
        Console.WriteLine($"La somma e': {somma}");
    }

    static void SecondoEsercizio()
    {
        double prezzo=50;
        double sconto=0.2;
        double prezzo_scontato= prezzo-(prezzo*sconto);
        Console.WriteLine($"Il prezzo scontato e': {prezzo_scontato}");
    }

    static void TerzoEsercizio()
    {
        float numero1=10f;
        Console.WriteLine($"Il bool e': {numero1>0}");
    }

    static void QuartoEsercizio()
    {
        Console.Write("Inserisci un numero intero:");
        string numero1=Console.ReadLine();
        Console.WriteLine("Inserisci un numero float:");
        string numero2=Console.ReadLine();
        int n1=int.Parse(numero1);
        float n2=float.Parse(numero2);
        Console.WriteLine($"La somma e':{n1+n2}");
    }

    static void QuintoEsercizio()
    {
        Console.Write("Quanti anni hai?");
        string eta = Console.ReadLine();
        Console.Write("Quanto sei alto?");
        string altezza = Console.ReadLine();
        int eta1 = int.Parse(eta);
        float altezza1 = float.Parse(altezza);
        int altezza2 = (int)altezza1;
        Console.WriteLine($"La somma e': {eta1+altezza2}");
    }
    static void SestoEsercizio()
    {
        Console.WriteLine($"Inserisci la tua eta': ");
        string? eta=Console.ReadLine();
        int eta1=int.Parse(eta);
        const int maggiorenne=18;
        if (eta1>=maggiorenne)
        {
            Console.WriteLine("Sei maggiorenne");
        }
        if (eta1<maggiorenne)
        {
            Console.WriteLine("Sei minorenne");
        }
    }

    static void SettimoEsercizio()
    {
        Console.WriteLine("Quanto è il prezzo del prodotto ?");
        string? prezzo=Console.ReadLine();
        double prezzo1 = double.Parse(prezzo);
        const double sconto=0.1;
        const int prezzo_max=100;
        if (prezzo1>=prezzo_max)
        {
            prezzo1=prezzo1-prezzo1*sconto;
        }
        Console.WriteLine($"Il prezzo finale sarà: {prezzo1}");
    }
    static void OttavoEsercizio()
    {
        Console.WriteLine("Inserisci il primo numero: ");
        string? num1=Console.ReadLine();
        int intero1=int.Parse(num1);
        Console.WriteLine("Inserisci il secondo numero: ");
        string? num2=Console.ReadLine();
        int intero2=int.Parse(num2);
        Console.WriteLine("Inserisci il terzo numero: ");
        string? num3=Console.ReadLine();
        int intero3=int.Parse(num3);
        double media=(intero1+intero2+intero3)/3;
        if (media>=60)
        {
            Console.WriteLine("Hai superato la prova!");
        }
        if (media<60)
        {
            Console.WriteLine("Prova fallita");
        }

    }

    static void NonoEsercizio()
    {
        Console.Write("Inserisci un numero intero:");
        string? numero=Console.ReadLine();
        int intero=int.Parse(numero);
        if ((intero%2)==0)
        {
            Console.WriteLine("Il numero e' pari");
        }
        else
        {
            Console.WriteLine("Il numero e' dispari");
        }

    }

    static void DecimoEsercizio()
    {
        Console.Write("Inserisci la password per accedere: ");
        const int PASSWORD=12345;
        string? num1=Console.ReadLine();
        int password_utente= int.Parse(num1);
        if (password_utente==PASSWORD)
        {
            Console.WriteLine("Accesso consentito");
        }
        else
        {
            Console.WriteLine("Accesso negato");
        }
    }

    static void UndicesimoEsercizio()
    {
        Console.WriteLine("Inserisci il primo numero double: ");
        string? num1=Console.ReadLine();
        double numero1=double.Parse(num1);
        Console.WriteLine("Inserisci il secondo numero double: ");
        string? num2=Console.ReadLine();
        double numero2=double.Parse(num2);
        Console.WriteLine("Inserisci l'operatore somma o differenza: ");
        string? operatore=Console.ReadLine();
        if (operatore=="+")
        {
            Console.WriteLine($"Il risultato della somma e': {numero1+numero2}");
        }
        else if (operatore=="-")
        {
            Console.WriteLine($"Il risultato della differenza e': {numero1-numero2}");
        }
        else
        {
            Console.WriteLine("Operatore non valido!");
        }
    }


}
