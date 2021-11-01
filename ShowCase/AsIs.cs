using System;
using System.Reflection;

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
            /*
                c as string     123
                System.String
                c is string     True
                System.Boolean
                c as int?
                True
                c is int        False
                System.Boolean*/

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
        internal void RefOut()
        {
            Console.WriteLine(new PropertyTry().Name);

        }
    }

    class PropertyTry
    {
        public PropertyTry()
        {
        }

        public PropertyTry(string name) => this.Name = name ?? throw new ArgumentNullException(nameof(name));

        public string Name { get; set; } = "Hello world";

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
            return "测试属性和变量";
        }
    }

    class Operator
    {
        internal readonly int? dd;
        /// <summary>
        /// lambda 表达式
        /// </summary>
        /// <param name="x">参数x</param>
        /// <returns>平方</returns>
        public int LambdaTry(int x) => x * x;

        /// <summary>
        /// 没有参数的lambda
        /// </summary>
        public void LambadaNoParameter() => Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);

        /// <summary>
        /// ?? 和？
        /// </summary>
        public void QuesttionMode()
        {
            int? c = null; //默认值是null
            int? d = 12;

            Console.WriteLine(c ?? 15);
            Console.WriteLine(d ?? 34);
            Console.WriteLine(c ??= 12);
            Console.WriteLine(dd);
        }

        /// <summary>
        /// is as
        /// </summary>
        /// <param name="c"></param>
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
            /*
                c as string     123
                System.String
                c is string     True
                System.Boolean
                c as int?
                True
                c is int        False
                System.Boolean*/

            // 类型
        }

        /// <summary>
        /// 三目运算
        /// </summary>
        /// <param name="day">星期对应的数字</param>
        /// <returns></returns>
        internal int ThreeEye(int day)
        {
            // 初级写法
            int x = 12;
            int cc = x == 12 ? 3 : 4;
            // 复杂写法
            string weekDay = day == 0 ? "日" : day == 1 ? "1" : day == 2 ? "2" : day == 3 ? "3" : day == 4 ? "4" : day == 5 ? "5" : day == 6 ? "6" : "error";
            Console.WriteLine(weekDay);
            return cc;
        }

    }
}
