using System;
using System.Runtime.InteropServices.Marshalling;

public class Studente
{
    private string _nome;
    private string _cognome;
    private double _media;

    public string Nome { get; set; }
    public string Cognome { get; set; }
    public double Media { get; set; }

    public Studente()
    {
        _nome = Nome;
        _cognome = Cognome;
        _media = Media;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} Cognome: {Cognome} Media: {Media}";
    }
}

public class Program
{
    public static void Main()
    {
        Studente student1 = new Studente();
        student1.Nome = Console.ReadLine();
        student1.Cognome = Console.ReadLine();
        student1.Media = double.Parse(Console.ReadLine());
        
        Console.Write(student1);
    }
}
