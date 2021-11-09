using DllTwo;
using System;
using System.Reflection;

namespace ShowCase
{
    /// <summary>
    /// 数据类型转换
    /// </summary>
    internal class AsIs
    {
        /// <summary>
        /// 常量，除了不可更改，只能用调用静态变量的方式调用
        /// </summary>
        private const int a = 1;

        public static void TwoStatic()
        {
            Console.WriteLine(a);
        }

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
            Console.WriteLine("......................");
            Console.WriteLine(a);
            Console.WriteLine(new Class1().getName());
            Console.WriteLine("======================");
        }

        internal void RefOut()
        {
            Console.WriteLine(new PropertyTry().Name);
        }

        /// <summary>
        /// 数据类型转换
        /// </summary>
        private void ShuJvLeiXingZhuanHuan()
        {
            // 隐式数据转换
            int sa = 1;
            double sd = sa;
            Console.WriteLine(sd);
            // 显示数据类型转换
            double sdd = 12.435;
            int cac = (int)sdd;
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

    /// <summary>
    /// 一个完整的类
    /// </summary>
    internal class Book
    {
        public Book()
        {
        }

        public Book(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        public Book(string name, double price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public readonly string readS = "redaonly";

        public string ReadS
        {
            get => this.readS;
            // 针对readonly字段，在属性中不可以用set访问器
            init => this.readS = value;
        }

        /// <summary>
        /// init only setter,只能在构造函数和初始化器中被设置，在其余时间为只读属性
        /// </summary>
        public int InitC { get; init; } = 12;

        public string Name { get; set; } = "老人与海";

        public double Price { get; set; } = 13.46;

        internal void TT()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            //var book = new Book();
            //var type = book.GetType();
            //PropertyInfo[] propertyInfos = type.GetProperties();
            //foreach (var item in propertyInfos)
            //{
            //    //Console.WriteLine(item.GetType());
            //    Console.WriteLine(item.GetValue(book));
            //}
            return $"Name\t{Name}\nPrice\t{Price}\nInitC\t{InitC}\nReads\t{ReadS}";
            //return base.ToString();
        }
    }

    /// <summary>
    /// 运算符
    /// </summary>
    internal class Operator
    {
        /// <summary>
        /// lambda的委托方法
        /// </summary>
        /// <returns>平方</returns>
        public Func<int, int> IntPow = x => x * x;

        internal readonly int? dd;

        /// <summary>
        /// 没有参数的lambda
        /// </summary>
        public void LambadaNoParameter() => Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);

        /// <summary>
        /// lambda 表达式
        /// </summary>
        /// <param name="x">参数x</param>
        /// <returns>平方</returns>
        public int LambdaTry(int x) => x * x;

        /// <summary>
        /// ?? 和？
        /// </summary>
        public void QuesttionMode()
        {
            // ??原理
            #region
            /*
             如果左操作数的值不为 null，则 null 合并运算符 ?? 返回该值；否则，它会计算右操作数并返回其结果。
            ?的意思是可以为null
             */
            #endregion
            int? c = null; //默认值是null
            int? d = 12;

            Console.WriteLine(c ?? 15);
            Console.WriteLine(d ?? 34);
            Console.WriteLine(c ??= 12);
            Console.WriteLine(dd);
            // 运算结果
            #region
            /*
             15
             12
             12

            */
            #endregion
        }

        /// <summary>
        /// is 和 as 的区别辨析
        /// </summary>
        internal void IsAs()
        {
            //as 和 is的就是返回值的区别,is返回true或者false，os如果符合就直接返回结果。不符合就返回null
            object demoString = "Hello world";
            object demoStringInt = "123";
            object demoInt = 124;
            int? @null = null;
            Console.WriteLine($"demoString is string\t{demoString is string}");
            Console.WriteLine($"demoStringInt is int\t{demoStringInt is int}");
            Console.WriteLine($"demoInt is demoInt\t{demoInt is int}");
            try
            #region
            {
                string ASDemoString = demoString as string;
                Console.WriteLine(ASDemoString.GetType());
                Console.WriteLine(demoString as string);
                Console.WriteLine(demoStringInt as int? ?? throw new ArgumentNullException(nameof(demoStringInt)));
            }
            #endregion
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //运行结果
            #region
            /*
             demoString is string    True
             demoStringInt is int    False
             demoInt is demoInt      True
             Hello world
             System.ArgumentNullException: Value cannot be null. (Parameter 'demoStringInt')
                 at ShowCase.Operator.IsAs() in C:\Users\苏月晟\source\repos\Solution1\ShowCase\AsIs.cs:line 213
             */
            #endregion
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

    /// <summary>
    /// 属性，get和set
    /// </summary>
    internal class PropertyTry
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

        internal void ReClass()
        {
            var book = new Book();
            Console.WriteLine(book.GetType());
            Console.WriteLine(book);
        }
    }

    internal class A
    {
        private string name;
        internal readonly string sex;

        public A()
        {
        }

        public A(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
    }

    internal struct StructA
    {
        internal readonly string name;
        internal readonly string sex;
        internal int age;
        internal double high;

        public StructA(string sex) : this()
        {
            this.sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        internal readonly string Name { get; init; }

        public readonly string sum(string name, string sex) => $"{name}\t{sex}";
    }

    /// <summary>
    /// 只读结构
    /// </summary>
    internal readonly struct StructBReadOnly
    {
        // 字段必须使只读
        internal readonly string _name;

        // 属性必须使init
        internal string Name { get; init; }

        public override string ToString()
        {
            return base.ToString();
        }

        // 默认是只读，不能被本结构中非readonly的成员调用。
        internal void Hello()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }

    /// <summary>
    /// 检验效果
    /// </summary>
    internal class Testt
    {
        public Testt()
        {
            One();
            Console.WriteLine("------------------------");
            Two();
            Console.WriteLine("-------------------------");
            Console.WriteLine(nameof(Three));
            Three();
            Console.WriteLine("-------------------------");
            Four();
            Console.WriteLine("-------------------------");
            Six();
        }

        /// <summary>
        /// 通过构造函数来访问
        /// </summary>
        internal void One()
        {
            Book book = new Book("123", 12.4);
            Console.WriteLine(book);
        }

        /// <summary>
        /// 调用 init only setter
        /// </summary>
        internal void Three()
        {
            Book book = new Book()
            {
                // InitC 只能从构造函数或者启动器里面设置，因为他是init only setter
                InitC = 124,
                Name = "1223",
                Price = 13.456,
            };
            Console.WriteLine(book);
        }

        /// <summary>
        /// 通过初始化器来创造实例
        /// </summary>
        internal void Two()
        {
            Book book = new Book()
            {
                Name = "123",
                Price = 12.45
            };
            Console.WriteLine(book);
        }

        /// <summary>
        /// 验证readonly和init的调用
        /// </summary>
        internal void Four()
        {
            Book book = new Book()
            {
                ReadS = "12343",
            };
            Console.WriteLine(book);
            Console.WriteLine(book.ReadS);
            book.TT();
            #region
            // 因为readS为readonly，所以只能在构造器里面定义
            //book.ReadS = "12";
            //book.readS = "1231";
            //如果没有readonly，就可以通过对类的字段进行随意设置了，readonly比private更为严格，readonly所定义的东西只能读
            //或者在构造器设置，或者在init访问器中设置。private只能保证该字段只能被类中的函数调用。
            #endregion
        }

        /// <summary>
        /// 测试结构
        /// </summary>
        internal void Five()
        {
            StructA structA = new StructA()
            {
                age = 12,
                high = 1.76,
                Name = "liu"
            };
        }

        /// <summary>
        /// 测试委托
        /// </summary>
        public static void WeiT()
        {
            Console.WriteLine("Hello 委托");
        }

        /// <summary>
        /// 测试带变量的静态委托
        /// </summary>
        /// <param name="name">需要被打印</param>
        public void WeiT(string name)
        {
            Console.WriteLine(name);
        }

        internal void Six()
        {
            StructBReadOnly structBReadOnly = new StructBReadOnly { Name = "只读结构的属性" };
            structBReadOnly.Hello();
        }
    }
}