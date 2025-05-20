using System;
using System.ComponentModel;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        // Settimana();
        // CalcoloArea();
        //NumeriInteri();
        //NumeroSegreto();
        //Bancomat();
        // Password();
        // Numeri0();
        Calcolatrice();
    }

    static void Settimana()
    {
        Console.Write("Inserisci un numero e ti diro' che giorno e' (da 1 a 7): ");
        int giorno = int.Parse(Console.ReadLine());

        switch (giorno)
        {
            case 1:
                Console.WriteLine("Oggi e' lunedi'!");
                break;
            case 2:
                Console.WriteLine("Oggi e' martedi'!");
                break;
            case 3:
                Console.WriteLine("Oggi e' mercoledi'!");
                break;
            case 4:
                Console.WriteLine("Oggi e' giovedi'!");
                break;
            case 5:
                Console.WriteLine("Oggi e' venerdi'!");
                break;
            case 6:
                Console.WriteLine("Oggi e' sabato!");
                break;
            case 7:
                Console.WriteLine("Oggi e' domenica!");
                break;
            default:
                Console.WriteLine("Non conosco questo giorno!");
                break;
        }
    }

    static void CalcoloArea()
    {

        double latoQ;
        double altezzaT;
        double baseT;
        double raggioC;
        const double PI = 3.14;

        Console.Write("Inserisci la figura di cui vuoi calcolare l'area tra quadrato,triangolo e cerchio (q,t,c): ");
        string? figura = Console.ReadLine();

        switch (figura)
        {
            case "q":
                Console.Write("Inserisci la lunghezza del lato del quadrato: ");
                latoQ = double.Parse(Console.ReadLine());

                Console.WriteLine($"L'area del quadrato e'{latoQ * latoQ}m");
                break;
            case "t":
                Console.Write("Inserisci la base del triangolo: ");
                baseT = double.Parse(Console.ReadLine());

                Console.Write("Inserisci l'altezza del triangolo: ");
                altezzaT = double.Parse(Console.ReadLine());

                Console.WriteLine($"L'area del triangolo e' {(baseT * altezzaT) / 2}m");
                break;
            case "c":
                Console.Write("Inserisci il raggio del cerchio: ");
                raggioC = double.Parse(Console.ReadLine());

                Console.WriteLine($"L'area del cerchio e' {PI * raggioC * raggioC}m");
                break;
            default:
                Console.WriteLine("Non conosco questa figura");
                break;
        }
    }

    static void NumeriInteri()
    {
        int numero, somma = 0;

        while (true)
        {
            Console.Write("Inserisci un numero intero positivo: ");
            numero = int.Parse(Console.ReadLine());

            if (numero >= 0)
            {
                somma += numero;
            }
            else
            {
                Console.WriteLine($"La somma vale {somma}");
                break;
            }
        }
    }

    static void NumeroSegreto()
    {
        const int NumeroSegreto = 50;
        int numero;
        bool indovino = false;

        while (!indovino)
        {
            Console.Write("Indovina il numero: ");
            if (int.TryParse(Console.ReadLine(), out numero))
            {

            }
            else
            {
                Console.WriteLine("Dato non valido. Riprovare!");
                continue;
            }

            if (numero > NumeroSegreto)
            {
                Console.WriteLine("Hai sbagliato il Numero Segreto e' piu' piccolo di questo. Riprova");
            }
            else if (numero < NumeroSegreto)
            {
                Console.WriteLine("Hai sbagliato il Numero Segreto e' piu' grande di questo. Riprova");
            }
            else if (numero == NumeroSegreto)
            {
                indovino = true;
                Console.WriteLine("Hai indovinato!!");
            }
        }

    }

    static void Bancomat()
    {
        int scelta;
        double saldo = 0, deposito, prelievo;
        bool esci = true;
        while (esci)
        {
            Console.WriteLine("\nBenvenuto nel bancomat, scegli cosa vuoi fare\n1: Visualizzare il Saldo\n2: Depositare denaro\n3: Prelevare denaro\n4: Esci");
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine($"Il tuo saldo e' di {saldo}");
                    break;
                case 2:
                    Console.Write("Quanto vuoi depositare ? ");
                    deposito = double.Parse(Console.ReadLine());

                    if (deposito > 0)
                    {
                        saldo += deposito;
                        Console.WriteLine($"Hai depositato {deposito}\nIl tuo saldo ora e' di {saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Valore non valido");
                    }
                    break;
                case 3:
                    Console.Write("Quanto vuoi prelevare? ");
                    prelievo = double.Parse(Console.ReadLine());

                    if (prelievo <= saldo)
                    {
                        saldo -= prelievo;
                        Console.WriteLine($"Hai prelevato {prelievo}\nIl tuo saldo ora e' di {saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Non puoi prelevare questa cifra, riprovare");
                    }
                    break;
                case 4:
                    Console.WriteLine("Arrivederci!");
                    esci = false;
                    break;
            }

        }

    }

    static void Password()
    {
        const int PASSWORD = 1234;
        int pass, tentativi = 0;

        do
        {
            Console.WriteLine("Inserisci la password numerica: ");

            if (int.TryParse(Console.ReadLine(), out pass))
            {

                if (pass == PASSWORD)
                {
                    Console.WriteLine("Password Corretta");
                    break;
                }

                else
                {
                    Console.WriteLine("La password non e' corretta. Riprovare!");
                }
            }

            else
            {
                Console.WriteLine("La password presenta caratteri non consentiti.");
            }

            tentativi++;
        } while (tentativi < 3);


    }

    static void Numeri0()
    {
        int numero, somma = 0;

        do
        {
            Console.Write("Inserisci un numero intero:");

            if (int.TryParse(Console.ReadLine(), out numero))
            {
                somma += numero;
            }
            else
            {
                Console.WriteLine("Non hai inserito un numero. Riprova");
                numero = 1;
            }

        } while (numero != 0);

        Console.WriteLine($"La somma finale e' {somma}");
    }

    static void Calcolatrice()
    {
        string operatore, risposta;
        double num1, num2;
        bool calcola = true, secondoNumeroValido = false, primoNumeroValido = false;

        do
        {
            Console.Write("Benvenuto nella calcolatrice, inserisci il primo numero: ");
            primoNumeroValido = double.TryParse(Console.ReadLine(), out num1);

            if (!primoNumeroValido)
            {
                continue;
            }
            do
            {
                Console.Write("Inserire il secondo numero: ");
                secondoNumeroValido = double.TryParse(Console.ReadLine(), out num2);

                if (!secondoNumeroValido)
                {
                    Console.WriteLine("Valore non valido. Riprova");
                }
            } while (!secondoNumeroValido);

            Console.Write("Inserisci l'operatore desiderato (+,-,*,/): ");
            operatore = Console.ReadLine();
            switch (operatore)
            {
                case "+":
                    Console.WriteLine($"La somma e' {num1 + num2}");
                    break;
                case "-":
                    Console.WriteLine($"La differenza e' {num1 - num2}");
                    break;
                case "*":
                    Console.WriteLine($"Il prodotto e' {num1 * num2}");
                    break;
                case "/":
                    Console.WriteLine($"Il rapporto e' {num1 / num2}");
                    break;
                default:
                    Console.WriteLine($"Non riconosco questo operatore!");
                    break;
            }
                Console.Write("Vuoi eseguire un altra operazione (s/n)? ");
                risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "s":
                        break;
                    case "n":
                        calcola = false;
                        break;
                }
        } while (calcola);

    }


}