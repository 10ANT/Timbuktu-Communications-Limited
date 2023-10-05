using Timbuktu_Communications_Limited;

public class TimbuktuCom
{
    private static void Main(string[] args)
    {/*
        Console.WriteLine("Hello, World!");
        GeneralBilling gen = new GeneralBilling();
        Console.WriteLine("$"+gen.CableandDigitalCharge());
        
        InternetBilling mina = new InternetBilling();
        Console.WriteLine(mina.CableTeleOnly);
        */
        Customer customer = new Customer();
        //customer.getAccHolderAddress();


        Console.WriteLine(customer.CableTeleOnly); 




    }
}


