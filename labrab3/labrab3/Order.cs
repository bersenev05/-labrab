using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab3
{
    public class Address
    {
        public (double, double) Coordinates;
        public string Street;
        public int House;

        public Address((double, double) Coordinates, string Street, int House)
        {
            this.Street = Street;
            this.House = House; 
            this.Coordinates = Coordinates;
        }
    }

    public class Order
    {
        public Customer Customer;
        public Address Destination;
        public Address Departure;
        public bool ChildSeat;
        public double Distance;

        public Order(Customer Customer, Address Departure, Address Destination, bool ChildSeat, double Distance)
        {
            this.Destination = Destination;
            this.Departure = Departure; 
            this.Distance = Distance;   
            this.ChildSeat = ChildSeat;
            this.Customer = Customer;
        }
    }
}
