using System.Globalization;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using Timbuktu_Communications_Limited;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TimbuktuCom
{
	public static GeneralBilling customer1 = null; // Creating the common base class instance tbu by derived classes

	//Main Method
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

				//Collection of Customer Details 
				customer1.getAccHolderDetails();
				customer1.getAccHolderAddress();

				//Collection of Previous Balance and Payment
				customer1.collectPreviousBalandPayment();

				//Calculation of the Balance Brought Forward
				customer1.balBroughtForward();

				Console.WriteLine();

				//Collection and Parsing of some Previous Dates of Due and Payment
				dateCollectandPreviousDueDate();
				dateCollectandParsePreviouspaymt();

				//Collecting and Parsing Current Payment Date 
				Console.WriteLine();
				dateCollectandParseCurDuepaymt();

				//Exception Handling of Invalid Date
				while (customer1.currentPaymtDueDate < customer1.previousDueDate) {
				    Console.WriteLine("\nCode 45: Invalid Date Entry, Please Try Again!");
					dateCollectandParseCurDuepaymt();
				}
				//Calcution of Late Fees or Early Payment Discounts
				customer1.earlyPaymtDiscount();
				customer1.latePaymtFees();

				//Calling some Calcution Functions
				customer1.lateorearlystatus();
				customer1.totAmtDuteBefTax();

                //OUTPUTS
                Console.WriteLine("\n\x1b[1m- - - Bill Details - - -\x1b[0m");
                Console.WriteLine();

				Console.WriteLine("Your Account Number is: " + customer1.accNum+"");
				Console.WriteLine("Your Account Holder Name is: " + customer1.accFirst_Lastconcat + "");
				Console.WriteLine("Your Account Holder Address is: " + customer1.accHolderAddress + "");
				//Specific Service Type
				Console.WriteLine("Your Account Service type is: Cable Television Only");
				Console.WriteLine("Your Previous Balance is: $" + customer1.altprevBal.ToString("F2"));
				Console.WriteLine("Your Payment on the Previous Balance is: $" + customer1.altpaymtonPrevBal.ToString("F2"));
				Console.WriteLine("Your Balance Brought Forward is: $" + customer1.varBalBroughtForward.ToString("F2"));
				//Specific Serv charge
				Console.WriteLine("Your Current Service Charge is: $" + customer1.CableTeleOnly.ToString("F2"));
				Console.WriteLine("Your Early Payment Discount is: $" + customer1.varearlyPaymtDiscount.ToString("F2"));
				Console.WriteLine("Your Late Payment Fee is: $" + customer1.varlatePaymtFees.ToString("F2"));
				Console.WriteLine("Your Total Current Charges are (Serv charge + Balance brought (+-) Discount/Fee: $" + customer1.vartotAmtDueBefTax.ToString("F2"));
				Console.WriteLine("Your GCT is @25%: $" + customer1.GCTamt.ToString("F2"));
				Console.WriteLine("Your Total Amount Due is: $" + customer1.vartotAmtDue.ToString("F2"));
				Console.WriteLine();
				Console.WriteLine("Your Previous Due Date is: " + customer1.previousDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Previous Payment Date is: " + customer1.previousPaymtDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Current Payment Date is: " + customer1.currentPaymtDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Thank you for you for choosing Timbuktu !");

				//Console.WriteLine($"${customer1.vartotAmtDueBefTax:0.00}");
				//Console.WriteLine(customer1.vartotAmtDue);

				break;
			case 2:
				customer1 = new DigitalLandBill();

				//Collection of Customer Details 
				customer1.getAccHolderDetails();
				customer1.getAccHolderAddress();

				//Collection of Previous Balance and Payment
				customer1.collectPreviousBalandPayment();

				//Calculation of the Balance Brought Forward
				customer1.balBroughtForward();

				Console.WriteLine();

				//Collection and Parsing of some Previous Dates of Due and Payment
				dateCollectandPreviousDueDate();
				dateCollectandParsePreviouspaymt();

				//Collecting and Parsing Current Payment Date 
				Console.WriteLine();
				dateCollectandParseCurDuepaymt();

				//Exception Handling of Invalid Date
				while (customer1.currentPaymtDueDate < customer1.previousDueDate)
				{
					Console.WriteLine("\nCode 45: Invalid Date Entry, Please Try Again!");
					dateCollectandParseCurDuepaymt();
				}
				//Calcution of Late Fees or Early Payment Discounts
				customer1.earlyPaymtDiscount();
				customer1.latePaymtFees();

				//Calling some Calcution Functions
				customer1.lateorearlystatus();
				customer1.totAmtDuteBefTax();

				//OUTPUTS
				Console.WriteLine("\n\x1b[1m- - - Bill Details - - -\x1b[0m");
				Console.WriteLine();

				Console.WriteLine("Your Account Number is: " + customer1.accNum + "");
				Console.WriteLine("Your Account Holder Name is: " + customer1.accFirst_Lastconcat + "");
				Console.WriteLine("Your Account Holder Address is: " + customer1.accHolderAddress + "");
				//Specific Service Type
				Console.WriteLine("Your Account Service type is: Digital Landline Only");
				Console.WriteLine("Your Previous Balance is: $" + customer1.altprevBal.ToString("F2"));
				Console.WriteLine("Your Payment on the Previous Balance is: $" + customer1.altpaymtonPrevBal.ToString("F2"));
				Console.WriteLine("Your Balance Brought Forward is: $" + customer1.varBalBroughtForward.ToString("F2"));
				//Specific Serv charge
				Console.WriteLine("Your Current Service Charge is: $" + customer1.DigitalLandOnly.ToString("F2"));
				Console.WriteLine("Your Early Payment Discount is: $" + customer1.varearlyPaymtDiscount.ToString("F2"));
				Console.WriteLine("Your Late Payment Fee is: $" + customer1.varlatePaymtFees.ToString("F2"));
				Console.WriteLine("Your Total Current Charges are (Serv charge + Balance brought (+-) Discount/Fee: $" + customer1.vartotAmtDueBefTax.ToString("F2"));
				Console.WriteLine("Your GCT is @25%: $" + customer1.GCTamt.ToString("F2"));
				Console.WriteLine("Your Total Amount Due is: $" + customer1.vartotAmtDue.ToString("F2"));
				Console.WriteLine();
				Console.WriteLine("Your Previous Due Date is: " + customer1.previousDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Previous Payment Date is: " + customer1.previousPaymtDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Current Payment Date is: " + customer1.currentPaymtDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Thank you for you for choosing Timbuktu !");


				break;
			case 3:
				customer1 = new InternetServBill();

				//Collection of Customer Details 
				customer1.getAccHolderDetails();
				customer1.getAccHolderAddress();

				//Collection of Previous Balance and Payment
				customer1.collectPreviousBalandPayment();

				//Calculation of the Balance Brought Forward
				customer1.balBroughtForward();

				Console.WriteLine();

				//Collection and Parsing of some Previous Dates of Due and Payment
				dateCollectandPreviousDueDate();
				dateCollectandParsePreviouspaymt();

				//Collecting and Parsing Current Payment Date 
				Console.WriteLine();
				dateCollectandParseCurDuepaymt();

				//Exception Handling of Invalid Date
				while (customer1.currentPaymtDueDate < customer1.previousDueDate)
				{
					Console.WriteLine("\nCode 45: Invalid Date Entry, Please Try Again!");
					dateCollectandParseCurDuepaymt();
				}
				//Calcution of Late Fees or Early Payment Discounts
				customer1.earlyPaymtDiscount();
				customer1.latePaymtFees();

				//Calling some Calcution Functions
				customer1.lateorearlystatus();
				customer1.totAmtDuteBefTax();

				//OUTPUTS
				Console.WriteLine("\n\x1b[1m- - - Bill Details - - -\x1b[0m");
				Console.WriteLine();

				Console.WriteLine("Your Account Number is: " + customer1.accNum + "");
				Console.WriteLine("Your Account Holder Name is: " + customer1.accFirst_Lastconcat + "");
				Console.WriteLine("Your Account Holder Address is: " + customer1.accHolderAddress + "");
				//Specific Service Type
				Console.WriteLine("Your Account Service type is: Internet service Only");
				Console.WriteLine("Your Previous Balance is: $" + customer1.altprevBal.ToString("F2"));
				Console.WriteLine("Your Payment on the Previous Balance is: $" + customer1.altpaymtonPrevBal.ToString("F2"));
				Console.WriteLine("Your Balance Brought Forward is: $" + customer1.varBalBroughtForward.ToString("F2"));
				//Specific Serv charge
				Console.WriteLine("Your Current Service Charge is: $" + customer1.InternetServOnly.ToString("F2"));
				Console.WriteLine("Your Early Payment Discount is: $" + customer1.varearlyPaymtDiscount.ToString("F2"));
				Console.WriteLine("Your Late Payment Fee is: $" + customer1.varlatePaymtFees.ToString("F2"));
				Console.WriteLine("Your Total Current Charges are (Serv charge + Balance brought (+-) Discount/Fee: $" + customer1.vartotAmtDueBefTax.ToString("F2"));
				Console.WriteLine("Your GCT is @25%: $" + customer1.GCTamt.ToString("F2"));
				Console.WriteLine("Your Total Amount Due is: $" + customer1.vartotAmtDue.ToString("F2"));
				Console.WriteLine();
				Console.WriteLine("Your Previous Due Date is: " + customer1.previousDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Previous Payment Date is: " + customer1.previousPaymtDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Current Payment Date is: " + customer1.currentPaymtDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Thank you for you for choosing Timbuktu !");

				break;
			case 4:


				customer1 = new BundledBill();
				customer1.bundlebillselector();

				//Collection of Customer Details 
				customer1.getAccHolderDetails();
				customer1.getAccHolderAddress();

				//Collection of Previous Balance and Payment
				customer1.collectPreviousBalandPayment();

				//Calculation of the Balance Brought Forward
				customer1.balBroughtForward();

				Console.WriteLine();

				//Collection and Parsing of some Previous Dates of Due and Payment
				dateCollectandPreviousDueDate();
				dateCollectandParsePreviouspaymt();

				//Collecting and Parsing Current Payment Date 
				Console.WriteLine();
				dateCollectandParseCurDuepaymt();

				//Exception Handling of Invalid Date
				while (customer1.currentPaymtDueDate < customer1.previousDueDate)
				{
					Console.WriteLine("\nCode 45: Invalid Date Entry, Please Try Again!");
					dateCollectandParseCurDuepaymt();
				}
				//Calcution of Late Fees or Early Payment Discounts
				customer1.earlyPaymtDiscount();
				customer1.latePaymtFees();

				//Calling some Calcution Functions ALTERED
				customer1.lateorearlystatus();

				customer1.totAmtDuteBefTax(customer1.bundlebillservcharge);

				//OUTPUTS
				Console.WriteLine("\n\x1b[1m- - - Bill Details - - -\x1b[0m");
				Console.WriteLine();

				Console.WriteLine("Your Account Number is: " + customer1.accNum + "");
				Console.WriteLine("Your Account Holder Name is: " + customer1.accFirst_Lastconcat + "");
				Console.WriteLine("Your Account Holder Address is: " + customer1.accHolderAddress + "");
				//Specific Service Type
				Console.WriteLine("Your Account Service type is: "+customer1.bundlebillservtype+"");
				Console.WriteLine("Your Previous Balance is: $" + customer1.altprevBal.ToString("F2"));
				Console.WriteLine("Your Payment on the Previous Balance is: $" + customer1.altpaymtonPrevBal.ToString("F2"));
				Console.WriteLine("Your Balance Brought Forward is: $" + customer1.varBalBroughtForward.ToString("F2"));

				//if state Service Charge Selector 
				if (customer1.bundlebillservtype == "Cable Television + Digital Landline")
				{
					Console.WriteLine("Your Current Service Charge is: $" + customer1.CableandDigitalCharge().ToString("F2"));
				}
				else if(customer1.bundlebillservtype == "Cable Television + Internet service")
				{
					Console.WriteLine("Your Current Service Charge is: $" + customer1.CableandInterServCharge().ToString("F2"));
				}
				else if(customer1.bundlebillservtype == "Digital Landline + Internet service")
				{
					Console.WriteLine("Your Current Service Charge is: $" + customer1.DigiLineandInternetServCharge().ToString("F2"));
				}
				else if(customer1.bundlebillservtype == "Cable Television + Digital Landline + Internet service")
				{
					Console.WriteLine("Your Current Service Charge is: $" + customer1.Cable_DigiLine_andInternetServCharge().ToString("F2"));
				}
				

				Console.WriteLine("Your Early Payment Discount is: $" + customer1.varearlyPaymtDiscount.ToString("F2"));
				Console.WriteLine("Your Late Payment Fee is: $" + customer1.varlatePaymtFees.ToString("F2"));
				Console.WriteLine("Your Total Current Charges are (Serv charge + Balance brought (+-) Discount/Fee: $" + customer1.vartotAmtDueBefTax.ToString("F2"));
				Console.WriteLine("Your GCT is @25%: $" + customer1.GCTamt.ToString("F2"));
				Console.WriteLine("Your Total Amount Due is: $" + customer1.vartotAmtDue.ToString("F2"));
				Console.WriteLine();
				Console.WriteLine("Your Previous Due Date is: " + customer1.previousDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Previous Payment Date is: " + customer1.previousPaymtDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Your Current Payment Date is: " + customer1.currentPaymtDueDate.ToString("MM/dd/yyyy") + "");
				Console.WriteLine("Thank you for you for choosing Timbuktu !");




				/*customer1.totAmtDuteBefTax();
				Console.WriteLine(customer1.vartotAmtDueBefTax);
				Console.WriteLine(customer1.vartotAmtDue);
                Console.WriteLine(customer1.fCTandDLcharge);
				*/



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


