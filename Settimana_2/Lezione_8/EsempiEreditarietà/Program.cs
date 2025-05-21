using System;

//Classe base
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

//Classe derivata 
public class Cane : Animale
{
    //Metodo specifico della classe derivata
    public void Scondinzola()
    {
        Console.WriteLine("Il cane scodinzola.");
    }
}

public class Program
{
    public static void Main()
    {
        Cane mioCane = new Cane();
        mioCane.FaiVerso();
        mioCane.Scondinzola();
    }
}