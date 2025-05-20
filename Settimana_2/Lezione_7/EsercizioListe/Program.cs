using System;

public class Program
{
    public static void Main()
    {
        //Creazione della lista della spesa, Messaggio di richiesta e inserimento del numero di CDC
        List<string> listaSpesa = new List<string>();
        Console.WriteLine("Quante cose devi comprare?");
        int CDComprare = int.Parse(Console.ReadLine());

        for (int i = 0; i < CDComprare; i++)
        {   
            //Aggiunge elemento ricevuto in input alla lista della Spesa
            Console.Write("Inserisci una cosa da comprare al supermercato: ");
            listaSpesa.Add(Console.ReadLine());
        }

        for (int i = 0; i < CDComprare; i++)
        {
            //Stampa dei valori
            Console.WriteLine($"Elemento {i + 1} = {listaSpesa[i]}");
        }
    }
}