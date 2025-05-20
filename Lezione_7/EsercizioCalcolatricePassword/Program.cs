using System;
using System.Reflection;


public class Utente
{
    // Dichiarazione delle proprietà della classe utente
    public string nickname;
    public string password;
    public int eta;

    /// <summary>
    /// Costruttore per Utente
    /// </summary>
    /// <param name="n"></param>
    /// <param name="p"></param>
    /// <param name="e"></param>
    public Utente(string n, string p, int e)
    {
        nickname = n;
        password = p;
        eta = e;
    }
    /// <summary>
    /// Funzione Equals modificata per poter controllare l'accesso in fase di login
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is Utente login)
        {
            return this.nickname == login.nickname && this.password == login.password;
        }
        return false;
    }
    
    /// <summary>
    ///Creazione di GetHashCode coerente con l'equals 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(nickname, password);
    }
}

public class Program
{
    public static void Main()
    {

        //Sistema di Registrazione che prende in input nome eta e password
        Console.Write("Registrati nel menu Calcolatrice, come prima cosa inserisci il nickname: ");
        string nome = Console.ReadLine();

        Console.Write("Inserisci la tua età: ");
        int eta = int.Parse(Console.ReadLine());

        Console.Write("Ora inserisci la password: ");
        string password = Console.ReadLine();

        Utente utente1 = new Utente(nome, password, eta); //Crezione dell'utente con le variabili in input
        
        bool controllo = false, uscire;// definizione e inizializzazione delle variabili di controllo dei due cicli while
        int calcoliSvolti=0;//contatore dei calcoli eseguiti

        do
        {
            //Ciclo while per il controllo di login che crea un uovo utente di appoggio login e lo controlla con l'utente creato in fase di registrazione
            while (!controllo)
            {
                Console.Write("Insersci il tuo nickname: ");
                string loginNick = Console.ReadLine();
                Console.Write("Inserisci la password: ");
                string loginPassword = Console.ReadLine();

                Utente login = new Utente(loginNick, loginPassword, 0);
                controllo = utente1.Equals(login);
                if (controllo == false) //Riporta l'errore e in seguito ricomincia il ciclo fino a che non viene inserito il login corretto
                {
                    Console.WriteLine("Password o nickname sbagliati riprovare");
                }
            }

            //Richiesta in input dei parametri per permettere alla funzione calcolatrice di funzionare grazie a due int e una stringa operatore
            Console.Write("Inserisci il primo numero: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Inserisci il secondo numero: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Inserisci l'operazione da svolgere tra somma, moltiplicazione e divisione: ");
            string operatore = Console.ReadLine();

            Console.WriteLine($"{Calcolatrice(a, b, operatore)}");

            //Richiesta di uscita dal ciclo e chiusura del programma
            Console.Write("Vuoi uscire dalla calcolatrice (s o qualsiasi altra cosa per restare)?");
            string scelta = Console.ReadLine();
            calcoliSvolti++;

            //Blocco di controlli per gestire la scelta e dopo 3 calcoli svolti richiede all'utente di rieffettuare il login
            if (scelta == "s")
            {
                uscire = true;
            }
            else
            {
                uscire = false;
                if (calcoliSvolti > 3)
                {
                    controllo = false;
                    Console.WriteLine("Calcoli esauriti: Reinserire nick e password");
                }
            }
        } while (!uscire);

        Console.WriteLine("Arrivederci!");

    }

    /// <summary>
    /// Funzione calcolatrice che riceve due int e una stringa operatore
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="operazione"></param>
    /// <returns>A seconda dell'operatore scelto ritorna il valore dell'operazione o un mes di errore se l'operatore non è riconosciuto</returns>
    public static object Calcolatrice(int a, int b, string operazione)
    {
        switch (operazione)
        {
            case "somma":
                return a + b;
            case "moltiplicazione":
                return a * b;
            case "divisione":
                return a / b;
            default:
                return "operatore non riconosciuto";
        }
    }
}