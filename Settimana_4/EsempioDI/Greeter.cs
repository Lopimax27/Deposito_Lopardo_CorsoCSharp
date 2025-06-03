
public interface IGreeter
{
    void Greet(string nome);
}

public class ConsoleGreeter : IGreeter
{
    public void Greet(string nome)
    {
        Console.WriteLine($"Benvenuto {nome} e complimenti per essere arrivato fin qui");
    }
}

public class GreeterService
{
    private readonly IGreeter _greeter;

    public GreeterService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public void Greeting(string nome)
    {
        _greeter.Greet(nome);
    }
}
