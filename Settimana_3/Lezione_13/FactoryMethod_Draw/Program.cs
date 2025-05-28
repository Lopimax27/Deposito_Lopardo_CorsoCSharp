using System;

//Creazione interfaccia IShape
public interface IShape
{
    void Draw();
}

//Crezione della classe concreta Cerchio e Quadrato
public class Circle:IShape
{
    public void Draw()
    { 
        Console.WriteLine("    ***");
        Console.WriteLine("  *     *");
        Console.WriteLine(" *       *");
        Console.WriteLine("*         *");
        Console.WriteLine("*         *");
        Console.WriteLine("*         *");
        Console.WriteLine(" *       *");
        Console.WriteLine("  *     *");
        Console.WriteLine("    ***");
    }
}

public class Square : IShape
{
    public void Draw()
    { 
        Console.WriteLine("*********");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*       *");
        Console.WriteLine("*********");
    }
}

public class Triangle : IShape
{
    public void Draw()
    { 
        Console.WriteLine("    *");
        Console.WriteLine("   * *");
        Console.WriteLine("  *   *");
        Console.WriteLine(" *     *");
        Console.WriteLine("*       *");
        Console.WriteLine("*********");
    }
}

public abstract class ShapeCreator
{
    public abstract IShape CreateShape(string type);

    public void Genera()
    {
        string type = Console.ReadLine();
        IShape shape = CreateShape(type);

        if (shape != null)
        {
            shape.Draw();
        }
    }
}

public class ConcreteShapeCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        switch (type.ToLower())
        {
            case "circle":
                return new Circle();
            case "square":
                return new Square();
            case "triangle":
                return new Triangle();
            default:
                Console.WriteLine("Forma sconosciuta");
                return null;
        }
    }
}

public class Menu()
{
    public static void ScelteMenu()
    {
        bool x = true;//variabile booleane che ti fa uscire dal ciclo do 
        do
        {
            //Visualizzazione Menu
            Console.WriteLine("1.Genera una forma a scelta\n0.Esci");
            int scelta = int.Parse(Console.ReadLine());//Scelta per lo switch

            switch (scelta)
            {
                case 1:
                    Input();
                    break;
                case 0:
                    x = false;//imposta bool a false per uscire
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (x);
    }
    private static void Input()
    {
        Console.WriteLine("Insersci cosa vuoi inserire (square o circle o triangle)");
        ShapeCreator v = new ConcreteShapeCreator();
        v.Genera();
    }
}


public class Program
{
    public static void Main()
    {
        Menu.ScelteMenu();
    }
}