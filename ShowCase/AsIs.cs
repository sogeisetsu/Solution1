using DllTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShowCase
{
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

    internal class A
    {
        internal readonly string sex;
        private string name;

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

        /// <summary>
        /// 调用Dlltwo
        /// </summary>
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
        public readonly string readS = "redaonly";

        public Book()
        {
        }

        public Book(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        public Book(string name, double price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        /// <summary>
        /// init only setter,只能在构造函数和初始化器中被设置，在其余时间为只读属性
        /// </summary>
        public int InitC { get; init; } = 12;

        public string Name { get; set; } = "老人与海";

        public double Price { get; set; } = 13.46;

        public string ReadS
        {
            get => this.readS;
            // 针对readonly字段，在属性中不可以用set访问器
            init => this.readS = value;
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

        internal void TT()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }

    /// <summary>
    /// 运算符
    /// </summary>
    internal class Operator
    {
        #region 普通运算符，is、as、?、？？、lambda、三目

        /// <summary>
        /// lambda的委托方法
        /// </summary>
        /// <returns> 平方 </returns>
        public Func<int, int> IntPow = x => x * x;

        internal readonly int? dd;

        /// <summary>
        /// 没有参数的lambda
        /// </summary>
        public void LambadaNoParameter() => Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);

        /// <summary>
        /// lambda 表达式
        /// </summary>
        /// <param name="x"> 参数x </param>
        /// <returns> 平方 </returns>
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
            //as 和 is的就是返回值的区别,is返回true或者false，as如果符合就直接返回结果。不符合就返回null
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
        /// <param name="day"> 星期对应的数字 </param>
        /// <returns> </returns>
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

        #endregion

        #region 方法参数的关键字 ref、out、in、params

        /// <summary>
        /// 在类中定义类
        /// </summary>
        internal class RefOut
        {
            /// <summary>
            /// 值类型
            /// </summary>
            internal int a = 0;

            /// <summary>
            /// 引用类型
            /// </summary>
            internal Book book1 = new Book();

            public RefOut()
            {
            }

            public RefOut(int a, Book book1)
            {
                this.a = a;
                this.book1 = book1;
            }

            /// <summary>
            /// 检测值类型和引用类型
            /// </summary>
            public void test()
            {
                #region
                //void testt()
                //{
                //    Console.WriteLine("本地函数");
                //}
                //本地函数的lambda实现
                //void testtd() => Console.WriteLine($"hello world");
                #endregion
                Console.WriteLine("原有数据");
                Console.WriteLine("a\t" + a);
                Console.WriteLine("name\t" + book1.Name);
                Console.WriteLine("----------------------");
                Console.WriteLine("修改之后");
                a = 1;
                book1 = new Book();
                book1.Name = $"{MethodBase.GetCurrentMethod().DeclaringType.FullName}";
                Console.WriteLine($"book1\t{book1.Name}");
                Console.WriteLine($"a\t{a}");
                Console.WriteLine("======================");
                Console.WriteLine("在函数中对参数进行普通的传递");
                ChangeRAndO(a, book1);
                Console.WriteLine($"book1\t{book1.Name}");
                Console.WriteLine($"a\t{a}");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("在函数中对参数进行ref关键字传递");
                ChangeRandO(ref a, ref book1);
                Console.WriteLine($"book1\t{book1.Name}");
                Console.WriteLine($"a\t{a}");
                Console.WriteLine("---------------------------");
                Console.WriteLine("在函数中对参数进行out关键字传递");
                ChangeRandOOut(out a, out book1);
                Console.WriteLine($"book1\t{book1.Name}");
                Console.WriteLine($"a\t{a}");
            }

            // TODO 探寻ref和out的不同
            /// <summary>
            /// 测试ref和out关键字的不同
            /// </summary>
            internal void TestDiff()
            {
                int a = 1;
                int b = 0;

                ChangeFiledNotInitForRef(ref a);
                Console.WriteLine($"在函数外部\na\t{a}\nb\t{b}");
                //ChangeFiledNotInitForRef(ref a);
                int aa=12;
                ChangeFiledNotInitForRef(out aa);
                Console.WriteLine($"在函数外部\naa\t{aa}");
                Console.WriteLine("ref 和 out 的区别是ref必须在调用之前赋值，out必须在函数内部赋值");
                ChangeParams(1, 2, 4, 56, 6);
                Console.WriteLine("-=-=-=-=-=-=+++++++++++");
                StartList();
                int inin=12;
                ChangeIn(in inin);
            }

            // TODO 在参数没有初始化的情况下对ref参数进行修改，结果表明ref参数必须在函数外进行了赋值
            /// <summary>
            /// 试图在参数没有初始化的情况下对ref参数进行修改，结果表明ref参数必须在函数外进行了赋值
            /// </summary>
            /// <param name="a"> ref 关键字 值类型 </param>
            /// <param name="b"> 普通值类型 </param>
            private static void ChangeFiledNotInitForRef(ref int a, int b = 0)
            {
                Console.WriteLine("======================");

                Console.WriteLine("在参数没有初始化的情况下对ref参数进行修改，结果表明ref参数必须在函数外进行了赋值");
                a = 12;
                b = 3;
                Console.WriteLine("在函数内部的值");
                Console.WriteLine($"a\t{a}\nb\t{b}");
                #region
                //ParameterInfo[] parameterInfos = MethodBase.GetCurrentMethod().GetParameters();
                //foreach (var item in parameterInfos)
                //{
                //    Console.WriteLine(item.Position);
                //}
                #endregion
                Console.WriteLine("======================");
            }

            // TODO 试图探索out关键字对参数赋值的要求，必须在方法内部进行赋值
            /// <summary>
            /// 试图探索out关键字对参数赋值的要求，必须在方法内部进行赋值
            /// </summary>
            /// <param name="outParam"> 值类型 out关键字 </param>
            private static void ChangeFiledNotInitForRef(out int outParam)
            {
                Console.WriteLine("======================");

                Console.WriteLine("试图探索out关键字对参数赋值的要求，必须在方法内部进行赋值");
                outParam = 0;
                Console.WriteLine($"在函数内部的值\noutParam\t{outParam}");
                Console.WriteLine("======================");
            }

            /// <summary>
            /// 探索in关键字的使用，in关键字必须先初始化，且不能在函数内部进行修改
            /// </summary>
            /// <param name="inParam"> 值类型 </param>
            private static void ChangeIn(in int inParam)
            {
                Console.WriteLine("======================");
                //inParam = 1; 这是错误的，因为in关键字修饰的参数必须不能修改,只能读取
                Console.WriteLine($"传入的参数\t{inParam}");
                Console.WriteLine("======================");
            }

            /// <summary>
            /// 探索参数关键字params。在方法声明中的 params 关键字之后不允许有任何其他参数， 并且在方法声明中只允许有一个 params 关键字。
            /// </summary>
            /// <param name="list"> 数组 </param>
            private static void ChangeParams(params int[] list)
            {
                Console.WriteLine("======================");

                Console.WriteLine(list.GetType());
                // 将arrary转为list类型
                Console.WriteLine(list[1..3]);
                List<int> list1 = list.ToList();
                Console.WriteLine(list1.GetRange(1, 3));
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("======================");
            }

            /// <summary>
            /// 在ref关键字中，对参数进行修改
            /// </summary>
            /// <param name="a"> 值类型 </param>
            /// <param name="book"> 参数类型 </param>
            private static void ChangeRandO(ref int a, ref Book book)
            {
                a = 2;
                book.Name = MethodBase.GetCurrentMethod().Name + "\tref";
            }

            /// <summary>
            /// 在没有ref或者out关键字的情况下，对参数进行修改
            /// </summary>
            /// <param name="a"> 值类型 </param>
            /// <param name="book"> 引用类型 </param>
            private static void ChangeRAndO(int a, Book book)
            {
                a = 2;
                book.Name = MethodBase.GetCurrentMethod().Name;
            }

            /// <summary>
            /// 在out关键字中对参数进行修改
            /// </summary>
            /// <param name="a"> 值类型 </param>
            /// <param name="book"> 参数类型 </param>
            private static void ChangeRandOOut(out int a, out Book book)
            {
                a = 3;
                book = new Book();
                book.Name = MethodBase.GetCurrentMethod().Name + "\tout";
            }

            /// <summary>
            /// 重载方法使用相同的参数个数和类型，但使用不同的方法参数关键字
            /// </summary>
            private class OverLoadFunParamsKeyWords
            {
                // TODO(blog) 在方法重载中只允许有无方法参数关键字的区别，但是不允许用不同的方法参数关键字来区分方法的不同重载
                private static void C(ref int refA)
                {
                }

                private static void C(int regularA)
                {
                }

                // TODO(blog) 顺便说一句，本地函数不能有访问修饰符，不能被重载，不能被方法外的方法调用
            }

            /// <summary>
            /// 调用使用out关键字作为方法参数的修饰的方法的神奇使用技巧
            /// </summary>
            private static void StartList()
            {
                // TODO(blog) 因为调用使用out关键字的方法的时候，被out关键字修饰的参数必须在参数内部进行赋值，所以可以使用“_”来代替参数。
                ChangeFiledNotInitForRef(out _);
                // 上面的调用方式某种程度上来说等于下面这种
                int a = 1;
                ChangeFiledNotInitForRef(out a);
            }
        }

        #endregion

        #region 匿名函数

        /// <summary>
        /// lambda 系统讲解
        /// </summary>
        internal class LambdaTest
        {
            /// <summary>
            /// 委托声明，委托的本质是表示对具有特定参数列表和返回类型的方法的引用
            /// </summary>
            /// <param name="a"> 被委托函数的参数 </param>
            /// <returns> 被委托函数的返回值 </returns>
            internal delegate string TDellegate(int a);

            /// <summary>
            /// 被委托的函数
            /// </summary>
            /// <param name="a"> 参数 </param>
            /// <returns> 返回int类型的string类型 </returns>
            internal string BeDelegate(int a)
            {
                Console.WriteLine("========================");
                Console.WriteLine("这是被委托的函数");
                Console.WriteLine("=========================");
                return a.ToString();
            }

            /// <summary>
            /// =>作为表达式主体定义，没有参数的情况
            /// </summary>
            /// <returns> 重写ToString </returns>
            public override string ToString() => "匿名函数以及运算符=>辨析";

            /// <summary>
            /// =>作为表达式主体定义，有参数的情况
            /// </summary>
            /// <param name="x"> </param>
            internal void MainDefinWithParam(int x) => Console.WriteLine(x + 1);

            #region 无参lambda 使用空括号指定零个输入参数
            Action Action = () => Console.WriteLine("lambda匿名函数，无参，无返回值。action来实现委托");
            Func<string> Func1 = () =>
            {
                Console.WriteLine("lambda匿名函数，无参，又返回值。func来实现委托");
                return "lambda匿名函数，无参，又返回值。func来实现委托";
            };
            #endregion

            // 有参，一个参数
            Func<int, int> Func = x => x + 1;
            // 有参,多个参数
            Action<int, int> Action1 = (a, b) => Console.WriteLine($"{MethodBase.GetCurrentMethod().GetParameters()}");
            // 有参，多个参数，指定参数类型
            Action<int, string> Action2 = (int a, string b) => Console.WriteLine($"{a}\t{b}");


            internal void Test()
            {
                // 进行委托和调用委托
                TDellegate dellegate = BeDelegate;
                dellegate(12);

                //使用委托的匿名函数
                TDellegate dellegateAnonymous = delegate (int a)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("这是使用委托创造的匿名");
                    Console.WriteLine("--------------------------");

                    return "212";
                };
                dellegateAnonymous(a: 12);

                // 这是最建议使用委托的方法
                TDellegate dellegateLambda = x =>
                {
                    Console.WriteLine($"委托和lambda的结合{x}");
                    return "123";
                };
                dellegateLambda(123);

                // Action和Func的使用
                void ActionAndFunc()
                {
                    Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName + "\t" + MethodBase.GetCurrentMethod().Name);
                    // func的泛型中最后一个是返回类型
                    Func<int, string> func = new Func<int, string>(BeDelegate);
                    func(21);
                    // action没有返回值，泛型为参数的值
                    Action<string> actionWrite = new Action<string>(Console.WriteLine);
                    actionWrite("action委托");
                    Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName + "\t" + MethodBase.GetCurrentMethod().Name);
                }

                ActionAndFunc();
            }
        }

        #endregion
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
        /// 测试委托
        /// </summary>
        public static void WeiT()
        {
            Console.WriteLine("Hello 委托");
        }

        /// <summary>
        /// 测试带变量的静态委托
        /// </summary>
        /// <param name="name"> 需要被打印 </param>
        public void WeiT(string name)
        {
            Console.WriteLine(name);
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
        /// 通过构造函数来访问
        /// </summary>
        internal void One()
        {
            Book book = new Book("123", 12.4);
            Console.WriteLine(book);
        }

        internal void Six()
        {
            StructBReadOnly structBReadOnly = new StructBReadOnly { Name = "只读结构的属性" };
            structBReadOnly.Hello();
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
    }
}