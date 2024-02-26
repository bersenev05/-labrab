
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace labrab2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names =
            [
                "нурбол",
                "абзал",
                "али",
                "салум"
            ];


            for (int num = 0; num < 100; num++)
            {

                Random random = new Random();
                List<dynamic> dataList = new List<dynamic>();
                for (int i = 0; i < 10; i++)
                {
                    int rnd = random.Next(100);
                    if (rnd % 100 == 1)
                    {
                        dataList.Add(new NotcomparableClass(rnd, names[random.Next(names.Count)]));
                    }
                    else if (rnd % 100 == 2)
                    {
                        dataList.Add(new UnreadableClass(rnd, names[random.Next(names.Count)]));
                    }
                    else if(true)
                    {
                        dataList.Add(new NormalClass(rnd, names[random.Next(names.Count)]));
                    }
                }

                dynamic[] dataListCopy = new dynamic[10];
                dataList.CopyTo(dataListCopy);
                int rnd2 = random.Next(100);
                if (rnd2 % 10 != 7)
                {
                    if(rnd2%2 == 0)
                    {
                        dataListCopy[random.Next(10)] = new NormalClass(10, "нурбольчик");
                        dataListCopy[random.Next(10)] = new UnreadableClass(10, "нурбольчик");
                        dataListCopy[random.Next(10)] = new NotcomparableClass(10, "нурбольчик");
                    }
                }
                else
                {
                    dataListCopy = new dynamic[5];
                }


                bool truefalse = false;
                if(LenChecker(dataList, dataListCopy))
                {
                    if (AttributeChecker(dataList))
                    {
                        if(typesChecker(dataList, dataListCopy))
                        {
                            if (ValueChecker(dataList, dataListCopy)) 
                            {
                                cprint("===Данные переданы успешно", ConsoleColor.Green);
                                truefalse = true;
                            }
                        }
                    }
                }
                if (!truefalse)
                {
                    cprint("Данные не переданы", ConsoleColor.Red);
                }
                Console.WriteLine();

            }
        }

        public static bool ValueChecker(List<dynamic> firstList, dynamic[] secondList)
        {
            bool truefalse = true; 
            for(int i=0;i<firstList.Count;i++)
            {
                FieldInfo[] firstFields = firstList[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                FieldInfo[] secondFields = secondList[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

                
                for(int val = 0; val<firstFields.Length; val++)
                {
                    dynamic good_val = firstFields[val]?.GetValue(firstList[i]);
                    dynamic bad_val = secondFields[val]?.GetValue(secondList[i]);
                    if(good_val != bad_val)
                    {
                        truefalse = false;
                        cprint($"Неверное значение на позиции {i}. Ожидалось: {good_val}, получено: {bad_val}", ConsoleColor.Red);
                    }
                }
            }
            return truefalse;
        }

        public static bool typesChecker(List<dynamic> firstList, dynamic[] secondList)
        {
            bool truefalse = true;
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i].GetType() != secondList[i].GetType())
                {
                    truefalse = false;
                    cprint($"Есть несовпадение типов на позиции {i}", ConsoleColor.Red);
                }
            }
            if (truefalse)
            {
                cprint("==Все типы данных совпали", ConsoleColor.Green);
            }
            return true;
        }

        public static bool LenChecker(List<dynamic> firstList, dynamic[] secondList) 
        {
            if (firstList.Count == secondList.Length)
            {
                cprint("=Длина совпала", ConsoleColor.Green);
                return true;
            }
            cprint("Длина не совпала", ConsoleColor.Red);
            return false;
        }

        public static bool AttributeChecker(List<dynamic> datalist)
        {
            bool truefalse = true;
            int i = 0;
            foreach (var item in datalist)
            {
                i++;
                Type type = item.GetType();
                object[] attributes = type.GetCustomAttributes(false);

                foreach (var attr in attributes)
                {
                    if (attr is NotComparableAttribute)
                    {
                        cprint($"Найден нечитаемый тип на позиции {i}", ConsoleColor.Red);
                        truefalse = false;

                    }
                    else if (attr is UnreadableAttribute)
                    {
                        cprint($"Данные на позиции {i} не передаются по сети", ConsoleColor.Red);
                        truefalse = false;
                    }

                }
            }
            return truefalse;
        }
        public static void cprint(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}

