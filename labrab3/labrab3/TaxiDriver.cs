using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab3
{
    public delegate void NotificationOfDriver(ArgsOfTaxiDriver driversArgs);

    public class TaxiDriver
    {

        public string Name;
        public (double, double) CurrentLocation;
        public double Ball;
        public bool Free;
        public Car Car;
        public event NotificationOfDriver RespondedToOrder;

        public TaxiDriver(string Name, (double, double) CurrentLocation, double Ball, bool Free, Car Car)
        {
            this.Name = Name;
            this.CurrentLocation = CurrentLocation;
            this.Ball = Ball;
            this.Free = Free;
            this.Car = Car;
        }

        public void GoToOrder(ArgsOfTaxiOrder order)
        {
            double distance = TechClass.distanceCounter(CurrentLocation, order.Order.Departure.Coordinates);
            string childSeat = Car.ChildSeat ? "Есть детское кресло" : "Нет детского кресла";

            bool truefalse = true;

            TechClass.cprint($"{Name}, балл {Ball}, {Car.Brand} {Car.Number}, {childSeat}, {distance} км от вас", ConsoleColor.Yellow);
            if (Free)
            {

                if (order.Order.ChildSeat == Car.ChildSeat)
                {
                    if(distance < 10)
                    {
                        Random random = new Random();
                        bool yesOrNo = random.Next(10)%2 == 0 ? true : false;
                       
                        TechClass.cprint($"Водитель подходит", ConsoleColor.Green);

                        if (yesOrNo)
                        {
                            RespondedToOrder(new ArgsOfTaxiDriver(this));
                            TechClass.cprint("Водитель согласился на поездку", ConsoleColor.Green);
                            Console.WriteLine();
                            return;
                        }

                        TechClass.cprint("Водитель не согласился на поездку", ConsoleColor.Red);
                        Console.WriteLine();

                        return;

                    }
                }
            }
            TechClass.cprint($"Водитель не подходит", ConsoleColor.Red);
            Console.WriteLine();
        }

    }

    public class Car
    {
        public string Number;
        public string Brand;
        public bool ChildSeat;

        public Car(string Number, string Brand, bool ChildSeat)
        {
            this .Number = Number;
            this .Brand = Brand;
            this .ChildSeat = ChildSeat;
        }
    }

    public class ArgsOfTaxiDriver : EventArgs
    {
        public TaxiDriver TaxiDriver;

        public ArgsOfTaxiDriver(TaxiDriver driver)
        {
            this.TaxiDriver = driver;
        }

    }

    public class ArgsOfTaxiOrder : EventArgs
    {
        public Order Order;
        public TaxiAgregator Agregator;

        public ArgsOfTaxiOrder(Order order, TaxiAgregator agregator)
        {
            this.Order = order;
            this.Agregator = agregator;
        }
    }
}
