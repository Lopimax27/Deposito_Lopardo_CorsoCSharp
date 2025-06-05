using System;

public enum TipoTransazione
{
    Acquisto,
    Rimborso,
    Trasferimento
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Inserisci l'importo della transazione:");
        
        if (decimal.TryParse(Console.ReadLine(), out decimal importoUtente))
        {
            Console.WriteLine("Seleziona il tipo di transazione:");
            Console.WriteLine("1 - Acquisto");
            Console.WriteLine("2 - Rimborso");
            Console.WriteLine("3 - Trasferimento");
            
            if (int.TryParse(Console.ReadLine(), out int scelta) && scelta >= 1 && scelta <= 3)
            {
                TipoTransazione tipoSelezionato = (TipoTransazione)(scelta - 1);
                decimal commissioneCalcolata = CalcolaCommissione(importoUtente, tipoSelezionato);
                
                Console.WriteLine($"Transazione: {tipoSelezionato}");
                Console.WriteLine($"Importo: €{importoUtente}");
                Console.WriteLine($"Commissione: €{commissioneCalcolata}");
                Console.WriteLine($"Totale: €{(importoUtente + commissioneCalcolata)}");
            }
            else
            {
                Console.WriteLine("Selezione non valida.");
            }
        }
        else
        {
            Console.WriteLine("Importo non valido.");
        }
    }
    
    /// <summary>
    /// Calcola la commissione in base al tipo di transazione
    /// </summary>
    /// <param name="importo">L'importo della transazione</param>
    /// <param name="tipoTransazione">Il tipo di transazione</param>
    /// <returns>La commissione calcolata</returns>
    public static decimal CalcolaCommissione(decimal importo, TipoTransazione tipoTransazione)
    {
        switch (tipoTransazione)
        {
            case TipoTransazione.Acquisto:
                return CalcolaCommissioneAcquisto(importo);
            case TipoTransazione.Rimborso:
                return CalcolaCommissioneRimborso(importo);
            case TipoTransazione.Trasferimento:
                return CalcolaCommissioneTrasferimento(importo);
            default:
                return 0;
        }
    }

    /// <summary>
    /// Calcola la commissione per gli acquisti
    /// Commissione: 2% dell'importo, minimo €1.50
    /// </summary>
    private static decimal CalcolaCommissioneAcquisto(decimal importo)
    {
        decimal percentuale = 0.02m;
        decimal commissionePercentuale = importo * percentuale;
        decimal commissioneMinima = 1.50m;

        if (commissioneMinima > commissionePercentuale)
        {
            return commissioneMinima;
        }
        else
        {
            return commissionePercentuale;
        }
    }
    
    /// <summary>
    /// Calcola la commissione per i rimborsi
    /// Commissione: 1% dell'importo, massimo €10.00
    /// </summary>
    private static decimal CalcolaCommissioneRimborso(decimal importo)
    {
        decimal percentuale = 0.01m; // 1%
        decimal commissionePercentuale = importo * percentuale;
        decimal commissioneMassima = 10.00m;

        if (commissioneMassima < commissionePercentuale)
        {
            return commissioneMassima;
        }
        else
        {
            return commissionePercentuale;
        }
    }

    /// <summary>
    /// Calcola la commissione per i trasferimenti
    /// Commissione fissa: €2.50 per importi fino a €500, €5.00 per importi superiori
    /// </summary>
    private static decimal CalcolaCommissioneTrasferimento(decimal importo)
    {
        if (importo < 500)
        {
            return 2.5m;
        }
        else
        {
            return 5m;
        }
    }
}
