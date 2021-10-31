using System;

namespace ShowCase
{
    class AsIs
    {
        /// <summary>
        /// 常量，除了不可更改，只能用调用静态变量的方式调用
        /// </summary>
        const int a = 1;
        //object a = "123";
        public void One(object c)
        {
            string cc = c as string;
            int? cd;
            try
            {
                cd = c as int?;
            }
            catch (Exception e)
            {
                cd = null;
                Console.WriteLine(e);
            }
            // string
            Console.WriteLine("c as string\t{0}", c as string);
            Console.WriteLine(cc.GetType());
            Console.WriteLine("c is string\t{0}", c is string);
            Console.WriteLine((c is string).GetType());

            // int
            Console.WriteLine("c as int?\t{0}", c as int?);
            Console.WriteLine(cd == null);
            Console.WriteLine("c is int\t{0}", c is int);
            Console.WriteLine((c is int).GetType());

            // 类型
        }
        public void Two()
        {
            Console.WriteLine(a);
        }
        public static void TwoStatic()
        {
            Console.WriteLine(a);

        }
        /// <summary>
        /// 数据类型转换
        /// </summary>
        void ShuJvLeiXingZhuanHuan()
        {
            // 隐式数据转换
            int sa = 1;
            double sd = sa;
            Console.WriteLine(sd);
            // 显示数据类型转换
            double sdd = 12.435;
            // 转换为字符串
            Console.WriteLine(sdd.ToString());
            // 数字转换
            Console.WriteLine(((int)sdd).GetType());
            // Parse
            string dp = "12.5";
            double.Parse(dp);
            // Convert 
            Convert.ToInt32(sdd);

        }



    }
}
