using System;

public class Program
{
    public static void Main()
    {
        List<string> listaSpesa = new List<string>();
        Console.WriteLine("Quante cose devi comprare?");
        int CDComprare = int.Parse(Console.ReadLine());

        for (int i = 0; i < CDComprare; i++)
        {
            Console.Write("Inserisci una cosa da comprare al supermercato: ");
            listaSpesa.Add(Console.ReadLine());
        }

        for (int i = 0; i < CDComprare; i++)
        {
            Console.WriteLine($"Elemento {i+1} = {listaSpesa[i]}");
        }
    }
}