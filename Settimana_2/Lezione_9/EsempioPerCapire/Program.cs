using System;

public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso");
    }
}

public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia.");
    }
}

public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola.");
    }
}

public class Program
{
    public static void Main()
    {
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        foreach (Animale an in animali)
        {
            an.FaiVerso();
        }
    }
}
