using System;

public class Program
{
    public static void Main(string[] args)
    {
        IGreeter g = new ConsoleGreeter();
        var service = new GreeterService(g);

        Console.WriteLine("Inserisci il tuo nome: ");
        string? nome = Console.ReadLine();

        service.Greeting(nome);

        IPaymentGateway payment1 = new PaypalGateway();
        IPaymentGateway payment2 = new StripeGateway();

        Console.WriteLine("Inserisci il metodo di pagamento paypal(1) stripe (2)");
        int metodo = int.Parse(Console.ReadLine());

        switch (metodo)
        {
            case 1:
                var paga = new PaymentProcessor(payment1);
                paga.MetodoScelto();
                break;
            case 2:
                paga = new PaymentProcessor(payment2);
                paga.MetodoScelto();
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
    }
}