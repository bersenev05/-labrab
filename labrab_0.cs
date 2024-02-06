using System.Data;
using System.Runtime.InteropServices;

namespace labrab
{
    public class Program
    {
        public static void Main(string[] args){
            zadanie3();
        }

        public static void zadanie1()
        {
            Console.Write("Введи x1: ");
            int x1 = int.Parse(Console.ReadLine());

            Console.Write("Введи y1: ");
            int y1 = int.Parse(Console.ReadLine());

            Console.Write("Введи x2: ");
            int x2 = int.Parse(Console.ReadLine());


            Console.Write("Введи y2: ");
            int y2 = int.Parse(Console.ReadLine());

            int answerx = (x1 + x2) / 2;
            int answery = (y1 + y2) / 2;

            Console.WriteLine($"Координаты центра отрезка ===> x = {answerx}, y = {answery}");
        }

        public static void zadanie2()
        {
            Console.Write("Введи A: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введи B: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введи C: ");
            int c = int.Parse(Console.ReadLine());

            Console.Write("Введи D: ");
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine();
            List<double> pluslist = [];
            List<double> alllist = [];
            for(int x = 0; x <= 10; x++)
            {
                double y = a * Math.Sqrt(b * x + d) - c * x;
                alllist.Add(y);
                if (y > 0)
                {
                    pluslist.Add(y);
                }
                Console.WriteLine($"При x = {x}, y = {y}");
            }

            Console.WriteLine();
            Console.WriteLine($"сумма всех положительных значений ====> {pluslist.Sum()}");
            Console.WriteLine($"среднее значение функции          ====> {alllist.Sum()/alllist.Count}");
        }

        public static void zadanie3()
        {

            var rabotnik = new Dictionary<string, int> 
            {
                { "ростислав", 23123 },
                { "евгений", 2991321 },
                { "азамат", 22332 },

            };

            List<string> zakazchik =
                [
                    "нурбол",
                    "али",
                    "азамат",
                    "аня рукосуева",
                    "any чурка",
                ];

            List<string> maybeglagol = 
                [
                    "разлетелся",
                    "убился",
                    "переел",
                    "упал",
                    "умер"
                ];

            List<string> maybesuch = [
                "пропеллер",
                "бачок",
                "мозг",
                "кирпич",
                "киркоров"
            ];
            var neispravnosti = new List<Dictionary<string,string>>();

            for (int x = 0; x<10; x++)
            {
                var random = new Random();
                var problem = new Dictionary<string, string>();

                problem["номер заказа"] = x.ToString();
                problem["проблема"] = maybesuch[random.Next(maybesuch.Count)] +" "+ maybeglagol[random.Next(maybesuch.Count)];
                problem["заказчик"] = zakazchik[random.Next(zakazchik.Count)];
                if (rabotnik.Count != 0)
                {
                    int number = random.Next(rabotnik.Count);
                    problem["исполнитель"] = rabotnik.Keys.ToList()[number];
                    problem["номер исполнителя"] = rabotnik[rabotnik.Keys.ToList()[number]].ToString();
                    rabotnik.Remove(problem["исполнитель"]);
                }
                neispravnosti.Add(problem);
            }
            foreach (Dictionary<string, string> problem in neispravnosti)
            {
                Console.WriteLine($"Номер заказа => {problem["номер заказа"]}");
                Console.WriteLine($"Заказчик => {problem["заказчик"]}");
                Console.WriteLine($"Проблема => {problem["проблема"]}");
                if (problem.Keys.Contains("исполнитель"))
                {
                    Console.WriteLine($"Исполнитель => {problem["исполнитель"]}");
                    Console.WriteLine($"Номер исполнителя => {problem["номер исполнителя"]}");
                }
                Console.WriteLine();
            }
        }

    }
}
