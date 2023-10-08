using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Timbuktu_Communications_Limited
{

    public class GeneralBilling
    {
		//Testing Vars
		public double fCTandDLcharge =7;

		public const double GCT = 0.25;
		
		public double bundlebillservcharge { set; get; }
		public string bundlebillservtype { set; get; }


		public string accNum { set; get; } = " ";
		public string accHolderName {set; get; } = string.Empty;
		// Variable to store the address as a single string
		public string accHolderAddress = " ";
        public int serviceType { set; get; } = 0;
        public static double previousBalance { set; get; } = 0;
        public static double paymtonPrevBal { set; get; } = 0;

		public double	GCTamt = 0;

		public double altprevBal = 0;
		public double altpaymtonPrevBal = 0;

		public  string accFirst_Lastconcat { set; get; } = string.Empty;

		//DateTime currentPaymentDueDate = new DateTime();
		public DateTime currentPaymtDueDate { get; set; }
		public DateTime previousPaymtDate { get; set; }
		public DateTime previousDueDate { get; set; }


		//bundele bill selector so i can be inherited and overidded
		public virtual void bundlebillselector()
		{

		}
		//
		public void collectPreviousBalandPayment()
		{
            Console.Write("\nWhat is your Previous Balance: $");
			previousBalance =Convert.ToDouble(Console.ReadLine());

			Console.Write("What is your Payment on the Previous Balance: $");
			paymtonPrevBal = Convert.ToDouble(Console.ReadLine());

			altprevBal = previousBalance;
		    altpaymtonPrevBal = paymtonPrevBal;
	}


		

        public double varBalBroughtForward { set; get; }
		public double vartotAmtDueBefTax = 0;
		public double vartotAmtDue { set; get; }


		public double varlatePaymtFees;

		public double varearlyPaymtDiscount;

		public void balBroughtForward()
		{
			varBalBroughtForward = (previousBalance - paymtonPrevBal);
		}
		public void getAccHolderDetails()
		{
           

			// Prompt the user to enter their  details
			Console.WriteLine("Please Enter your Account Details:");
			Console.WriteLine();
			Console.Write("Your Account Number: ");
		    accNum = Console.ReadLine(); 
			Console.Write("Your Account Holder Name (Enter First Name then Last Name): ");
			string accHoldernameFirst = Console.ReadLine();
			string accHoldernameLast = Console.ReadLine();

            Console.WriteLine();


            // Combine the address components into a single string
            accFirst_Lastconcat = $"{accHoldernameFirst} {accHoldernameLast}";

		}

		public void getAccHolderAddress()
		{
			
			

			// Prompt the user to enter the address details
			Console.WriteLine("Enter Address Details:");
			Console.Write("Street: ");
			string street = Console.ReadLine();
			Console.Write("City: ");
			string city = Console.ReadLine();
			Console.Write("Parish: ");
			string parish = Console.ReadLine();
			Console.Write("Postal Code: ");
			string postalCode = Console.ReadLine();

			// Combine the address components into a single string
			 accHolderAddress = $"{street}, {city}, {parish} {postalCode}";


		}
		public void latePaymtFees()
		{
			if (previousDueDate < previousPaymtDate)
			{
				varlatePaymtFees= 250.0;
			}
			else
			{
				varlatePaymtFees = 0.0;
			}
		}
		public void earlyPaymtDiscount()
		{

			if (previousPaymtDate < previousDueDate)
			{
				varearlyPaymtDiscount = 250.0;
			}
			else
			{
				varearlyPaymtDiscount = 0.0;
			}
		}

		public void lateorearlystatus()
		{
			if (varlatePaymtFees == 250.0)
			{
				Console.WriteLine("\nPayment made after or on the due date. Late payment fees applied...");
			}
			else if (varlatePaymtFees == 0)
			{
				Console.WriteLine("\nPayment made before the due date. No Late payment fees applied.");
			}
			if (varearlyPaymtDiscount == 250)
			{
				Console.WriteLine("\n\x1b[1mApplying early payment discount... \x1b[0m");
			}
			else if (varearlyPaymtDiscount == 0)
			{
				Console.WriteLine("\n\x1b[1mNo early payment discount applied.\x1b[0m");
			}
		}
			
		//servcharge
		public double servcharge { set; get; }

		public virtual void totAmtDuteBefTax(double servcharge)
        {
            vartotAmtDueBefTax= ((servcharge + varBalBroughtForward ) + varlatePaymtFees - varearlyPaymtDiscount);
        }
		//this one is to for overide of derived classes its no parameterized
		public virtual void totAmtDuteBefTax()
		{
			vartotAmtDueBefTax = ((servcharge + varBalBroughtForward) + varlatePaymtFees - varearlyPaymtDiscount);
		}

		public double totAmountDue()
		{
			//GCT percentage Calculation
			GCTamt = (vartotAmtDueBefTax * GCT);
			return (vartotAmtDueBefTax - (vartotAmtDueBefTax * GCT));
		}
		//CHECK IF LOGIC WORKS OUT
		

		public double CableTeleOnly = 2050.76;
        public double DigitalLandOnly = 1210.50;
        public double InternetServOnly = 4999.99;

        //Calculation Functions 
        public double CableandDigitalCharge()
        {
            return (CableTeleOnly+(DigitalLandOnly*70/100));
        }
        public double CableandInterServCharge()
        {
            return (CableTeleOnly + (InternetServOnly * 80 / 100));
        }
        public double DigiLineandInternetServCharge()
        {
           
            return (DigitalLandOnly + (InternetServOnly * 90 / 100));
        }
        public double Cable_DigiLine_andInternetServCharge()
        {
            return (CableTeleOnly + DigitalLandOnly + (InternetServOnly * 70 / 100));
        }


        public GeneralBilling(double ctonly, double dlonly,double intServonly) {
            this.CableTeleOnly = ctonly;
            this.DigitalLandOnly = dlonly;
            this.InternetServOnly = intServonly;

        }
        public GeneralBilling() {

		}


	}
    public class CableTeleBill : GeneralBilling
    {
		public double fcabtelecharge { set; get; }

		public override void totAmtDuteBefTax()
		{
			vartotAmtDueBefTax = ((CableTeleOnly + varBalBroughtForward) + varlatePaymtFees - varearlyPaymtDiscount);
			fcabtelecharge = totAmountDue();
			vartotAmtDue = totAmountDue();
		}
		

	}
	public class DigitalLandBill : GeneralBilling
    {
		public double fdigitallandcharge { set; get; }

		public override void totAmtDuteBefTax()
		{
			vartotAmtDueBefTax = ((DigitalLandOnly + varBalBroughtForward) + varlatePaymtFees - varearlyPaymtDiscount);
			fdigitallandcharge = totAmountDue();
			vartotAmtDue = totAmountDue();
		}
	}
	public class InternetServBill : GeneralBilling
	{
		public double finternetservcharge { set; get; }

		public override void totAmtDuteBefTax()
		{
			vartotAmtDueBefTax = ((InternetServOnly + varBalBroughtForward) + varlatePaymtFees - varearlyPaymtDiscount);
			finternetservcharge = totAmountDue();
			vartotAmtDue = totAmountDue();
		}

	}
	public class BundledBill:GeneralBilling
	{
		
		public override void bundlebillselector()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine(" Bundle Bill Menu:");
				Console.WriteLine("1. Cable Television + Digital Landline");
				Console.WriteLine("2. Cable Television + Internet service ");
				Console.WriteLine("3. Digital Landline + Internet service");
				Console.WriteLine("4. Cable Television + Digital Landline + Internet service");
				Console.WriteLine("5. Exit");

				Console.Write("Enter your choice: ");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.WriteLine("\nYou selected Option 1. Cable Television + Digital Landline");
						// Perform action for Option 1
						//settings a varible to dual serv charge
						bundlebillservcharge = CableandDigitalCharge();
						//sets Service type name
						bundlebillservtype = "Cable Television + Digital Landline";


						break;
					case "2":
						Console.WriteLine("\nYou selected Option 2.Cable Television + Internet service");
						// Perform action for Option 2
						//settings a varib;le to dual serv charge
						bundlebillservcharge = CableandInterServCharge();
						//sets Service type name
						bundlebillservtype = "Cable Television + Internet service";

						break;
					case "3":
						Console.WriteLine("\nYou selected Option 3.Digital Landline + Internet service");
						// Perform action for Option 3
						//settings a varible to dual serv charge
						bundlebillservcharge = DigiLineandInternetServCharge();
						//sets Service type name
						bundlebillservtype = "Digital Landline + Internet service";

						break;
					case "4":
						Console.WriteLine("\nYou selected Option 4. Cable Television + Digital Landline + Internet service");
						// Perform action for Option 4
						//settings a varib;le to dual serv charge
						bundlebillservcharge = Cable_DigiLine_andInternetServCharge();
						//sets Service type name
						bundlebillservtype = "Cable Television + Digital Landline + Internet service";

						break;
					case "5":
						Console.WriteLine("Exiting program.");
						return;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}

				Console.WriteLine("\nPress any key to continue...");
				Console.ReadKey();
				break;
			}

		}
		public override void totAmtDuteBefTax(double bundleservc)
		{
			vartotAmtDueBefTax = ((bundleservc + varBalBroughtForward) + varlatePaymtFees - varearlyPaymtDiscount);
			vartotAmtDue = totAmountDue();
		}


	}


}
