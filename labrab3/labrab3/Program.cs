using System.Security.Cryptography.X509Certificates;

namespace labrab3
{
    class Program
    {
        public static List<string> names = 
            [
                "Нурбол",
                "Абдула",
                "Хабиб",
                "Хасбула",
                "Дилдорбек",
                "Нурболайзер",
                "Болболнур"
            ];

        static void Main(string[] args)
        {
            TaxiAgregator Yandex = new TaxiAgregator();

            Customer Ivan = new Customer(Name: "Иван", agregator: Yandex);
            CreateTaxiDrivers(Yandex);

            Yandex.CreateAnOrder(
                Ivan, 
                new Address((0, 0), "Алексеева", 33),
                new Address((1, 1), "Алексеева", 34),
                true
                );
        }

        static void CreateTaxiDrivers(TaxiAgregator agregator)
        {
            Random random = new Random();

            for(int i = 0; i<10; i++)
            {
                string name = names[random.Next(names.Count)];
                bool ChildSeat = random.Next(100) % 2 == 0 ? true : false;

                agregator.AddNewTaxiDriver(
                    new TaxiDriver(
                        Name: name,
                        CurrentLocation: (random.Next(10), random.Next(8)),
                        Ball: (double) random.Next(30,50) / 10,
                        Free: true,
                        Car: new Car(
                            Number: $"о{random.Next(100,1000)}оо{random.Next(100, 1000)}",
                            Brand: "Toyota", 
                            ChildSeat: ChildSeat
                            ) 
                    )
                ); 
            }
        }
        
    }
}