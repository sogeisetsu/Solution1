using System;
using System.Collections;

namespace Function
{
    public class Class1
    {
        public string operator0 = " ";
        public double? yu = null;
        /// <summary>
        /// 构造函数，创建示例即创建了一个计算器
        /// </summary>
        public Class1()
        {
            //Console.WriteLine("Hello World!");

            Hashtable ht = new();
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
            if (yu != null && yu != 0)
            {
                Console.WriteLine($"{number1}\t{(string)ht[operator0]}\t{number2}={r}……{yu}");
                return;
            }

            Console.WriteLine($"{number1}\t{(string)ht[operator0]}\t{number2}={r}");


        }
        /// <summary>
        /// 检查是否为数字，并且通过递归函数要求直到输入数字为止
        /// </summary>
        /// <param name="numberString">用户输入的值</param>
        /// <returns>将输入的字符转为数字</returns>
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        /// <summary>
        /// 获取运算结果
        /// </summary>
        /// <param name="o">运算符所对应的数字的字符串形式</param>
        /// <param name="n1">第一个数字</param>
        /// <param name="n2">第二个数字</param>
        /// <returns>运算结果</returns>
        double? GetR(string o, double n1, double n2)
        {
            double? r;
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
                    yu = n1 % n2;
                    if (yu == 0)
                    {
                        r = n1 / n2;
                        break;
                    }
                    else
                    {
                        r = (int)n1 / n2;
                        break;
                    }

                default:
                    Console.WriteLine("error，please press again to select operator");
                    operator0 = Console.ReadLine();
                    return GetR(operator0, n1, n2);

            }
            return r;
        }
    }
}
