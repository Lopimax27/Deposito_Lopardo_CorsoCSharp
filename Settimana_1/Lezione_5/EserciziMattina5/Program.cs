using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

class Program
{
    public static int punteggio1 = 0, punteggio2 = 0, punteggio3 = 0, bns1 = 0, bns2 = 0, bns3 = 0, punteggioTotale;
    public static double punteggioMedio;
    static void Main(string[] args)
    {
        //EsercizioPunteggio();
        EsercizioStudente();
    }

    private static void EsercizioPunteggio()
    {
        Console.Write("Inserisci il tuo primo punteggio: ");
        punteggio1 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il tuo secondo punteggio: ");
        punteggio2 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il tuo terzo punteggio: ");
        punteggio3 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il tuo primo bonus: ");
        bns1 = int.Parse(Console.ReadLine());
        Console.Write("Inserisci il tuo secondo bonus: ");

        bns2 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il tuo terzo bonus: ");
        bns3 = int.Parse(Console.ReadLine());

        AggiornaPunteggio(ref punteggio1, ref punteggio2, ref punteggio3, bns1, bns2, bns3, out punteggioTotale, out punteggioMedio);

        Console.WriteLine($"Il punteggio totale vale {punteggioTotale} e Il tuo punteggio medio vale {punteggioMedio}");
    }
    private static void AggiornaPunteggio(ref int p1, ref int p2, ref int p3, int bns1, int bsn2, int bsn3, out int pntTot, out double pntMd)
    {
        p1 += bns1;
        p2 += bns2;
        p3 += bns3;

        pntTot = p1 + p2 + p3;
        pntMd = pntTot / 3.0;
    }

    private static void EsercizioStudente()
    {
        double votoMedio;
        bool promosso;

        Console.Write("Inserisci il tuo nome: ");
        string? nome = Console.ReadLine();

        Console.Write("Inserisci voto 1: ");
        double voto1 = int.Parse(Console.ReadLine());

        Console.Write("Inserisci voto 2: ");
        double voto2 = int.Parse(Console.ReadLine());

        ElaboraStudente(ref nome, ref voto1, ref voto2, out votoMedio, out promosso);
        Console.Write($"Il voto medio di {nome} è {votoMedio},");
        if (promosso == true)
        {
            Console.Write("Sei Promosso!!");
        }
        else
        { 
            Console.Write($"{nome}Bocciato buuuu!");
        }
        
    }

    private static void ElaboraStudente(ref string nome, ref double voto1, ref double voto2, out double votoMedio, out bool promosso)
    {
        votoMedio = (voto1 + voto2) / 2.0;
        promosso = votoMedio >= 6;
    }
}