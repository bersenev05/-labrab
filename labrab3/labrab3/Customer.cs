using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab3
{
    public delegate void NotificationOfCustomer(ArgsOfTaxiOrder order);

    public class Customer
    {

        public string Name;
        public Order tempOrder;
        public event NotificationOfCustomer IWantToTakeATaxi;
        public int ordersCount = 0;
        public TaxiAgregator agregator;

        public Customer(string Name, TaxiAgregator agregator) 
        { 
            this.Name = Name;
            this.agregator = agregator;
            downloadAgregator();
        }

        public void downloadAgregator()
        {
            agregator.customers.Add(this);
        }


        public void TakeATaxi()
        {
            if(IWantToTakeATaxi != null)
            {
                IWantToTakeATaxi(new ArgsOfTaxiOrder(tempOrder, agregator));
            }
        }

    }
}
