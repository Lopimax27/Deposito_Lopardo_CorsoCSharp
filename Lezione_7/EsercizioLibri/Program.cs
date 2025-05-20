using System;

public class Film
{
    //Definizione delle variabili del film
    public string titolo, regista, versione;
    public int annoDiUscitaDVD;

    /// <summary>
    /// Costruttore della classe film
    /// </summary>
    /// <param name="tit"></param>
    /// <param name="reg"></param>
    /// <param name="ver"></param>
    /// <param name="anno"></param>
    public Film(string tit, string reg, string ver, int anno)
    {
        titolo = tit;
        regista = reg;
        versione = ver;
        annoDiUscitaDVD = anno;
    }

    /// <summary>
    /// Metodo ToString per ricevere la descrizione del film 
    /// </summary>
    /// <returns>Titolo regista anno di uscita e versione</returns>
    public override string ToString()
    {
        return $"{titolo} del regista {regista} uscito nell'anno {annoDiUscitaDVD} in {versione}";
    }

    /// <summary>
    /// Esegue il controllo per verificare se il film ha stesso titolo e regista
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj is Film film)
        {
            return this.titolo == film.titolo && this.regista == film.regista;
        }
        return false;
    }

    /// <summary>
    /// Esegue il controllo logico coerente con la funzione Equals
    /// </summary>
    /// <returns>Combina HashCode di titolo e regista</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(titolo, regista);
    }
    
}

public class Program
{
    public static void Main()
    {
        //Inizializzazione dei 3 film diversi con titolo regista versione e anno
        Film inception = new Film("Inception", "Christopher Nolan", "Cinema", 2010);
        Film inceptionDVD = new Film("Inception", "Christopher Nolan", "DVD-Blu-Ray", 2015);
        Film tenet = new Film("Tenet", "Christopher Nolan", "Cinema", 2020);

        //stampa la descrizione
        Console.WriteLine(inception);
        Console.WriteLine(tenet);

        //Esegue il test Equals true
        Console.WriteLine(inception.Equals(inceptionDVD));
        Console.WriteLine($"{inception.GetHashCode()} e {inceptionDVD.GetHashCode}");

        //Esegue il test nel caso false
        Console.WriteLine(tenet.Equals(inception));
        Console.WriteLine($"{inception.GetHashCode()} e {tenet.GetHashCode}");

        Console.WriteLine(inception.GetType());
        
    }
}