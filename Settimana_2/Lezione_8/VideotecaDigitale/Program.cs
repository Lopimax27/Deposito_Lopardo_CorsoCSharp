using System;

public class Film
{
    //Definizione di proprietà titolo regista genere e anno
    public string titolo, regista, genere;
    public int anno;

    /// <summary>
    /// Generazione del costruttore
    /// </summary>
    /// <param name="tit"></param>
    /// <param name="reg"></param>
    /// <param name="gen"></param>
    /// <param name="ann"></param>
    public Film(string tit, string reg, string gen, int ann)
    {
        titolo = tit;
        regista = reg;
        genere = gen;
        anno = ann;
    }

    /// <summary>
    /// Override della funzione ToString per stampare la descrizione del film
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"Il film {titolo} di {regista} dell'anno {anno}, genere {genere} è presente in raccolta";
    }
}

public class Program
{
    public static void Main()
    {
        List<Film> videoteca = new List<Film>(); //inizializzazione lista videoteca

        Console.WriteLine("Benvenuto nella videoteca!");
        //Controllore1  variabile che fa continuare il ciclo while fino a quando l'utente richiede di uscire dal programma 
        bool controllore1 = true;

        do
        {
            //Menu visualizzato
            Console.WriteLine("Eccoti nel menu: Premere 1 per aggiungere un film alla raccolta, premere 2 per effettuare una ricerca nella raccolta, premere 3 per visualizzare tutta la raccolta e 4 per uscire");
            int scelta = int.Parse(Console.ReadLine());

            //switch per muoversi nel menu e scegliere cosa fare e che funzioni richiamare
            switch (scelta)
            {
                case 1:
                    videoteca.Add(InputUtente());//Aggiunge il film restituito da InputUtente
                    break;
                case 2:
                    RicercaFilm(videoteca);//Entra nello switch per scegliere in base a cosa cercare
                    break;
                case 3:
                    Stampa(videoteca);//Richiama la funzione di stampa di tutti i film in raccolta
                    break;
                case 4:
                    controllore1 = false;//booleano che settato false chiude il ciclo
                    break;
            }

        } while (controllore1);

        Console.WriteLine("Arrivederci e buon film!");

    }

    /// <summary>
    /// Richiede all'utente i dati del film
    /// </summary>
    /// <returns>Il nuovo film per salvarlo nella lista</returns>
    public static Film InputUtente()
    {
        Console.Write("Inserisci il titolo del film: ");
        string titolo = Console.ReadLine();

        Console.Write("Inserisci il regista del film: ");
        string regista = Console.ReadLine();

        Console.Write("Inserisci il genere del film: ");
        string genere = Console.ReadLine();

        Console.Write("Inserisci l'anno di uscita del film: ");
        int anno = int.Parse(Console.ReadLine());

        return new Film(titolo, regista, genere, anno);
    }

    /// <summary>
    /// Grazie al ciclo stampa tutti gli elementi della lista
    /// </summary>
    /// <param name="videoteca"></param>
    public static void Stampa(List<Film> videoteca)
    {
        Console.WriteLine("Nella raccolta abbiamo:");
        foreach (Film film in videoteca)
        {
            Console.WriteLine(film);
        }
    }

    /// <summary>
    /// Funzione di switch che permette di scegliere il criterio di ricerca 
    /// </summary>
    /// <param name="videoteca"></param>
    public static void RicercaFilm(List<Film> videoteca)
    {
        Console.Write("Come vuoi cercare il film (1.titolo,2.regista,3.genere,4.anno) ?: ");
        int ricerca = int.Parse(Console.ReadLine());

        //Richiama la funzione in base alla scelta dell'utente
        switch (ricerca)
        {
            case 1:
                SceltaTitolo(videoteca);
                break;
            case 2:
                SceltaRegista(videoteca);
                break;
            case 3:
                SceltaGenere(videoteca);
                break;
            case 4:
                SceltaAnno(videoteca);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Funzione che imposta il controllo per ogni film in base al genere e conta i presenti in caso messaggio di errore
    /// </summary>
    /// <param name="videoteca"></param>
    public static void SceltaGenere(List<Film> videoteca)
    {
        int conto = 0;
        Console.Write("Inserisci il genere del film che vuoi vedere: ");
        string genere = Console.ReadLine();

        foreach (Film film in videoteca)
        {
            if (film.genere == genere) //verifica se il genere coincide con quello preso in i
            {
                Console.WriteLine(film);
                conto++;
            }
        }
        if (conto == 00)
        {
            Console.WriteLine("Non abbiamo film di questo genere, riprovare o aggiungerne uno");
        }
    }

    /// <summary>
    /// Funzione che imposta il controllo per ogni film in base al titolo e conta i presenti in caso messaggio di errore
    /// </summary>
    /// <param name="videoteca"></param>
    public static void SceltaTitolo(List<Film> videoteca)
    {
        int conto = 0;
        Console.Write("Inserisci il titolo del film che vuoi vedere: ");
        string titolo = Console.ReadLine();

        foreach (Film film in videoteca)
        {
            if (film.titolo.ToLower() == titolo.ToLower())
            {
                Console.WriteLine(film);
                conto++;
            }
        }
        if (conto == 00)
        {
            Console.WriteLine("Non abbiamo film con questo titolo, riprovare o aggiungerne uno");
        }
    }

    /// <summary>
    /// Funzione che imposta il controllo per ogni film in base al regista e conta i presenti in caso messaggio di errore
    /// </summary>
    /// <param name="videoteca"></param>
    public static void SceltaRegista(List<Film> videoteca)
    {
        int conto = 0;
        Console.Write("Inserisci il titolo del film che vuoi vedere: ");
        string regista = Console.ReadLine();

        foreach (Film film in videoteca)
        {
            if (film.regista.ToLower() == regista.ToLower())
            {
                Console.WriteLine(film);
                conto++;
            }
        }
        if (conto == 00)
        {
            Console.WriteLine("Non abbiamo film di questo regista, riprovare o aggiungerne uno");
        }
    }
    
    /// <summary>
    /// Funzione che imposta il controllo per ogni film in base all'anno e conta i presenti in caso messaggio di errore
    /// </summary>
    /// <param name="videoteca"></param>
    public static void SceltaAnno(List<Film> videoteca)
    {
        int conto = 0;
        Console.Write("Inserisci il titolo del film che vuoi vedere: ");
        int anno = int.Parse(Console.ReadLine());

        foreach (Film film in videoteca)
        {
            if (film.anno == anno)
            {
                Console.WriteLine(film);
                conto++;
            }
        }
        if (conto == 00)
        {
            Console.WriteLine("Non abbiamo film di questo anno, riprovare o aggiungerne uno");
        }
    }

}