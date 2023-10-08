using System.Globalization;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using Timbuktu_Communications_Limited;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TimbuktuCom
{
	public static GeneralBilling customer1 = null; // Use the common base class

	private static void Main(string[] args)
    {
		Console.WriteLine("\x1b[1mWelcome to Timbuktu's Bill Processing Platform \x1b[0m");
        Console.WriteLine();
        Console.WriteLine("Select the type of customer that you are:");
		Console.WriteLine("1. Cable Television Only");
		Console.WriteLine("2. Digital Landline Only");
		Console.WriteLine("3. Internet service Only");
		Console.WriteLine("4. Bundle Bill Service");

		

		int choice = int.Parse(Console.ReadLine());

		switch (choice)
		{
			case 1:
				
				customer1 = new CableTeleBill();


				customer1.getAccHolderDetails();
				customer1.getAccHolderAddress();

				customer1.collectPreviousBalandPayment();

                Console.WriteLine();

               // dateCollectandParsePreviouspaymt();
				//dateCollectandParseCurDuepaymt();

				customer1.earlyPaymtDiscount();
				customer1.latePaymtFees();


				customer1.lateorearlystatus();
				customer1.totAmtDuteBefTax();

				//Outputs
				Console.WriteLine();

				Console.WriteLine("Your Account Number is: "+customer1.accNum+"");
				Console.WriteLine("Your Account Holder Name is: " + customer1.accFirst_Lastconcat + "");
				Console.WriteLine("Your Account Holder Address is: " + customer1.accHolderAddress + "");
				//Specific Service Type 
				Console.WriteLine("Your Account Service type is: Cable Television Only");
				Console.WriteLine("Your Previous Balance is: " + customer1.altprevBal.ToString("F2"));
				Console.WriteLine("Your Payment on the Previous Balance is: " + customer1.altpaymtonPrevBal.ToString("F2"));



				Console.WriteLine($"${customer1.vartotAmtDueBefTax:0.00}");
				Console.WriteLine(customer1.vartotAmtDue);

				break;
			case 2:
				customer1 = new DigitalLandBill();
				customer1.totAmtDuteBefTax();
				Console.WriteLine(customer1.vartotAmtDueBefTax);
				Console.WriteLine(customer1.vartotAmtDue);

				break;
			case 3:
			
				customer1 = new InternetServBill();
				break;

			case 4:
				customer1 = new BundledBill();
				customer1.bundlebillselector();

				customer1.totAmtDuteBefTax();
				Console.WriteLine(customer1.vartotAmtDueBefTax);
				Console.WriteLine(customer1.vartotAmtDue);
                Console.WriteLine(customer1.fCTandDLcharge);



                break;

			default:
				Console.WriteLine("Invalid choice");
				return;
		}






		/*
        Console.WriteLine("Hello, World!");
        GeneralBilling gen = new GeneralBilling();
        Console.WriteLine("$"+gen.CableandDigitalCharge());
        
        InternetBilling mina = new InternetBilling();
        Console.WriteLine(mina.CableTeleOnly);
        */
		//Customer customew = new Customer();
		//customer.getAccHolderAddress();


		//Console.WriteLine(customer.CableTeleOnly);


		//newcu.currentPaymtDate = new DateTime(2023, 5, 6);
		
		//customer1.currentPaymtDueDate= new DateTime(2023, 4, 6);
		//customer1.previousPaymtDate = new DateTime(2023, 5, 6);




		//Console.WriteLine(customer1.latePaymtFees());
		//Console.WriteLine(customer1.earlyPaymtDiscount());
		






    }
	
	public static void dateCollectandParseCurDuepaymt()
    {
		
		//collect date
		Console.Write("Enter your current payment date (yyyy-MM-dd format): ");
		string userInput = Console.ReadLine();

		DateTime parseHolder;
		

		// Attempt to parse the user input into a DateTime
		if (DateTime.TryParse(userInput, out parseHolder))
		{
			// Parsing successful, assign the value to newcu.currentPaymtDate
			 //Console.WriteLine($"You entered: {parseHolder.ToString("yyyy-MM-dd")}");
			 customer1.currentPaymtDueDate = parseHolder;
		
		}
		else
		{
			// Parsing failed, handle the error
			Console.WriteLine("Invalid date input. Please enter a valid date in yyyy-MM-dd format.");
           
        }
	}

	public static void dateCollectandParsePreviouspaymt()
	{

		//collect date
		Console.Write("Enter your previous payment date (yyyy-MM-dd format): ");
		string userInput = Console.ReadLine();

		DateTime parseHolder;


		// Attempt to parse the user input into a DateTime
		if (DateTime.TryParse(userInput, out parseHolder))
		{
			// Parsing successful, assign the value to newcu.currentPaymtDate
			 //Console.WriteLine($"You entered: {parseHolder.ToString("yyyy-MM-dd")}");
			 customer1.previousPaymtDate = parseHolder;
		}
		else
		{
			// Parsing failed, handle the error
			Console.WriteLine("Invalid date input. Please enter a valid date in yyyy-MM-dd format.");
		}
	}

	public static void dateCollectandPreviousDueDate()
	{

		//collect date
		Console.Write("Enter your previous due date (yyyy-MM-dd format): ");
		string userInput = Console.ReadLine();

		DateTime parseHolder;


		// Attempt to parse the user input into a DateTime
		if (DateTime.TryParse(userInput, out parseHolder))
		{
			// Parsing successful, assign the value to newcu.currentPaymtDate
			//Console.WriteLine($"You entered: {parseHolder.ToString("yyyy-MM-dd")}");
			customer1.previousDueDate = parseHolder;
		}
		else
		{
			// Parsing failed, handle the error
			Console.WriteLine("Invalid date input. Please enter a valid date in yyyy-MM-dd format.");
		}
	}

	

	/*public static void CollectAndParsePrev(Customer customer)
	{
		Console.Write("Enter your current payment date (yyyy-MM-dd format): ");
		string userInput = Console.ReadLine();

		DateTime currentPaymentDate;

		if (!string.IsNullOrWhiteSpace(userInput) &&
			DateTime.TryParseExact(userInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentPaymentDate))
		{
			customer.currentPaymtDueDate = currentPaymentDate;

			
		}
		else
		{
			Console.WriteLine("Invalid date input. Please enter a valid date in yyyy-MM-dd format.");
		}
	}*/	
}
// to string  to get rid og 12:00:00am


