using System;

class Program
{
    static void Main(string[] args)
    {
        // PrimoEsercizio();
        // SecondoEsercizio();
        // TerzoEsercizio();
        QuartoEsercizio();
        QuintoEsercizio();
        //SestoEsercizio();
        EsercizioExtra();
    }
    static void PrimoEsercizio()
    {
        Console.Write("Inserisci un numero intero: ");
        int numero = int.Parse(Console.ReadLine());
        if (numero%2 == 0)
        {
            Console.WriteLine("Il numero e' pari");
        }
        else
        {
            Console.WriteLine("Il numero e' dispari");
        }
    }
    
    static void SecondoEsercizio()
    {
        const int PASSWORD=1234;
        Console.Write("Inserisci la password per accedere: ");
        int numero=int.Parse(Console.ReadLine());
        if (numero==PASSWORD)
        {
            Console.WriteLine("Accesso consentito");
        }
        else 
        {
            Console.WriteLine("Accesso negato");
        }

    }

    static void TerzoEsercizio()
    {
        Console.Write("Inserisci il primo numero double: ");
        double numero1=double.Parse(Console.ReadLine());
        Console.Write("Inserisci il secondo numero double: ");
        double numero2=double.Parse(Console.ReadLine());
        Console.Write("Inserire l' operatore da utilizzare: ");
        string? operatore=Console.ReadLine();
        if (operatore=="+")
        {
            Console.WriteLine($"La somma e' {numero1+numero2}");
        }
        else if (operatore=="-")
        {
            Console.WriteLine($"La differenza e' {numero1-numero2}");
        }
        else
        {
            Console.WriteLine("Operatore non valido");
        }
    }

    static void QuartoEsercizio()
    {
        Console.Write("Inserisci il tuo voto da 1 a 10: ");
        int voto=int.Parse(Console.ReadLine());
        
        if( voto>=1 && voto<=4)
        {
            Console.WriteLine("Il tuo voto e' INSUFFICIENTE");
        } 
        else if( voto==5 || voto==6)
        {
            Console.WriteLine("Il tuo voto e' SUFFICIENTE");
        }
        else if( voto==7 || voto==8)
        {
            Console.WriteLine("Il tuo voto e' BUONO");
        }
        else if( voto==9 || voto==10)
        {
            Console.WriteLine("Il tuo voto e' OTTIMO");
        }
        else
        {
            Console.WriteLine("Il tuo voto non e' valido");
        }
    }

    static void QuintoEsercizio()
    {
        const double SOTTO=18.5;
        const double NORMO=25;
        const double SOVRA=30;
        double peso;
        double altezza;
        
        Console.Write("Inserisci la tua altezza in metri: ");
        altezza = double.Parse(Console.ReadLine());
        Console.Write("Inserisci il tuo peso in kg: ");
        peso = double.Parse(Console.ReadLine());
        
        double bmi = peso/(altezza*altezza);
        
        if (bmi<SOTTO && bmi>=0)
        {
            Console.WriteLine("Sei sottopeso!");
        }
        else if (bmi>=SOTTO && bmi<NORMO)
        {
            Console.WriteLine("Sei normopeso!");
        }
        else if (bmi>=NORMO && bmi<SOVRA)
        {
            Console.WriteLine("Sei sovrappeso!");
        }
        else if (bmi>=SOVRA)
        {
            Console.WriteLine("Sei obeso!");
        }
        else 
        {
            Console.WriteLine("Valori in altezza o peso negativi, quindi dati non validi!");
        }
    }    

    static void SestoEsercizio()
    {
        double celsius;
        double kelvin;
        double far;
        double rankine;

        const double CToK=273.15;
        const double CToF1=1.8;
        const int CToF2=32;
        const double CToR=491.67;

        Console.Write("Inserisci la temperatura in Celsius: ");
        celsius = double.Parse(Console.ReadLine());
        
        Console.Write("Inserisci l'unita' di misura in cui convertire la temperatura in simboli (F,K,R): ");
        string uma=Console.ReadLine();

        if (uma=="K")
        {
            kelvin = celsius + CToK ;
            Console.WriteLine($"La temperatura in Kelvin e' {kelvin} K");
        }
        else if (uma=="F")
        {
            far = celsius*CToF1+CToF2;
            Console.WriteLine($"La temperatura in Farenheit e' {far} F");
        }
        else if (uma=="R")
        {
            rankine = celsius*CToF1 + CToR;
            Console.WriteLine($"La temperatura in Rankine e' {rankine} R");
        }
        else
        {
            Console.WriteLine("Unita' di misura non valida");
        }
    }

    static void EsercizioExtra()
    {
        double temperatura;
        double celsius;
        double kelvin;
        double far;
        double rankine;

        const double CToK=273.15;
        const double CToF1=1.8;
        const int CToF2=32;
        const double CToR=491.67;

        Console.Write("Inserisci il valore della temperatura: ");
        temperatura = double.Parse(Console.ReadLine());
        
        Console.Write("Inserisci l'unita' di misura di partenza in simboli (F,K,R,C): ");
        string umaPar=Console.ReadLine();

        Console.Write("Inserisci l'unita' di misura in cui convertire la temperatura in simboli (F,K,R,C): ");
        string uma=Console.ReadLine();
        
        if (umaPar=="C")
        {   
            celsius=temperatura;
            if (uma=="K")
            {
                kelvin = celsius + CToK ;
                Console.WriteLine($"La temperatura in Kelvin e' {kelvin} K");
            }
            else if (uma=="F")
            {
                far = celsius*CToF1+CToF2;
                Console.WriteLine($"La temperatura in Farenheit e' {far} F");
            }
            else if (uma=="R")
            {
                rankine = celsius*CToF1 + CToR;
                Console.WriteLine($"La temperatura in Rankine e' {rankine} R");
            }
            else
            {
                Console.WriteLine("Unita' di misura non valida");
            }
        }
        if (umaPar=="K")
        {   
            kelvin=temperatura;
            celsius = kelvin - CToK ;
            if (uma=="C")
            {
                Console.WriteLine($"La temperatura in Celsius e' {celsius} C");
            }
            else if (uma=="F")
            {
                far = celsius*CToF1+CToF2;
                Console.WriteLine($"La temperatura in Farenheit e' {far} F");
            }
            else if (uma=="R")
            {
                rankine = celsius*CToF1 + CToR;
                Console.WriteLine($"La temperatura in Rankine e' {rankine} R");
            }
            else
            {
                Console.WriteLine("Unita' di misura non valida");
            }
        }
        if (umaPar=="F")
        {   
            far=temperatura;
            celsius=(far-CToF2)/CToF1;
            if (uma=="K")
            {
                kelvin = celsius + CToK ;
                Console.WriteLine($"La temperatura in Kelvin e' {kelvin} K");
            }
            else if (uma=="C")
            {
                Console.WriteLine($"La temperatura in Celsius e' {celsius} C");
            }
            else if (uma=="R")
            {
                rankine = celsius*CToF1 + CToR;
                Console.WriteLine($"La temperatura in Rankine e' {rankine} R");
            }
            else
            {
                Console.WriteLine("Unita' di misura non valida");
            }
        }
        if (umaPar=="R")
        {   
            rankine=temperatura;
            celsius=(rankine-CToR)/CToF1;
            if (uma=="K")
            {
                kelvin = celsius + CToK ;
                Console.WriteLine($"La temperatura in Kelvin e' {kelvin} K");
            }
            else if (uma=="F")
            {
                far = celsius*CToF1+CToF2;
                Console.WriteLine($"La temperatura in Farenheit e' {far} F");
            }
            else if (uma=="C")
            {
                Console.WriteLine($"La temperatura in Rankine e' {celsius} C");
            }
            else
            {
                Console.WriteLine("Unita' di misura non valida");
            }
        }
    }



}