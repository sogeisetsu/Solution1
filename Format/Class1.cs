using System;

namespace Format
{
    public class FormatOne
    {
        public FormatOne() {
            Console.WriteLine("字符串格式化");
        }
        /// <summary>
        /// 字符串格式化
        /// </summary>
        public static void Format()
        {
            string a = "hello world";
            string c = "hello world";
            string b = a.Substring(0, 1).ToUpper() + a.Substring(1);
            Console.WriteLine($"首字母大写\t{b}");
            Console.WriteLine("比较");
            Console.WriteLine(a.Equals("hello world"));
            Console.WriteLine(a.CompareTo("hello world"));
            Console.WriteLine(a == c);
            Console.WriteLine(a.GetType());
            Type type = typeof(int);
            Console.WriteLine(type.GetType());
            //两种字符转内插
            Console.WriteLine($"{a}\t{b}\t{c}");
            Console.WriteLine("@可以无视转义符");
            Console.WriteLine("\\a\\f");
            Console.WriteLine(@"\\a\\f");
        }
    }
}
