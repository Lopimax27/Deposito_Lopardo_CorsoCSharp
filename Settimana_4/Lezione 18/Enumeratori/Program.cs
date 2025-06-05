using System;
using System.ComponentModel;

public enum GiornoSettimana
{
    Lunedi,
    Martedi,
    Mercoledi,
    Giovedi,
    Venerdi,
    Sabato,
    Domenica
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Che giorno è oggi?");
        GiornoSettimana giorno = Enum.Parse<GiornoSettimana>(Console.ReadLine());
        switch (giorno)
        {
            case GiornoSettimana.Lunedi:
                Console.WriteLine("Today is Monday");
                break;
            case GiornoSettimana.Martedi:
                Console.WriteLine("Today is Tuesday");
                break;
            case GiornoSettimana.Mercoledi:
                Console.WriteLine("Today is Wednesday");
                break;
            case GiornoSettimana.Giovedi:
                Console.WriteLine("Today is Thursday");
                break;
            case GiornoSettimana.Venerdi:
                Console.WriteLine("Today is Friday");
                break;
            case GiornoSettimana.Sabato:
                Console.WriteLine("Today is Saturday");
                break;
            case GiornoSettimana.Domenica:
                Console.WriteLine("Today is Sunday");
                break;
        }
    }

}