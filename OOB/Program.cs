using System;
using System.Collections.Generic;

namespace OOB
{
    /// <summary>
    /// 定义了方法
    /// </summary>
    internal class Program
    {
        private static void Hi(ref int a, List<string> list)
        {
            if (a != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                    if (i % 2 == 0)
                    {
                        list.Add(list[i] + "a");
                    }
                    else
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            else
            {
                Console.WriteLine(a);
            }
        }

        /// <summary>
        /// 主方法
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> listA = new() { "123", "你好", "<name>", "hahah" };
            int a = 12;
            Hi(ref a, listA);
        }
    }
}