using System;

namespace Format
{
    public class FormatOne
    {
        public FormatOne() => Console.WriteLine("字符串格式化");

        /// <summary>
        /// 字符串格式化
        /// </summary>
        public static void Format()
        {
            string a = "hello world";
            string c = "hello world";
            // 首字母大写
            string b = a.Substring(0, 1).ToUpper() + a[1..];
            Console.WriteLine($"首字母大写\t{b}");
            Console.WriteLine("比较");
            Console.WriteLine(a.Equals("hello world"));// 返回 true or false
            Console.WriteLine(a.CompareTo("hello world"));// 0 or 1
            Console.WriteLine(a == c);// true or false
            Console.WriteLine(a.GetType());
            Type type = typeof(int);
            Console.WriteLine(type.GetType());
            //两种字符转内插
            Console.WriteLine($"{a}\t{b}\t{c}");
            Console.WriteLine(String.Format("{0}1122{1}", a, b));
            Console.WriteLine("{0}\t{1}", a, b);
            Console.WriteLine("@可以无视转义符");
            Console.WriteLine("\\a\\f");
            Console.WriteLine(@"\\a\\f");
            // index
            Console.WriteLine(a.IndexOf("o"));
            //Console.WriteLine(a)
            Console.WriteLine("验证代码开头");
            a = "**ss**";
            Console.WriteLine(a.StartsWith("**"));
            Console.WriteLine("验证包含");
            Console.WriteLine(a.Contains("s"));
            Console.WriteLine("字符数字转换");
            // string to number
            Console.WriteLine(int.Parse("12").GetType());
            // number to string
            Console.WriteLine(123.4.ToString().GetType());
        }
    }
}