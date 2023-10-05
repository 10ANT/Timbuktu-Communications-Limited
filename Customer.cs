using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbuktu_Communications_Limited
{
    //Using properties
    public class Customer:InternetBilling
    {

        public int accNum = 0;
        public string accHolderName = " ";
        public string accHolderAddress = " ";


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
        
























        /* Account number
• Account holder’s name
• Account holder’s address
• Service type
• Previous balance
• Payment on previous balance
• Balance brought forward
• Current service charges
• Early payment discount
• Late payment charges
• Total Current Charges
• General consumption tax (GCT)
• Total amount due
• Previous due date
• Previous payment date
• Current payment due date*/

    }
}
