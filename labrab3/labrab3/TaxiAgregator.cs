using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labrab3
{
    public class TechClass
    {
        public static void cprint(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void ccprint(string text, ConsoleColor color, ConsoleColor color2)
        {
            Console.BackgroundColor = color2;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }


        public static double distanceCounter((double, double) departureCoordinates, (double, double) destinationCoordinates)
        {
            double distance = Math.Sqrt(Math.Pow((departureCoordinates.Item1 - destinationCoordinates.Item1), 2) + Math.Pow((departureCoordinates.Item2 - destinationCoordinates.Item2), 2));
            return Math.Round(distance);
        }
    }

    public class TaxiAgregator
    {
        public List<Customer> customers = [];
        public List<TaxiDriver> taxiDrivers = [];
        public List<TaxiDriver> taxiDriversTemp = [];

        public void AddNewTaxiDriver(TaxiDriver driver) 
        {
            taxiDrivers.Add(driver);
            driver.RespondedToOrder += AddReadyDriverInTempList;
        }
        public void RemoveTaxiDriver(TaxiDriver driver) 
        { 
            taxiDrivers.Remove(driver);
            driver.RespondedToOrder -= AddReadyDriverInTempList;
        }

        public void FindBestDriver() 
        {
            if (taxiDriversTemp.Count > 0)
            {
                TaxiDriver best = taxiDriversTemp[0];
                foreach (TaxiDriver driver in taxiDriversTemp)
                {
                    if (driver.Ball > best.Ball)
                    {
                        best = driver;
                    }

                }
                TechClass.ccprint($"Водитель найден! К вам едет {best.Name}, {best.Car.Brand} {best.Car.Number}", ConsoleColor.White, ConsoleColor.DarkGreen);
                return;

            }
            TechClass.cprint("Сейчас все водители заняты, извините", ConsoleColor.Red);

        }

        public void AddReadyDriverInTempList(ArgsOfTaxiDriver driverArgs)
        {
            taxiDriversTemp.Add(driverArgs.TaxiDriver);
        }

        public void DeleteReadyDriverInTempList(TaxiDriver driver)
        {
            taxiDriversTemp.Remove(driver);
        }



        public string CreateAnOrder(Customer customer, Address departure, Address destination, bool ChildSeat)
        {
            double distance = TechClass.distanceCounter(departure.Coordinates, destination.Coordinates);

            Order order = new Order(
                Customer: customer,
                Departure: departure,
                Destination: destination,
                ChildSeat: ChildSeat,
                Distance: distance
                );

            string from = departure.Street + departure.House;
            string to = destination.Street + destination.House;

            string childSeat = ChildSeat ? "Нужно детское кресло" : "Без детского кресла"; 

            TechClass.ccprint($"{customer.Name} сделал заказ. {from} ==> {to} ({distance} км), {childSeat}", ConsoleColor.White, ConsoleColor.DarkGreen);
            TechClass.cprint("----------------------------------------------------------------------------", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine();

            if (customer.ordersCount == 0)
            {
                foreach (TaxiDriver driver in taxiDrivers)
                {
                    customer.IWantToTakeATaxi += driver.GoToOrder;
                }
            }
            
            customer.ordersCount++;
            customer.tempOrder = order;
            customer.TakeATaxi();

            Console.WriteLine();
            TechClass.cprint("-----------------------------------------------------------------------------", ConsoleColor.Green);
            FindBestDriver();
            return "заказ создан";
        }



    }
}
