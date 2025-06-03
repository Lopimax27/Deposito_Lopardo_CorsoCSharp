/// <summary>
/// Interfaccia StorageService con metodo salva per salvare file su un metodo di storage
/// </summary>
public interface IStorageService
{
    void Salva();
}

/// <summary>
/// Classe concreta che implementa l'interfaccia IstorageService con metodo salva che stampa messaggio
/// </summary>
public class DiskStorage : IStorageService
{
    public void Salva()
    {
        Console.WriteLine("FILE SALVATO SU DISCO");
    }
}
/// <summary>
/// Classe concreta che implementa l'interfaccia IstorageService con metodo salva che stampa messaggio simulato
/// </summary>
public class SimulateStorage : IStorageService
{
    public void Salva()
    {
        Console.WriteLine("FILE SALVATO SU MEMORIA SIMULATA");
    }

}

/// <summary>
/// Classe che implementa come proprietà IStorage service con get e set e funzione salva che verifica non sia nullo lo storage
/// </summary>
public class FileUploader
{
    public IStorageService storage { get; set; }

    public void Salva()
    {
        if (storage == null)
        {
            Console.WriteLine("Memoria non impostata non posso salvare il file");
            return;
        }
        storage.Salva();
    }
}
