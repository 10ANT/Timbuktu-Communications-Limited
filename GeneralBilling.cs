using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timbuktu_Communications_Limited
{

    public class GeneralBilling
    {
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
}
