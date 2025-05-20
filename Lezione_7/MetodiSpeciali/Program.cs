using System;
public class Punto
{
    public int x;
    public int y;

    public override bool Equals(object obj)
    {
        if (obj is Punto altro)
        {
            return this.x == altro.x && this.y == altro.y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}

public class Program
{
    public static void Main()
    {
        Punto a = new Punto { x = 1, y = 2 };
        Punto b = new Punto { x = 1, y = 2 };

        Console.WriteLine(a.Equals(b));
        Console.WriteLine(a.GetHashCode());
        Console.WriteLine(b.GetHashCode());
    }
}