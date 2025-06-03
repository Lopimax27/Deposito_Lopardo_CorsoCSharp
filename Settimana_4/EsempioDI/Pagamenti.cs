
public interface IPaymentGateway
{
    void Log();
}

public class PaypalGateway:IPaymentGateway
{
    public void Log()
    {
        Console.WriteLine("Metodo scelto paypal\nIn attesa di pagamento...");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void Log()
    {
        Console.WriteLine("Metodo scelto stripe\nIn attesa di pagamento...");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentGateway _pay;

    public PaymentProcessor(IPaymentGateway pay)
    {
        _pay = pay;
    }

    public void MetodoScelto()
    {
        _pay.Log();
    }
}