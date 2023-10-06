using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbuktu_Communications_Limited
{

    public class GeneralBilling
    {
		const int GCT = 25;

		public int accNum { set; get; } = 0;
		public string accHolderName {set; get; } = string.Empty;
		public string accHolderAddress = " ";
        public int serviceType { set; get; } = 0;
        public double previousBalance { set; get; } = 0;
        public double paymtonPrevBal { set; get; } = 0;

        //DateTime currentPaymentDueDate = new DateTime();
		public DateTime currentPaymtDate { get; set; }

		public double balBroughtForward()
        {
            return (previousBalance - paymtonPrevBal);
        }


		public void getAccHolderAddress()
		{
			// Variable to store the address as a single string
			string accHolderAddress;

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


		public double CableTeleOnly = 2050.76;
        public double DigitalLandOnly = 1210.50;
        public double InternetServOnly = 4999.99;

        //Calculation Functions 
        public double CableandDigitalCharge()
        {
            return(CableTeleOnly+(DigitalLandOnly*70/100));
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
        public GeneralBilling() {}


    }
    public class CableTeleBill : GeneralBilling
    {

    }
    public class DigitalLandBill : GeneralBilling
    {

    }
	public class InternetServBill : GeneralBilling
	{

	}


}
