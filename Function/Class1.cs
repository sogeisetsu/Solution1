using System;
using System.Collections;

namespace Function
{
    public class Class1
    {
        public string operator0 = " ";

        public Class1()
        {
            Console.WriteLine("Hello World!");

            Hashtable ht = new Hashtable();
            ht.Add("1", "+");
            ht.Add("2", "-");
            ht.Add("3", "*");
            ht.Add("4", "/");
            ht.Add("A", "a");
            Console.WriteLine("this is a calulator\nplease press any number");
            Console.WriteLine("wating for the first number");
            string no1 = Console.ReadLine();
            double number1 = CheckNumber(no1);
            Console.WriteLine("please press the second number");
            double number2 = CheckNumber(Console.ReadLine());
            Console.WriteLine("Press the number to select the corresponding operator");
            Console.WriteLine("1\t+\n2\t-\n3\t*\n4\t/\n");
            operator0 = Console.ReadLine();
            var r = GetR(operator0, number1, number2);

            Console.WriteLine($"{number1}\t{(string)ht[operator0]}\t{number2}={r}");


        }
        static double CheckNumber(string numberString)
        {
            try
            {
                double number = double.Parse(numberString);
                return number;
            }
            catch (Exception)
            {
                Console.WriteLine("i am sorry, this not a number, please try again");
                return CheckNumber(Console.ReadLine());
            }
        }
        double? GetR(string o, double n1, double n2)
        {
            double? r = null;
            switch (o)
            {
                case "1":
                    r = n1 + n2;
                    break;
                case "2":
                    r = n1 - n2;
                    break;
                case "3":
                    r = n1 * n2;
                    break;
                case "4":
                    r = n1 / n2;
                    break;
                default:
                    Console.WriteLine("error，please press again to select operator");
                    operator0 = Console.ReadLine();
                    return GetR(operator0, n1, n2);

            }
            return r;
        }
    }
}
