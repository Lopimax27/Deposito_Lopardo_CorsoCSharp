using System;

public class Film
{
    public string titolo, regista, genere;
    public int anno;

    public Film(string tit, string reg, string gen, int ann)
    {
        titolo = tit;
        regista = reg;
        genere = gen;
        anno = ann;
    }

    public override string ToString()
    {
        return $"Il film {titolo} di {regista} dell'anno {anno}, genere {genere} è presente in raccolta";
    }
}

public class Program
{
    public static void Main()
    {
        List<Film> videoteca = new List<Film>();

        Console.WriteLine("Benvenuto nella videoteca!");
        bool controllore1 = true;

        do
        {
            Console.WriteLine("Eccoti nel menu: Premere 1 per aggiungere un film alla raccolta, premere 2 per scegliere un genere e visualizzare i film proposti, premere 3 per visualizzare tutta la raccolta e 4 per uscire");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    videoteca.Add(InputUtente());
                    break;
                case 2:
                    RicercaFilm(videoteca);
                    break;
                case 3:
                    Stampa(videoteca);
                    break;
                case 4:
                    controllore1 = false;
                    break;
            }

        } while (controllore1);

        Console.WriteLine("Arrivederci e buon film!");

    }

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

    public static void Stampa(List<Film> videoteca)
    {
        Console.WriteLine("Nella raccolta abbiamo:");
        foreach (Film film in videoteca)
        {
            Console.WriteLine(film);
        }
    }

    public static void RicercaFilm(List<Film> videoteca)
    {
        Console.Write("Come vuoi cercare il film (1.titolo,2.regista,3.genere,4.anno) ?: ");
        int ricerca = int.Parse(Console.ReadLine());

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

    public static void SceltaGenere(List<Film> videoteca)
    {
        int conto = 0;
        Console.Write("Inserisci il genere del film che vuoi vedere: ");
        string genere = Console.ReadLine();

        foreach (Film film in videoteca)
        {
            if (film.genere == genere)
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
    
    public static void SceltaAnno( List<Film> videoteca)
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