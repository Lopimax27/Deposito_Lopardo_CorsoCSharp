using System;

public class Macchina
{
    //Proprietà della classe Macchina
    public string motore;
    public int sospensioneMax, nrModifiche;
    public float velocitaMax;

    //Costruttore della classe che riceve i 4 valori e le assegna alle proprietà del nuovo oggetto 
    public Macchina(string mot, float vM, int sM, int nrM)
    {
        motore = mot;
        velocitaMax = vM;
        sospensioneMax = sM;
        nrModifiche = nrM;
    }

    //override della funzione per ottenere la descrizione della macchina
    public override string ToString()
    {
        return $"ha il motore {motore}, ha {velocitaMax}, è stato modificato {nrModifiche} volte e ha {sospensioneMax} sospensioni. ";
    }
}

public class Utente
{
    //Proprietà della classe utente
    public string nome;
    public int credito;

    //Costruttore della classe utente
    public Utente(string nm, int cr)
    {
        nome = nm;
        credito = cr;
    }

    //Override per ottenere solo il nome e non i crediti al richiamo dell'utente in CWL
    public override string ToString()
    {
        return nome;
    }
}

public class Program
{
    public static void Main()
    {
        Utente utente1 = InputUtente();//creazione dell'utente grazie al costruttore e alla funzione inpututente
        Macchina miaAuto1 = InputMacchina();//creazione della macchina grazie al costruttore e alla funzione inputmacchina
        Modifiche(ref miaAuto1, ref utente1);

        Utente utente2 = InputUtente();
        Macchina miaAuto2 = InputMacchina();
        Modifiche(ref miaAuto2, ref utente2);

        Utente utente3 = InputUtente();
        Macchina miaAuto3 = InputMacchina();
        Modifiche(ref miaAuto3, ref utente3);
    }

    /// <summary>
    /// Funzione di input che prende le proprietà della macchina 
    /// </summary>
    /// <returns>restituisce la macchina da salvare poi nel main in una variabile</returns>
    public static Macchina InputMacchina()
    {
        Console.Write("Inserisci il motore della tua macchina: ");
        string motore = Console.ReadLine();
        Console.Write("Inserisci la velocità massima: ");
        float velocitaMax = float.Parse(Console.ReadLine());
        Console.Write("Inserisci il numero di sospensioni: ");
        int sospensioneMax = int.Parse(Console.ReadLine());

        return new Macchina(motore, velocitaMax, sospensioneMax, 0);
    }

    /// <summary>
    /// Funzione di input che prende nome e crediti dell'utente
    /// </summary>
    /// <returns>restituisce l'utente  poi nel main in una variabile</returns>
    public static Utente InputUtente()
    {
        Console.Write("Inserisci il tuo nome: ");
        string nome = Console.ReadLine();

        Console.Write("Inserisic i tuoi crediti: ");
        int crediti = int.Parse(Console.ReadLine());

        return new Utente(nome, crediti);
    }

    /// <summary>
    /// Funzione che modifica le auto ricevute dall'utente a seconda della scelta in cambio di crediti
    /// </summary>
    /// <param name="miaAuto"></param>
    /// <param name="utente"></param>
    public static void Modifiche(ref Macchina miaAuto, ref Utente utente)
    {
        for (int i = 0; i < utente.credito; i++)
        {
            Console.WriteLine("Scegli la modifica da effettuare 1. Aumenta la velocità di 10 2. Cambia il tipo di motore 3.Aumenta di 1 le sospensioni: ");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    miaAuto.velocitaMax += 10;

                    break;
                case 2:
                    miaAuto.motore = Console.ReadLine();
                    break;
                case 3:
                    miaAuto.sospensioneMax++;
                    break;
                default:
                    Console.WriteLine("Scelta non valita");
                    miaAuto.nrModifiche--;
                    utente.credito++;
                    break;
            }

            miaAuto.nrModifiche++;
            utente.credito--;
        }

        Console.WriteLine($"La macchina di {utente} {miaAuto} ");
    }
}