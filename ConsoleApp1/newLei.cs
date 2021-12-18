using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ConsoleApp1
{
    public delegate void WTuo();

    /// <summary>
    /// 对json进行操作的拓展方法
    /// </summary>
    public static class JsonDocumentExtensions
    {
        /// <summary>
        /// 将JsonDocument转为格式化过的字符串
        /// </summary>
        /// <param name="jsonDocument"> </param>
        /// <returns> 格式化过的字符串 </returns>
        internal static string JDFormatToString(this JsonDocument jsonDocument)
        {
            return JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });
        }

        /// <summary>
        /// 将json字符串转为格式化过的字符串
        /// </summary>
        /// <param name="str"> </param>
        /// <returns> 格式化过的字符串 </returns>
        internal static string TOJsonString(this string str)
        {
            using (JsonDocument jsonDocument = JsonDocument.Parse(str))
            {
                return JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
            }
        }
    }

    /// <summary>
    /// 为string类型增加拓展方法
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 将string类型转为arrarylist，并且在结尾加上一个整数a
        /// </summary>
        /// <param name="str"> 要被操作的字符串 </param>
        /// <param name="a"> 需要加在结尾的整数 </param>
        /// <returns> arrayList集合 </returns>
        internal static ArrayList GetArrayList(this string str, int a)
        {
            string[] strings = new string[str.Length + 1];
            for (int i = 0; i < str.Length; i++)
            {
                strings[i] = str.Substring(i, 1);
            }
            strings[str.Length] = a.ToString();
            ArrayList arrayList = new(strings);
            return arrayList;
        }

        /// <summary>
        /// demo，试图获取string实例化对象长度的两倍
        /// </summary>
        /// <param name="str"> 此方法的第一个参数指定方法所操作的类型；此参数前面必须加上 this 修饰符。 </param>
        /// <returns> 原来长度的两倍 </returns>
        internal static int GetTheDoubleLength(this string str)
        {
            return str.Length * 2;
        }
    }

    /// <summary>
    /// 用于测试的类
    /// </summary>
    public class BookA
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonInclude]
        public long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        private string _author;

        private string _outCompany;

        private DateTime _time = DateTime.Now;

        public BookA()
        {
        }

        /// <summary>
        /// 定义书的基本信息
        /// </summary>
        /// <param name="name"> 书名 </param>
        /// <param name="peices"> 价格 </param>
        /// <param name="outCompany"> 出版商 </param>
        public BookA(string name, int peices, string outCompany = "无")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Peices = peices;
            OutCompany = outCompany ?? throw new ArgumentNullException(nameof(outCompany));
        }

        /// <summary>
        /// 析构函数（终结器）
        /// </summary>
        ~BookA()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
            Console.WriteLine("终结器\t在整个程序结束的时候运行");
        }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonPropertyName("作者")]
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public DefaultFun defaultFun { get; set; } = new DefaultFun();

        [JsonInclude]
        public Dictionary<string, int> Details { get; private set; } = new Dictionary<string, int>() {
            {"FirstName",1 },
            { "Sex",2}
        };

        /// <summary>
        /// 储存反序列化时候的溢出数据
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }

        /// <summary>
        /// 书的名称
        /// </summary>
        [JsonInclude]
        public string Name { private get; set; } = "《书名》";

        /// <summary>
        /// 书的出版商
        /// </summary>
        [JsonIgnore]
        public string OutCompany { get => _outCompany; set => _outCompany = value; }

        /// <summary>
        /// 出版时间
        /// </summary>
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// 书的价格
        /// </summary>
        internal int Peices { get; init; } = 0;

        public override string ToString()
        {
            return $"Name:{this.Name}\tPrices:{this.Peices}\t出版时间:{this.Time}";
        }

        /// <summary>
        /// overload
        /// </summary>
        /// <returns> </returns>
        protected internal string One()
        {
            return "验证function overload";
        }

        protected internal string One(int a)
        {
            Console.WriteLine("方法重载");
            string aString = a.ToString();
            return aString;
        }

        protected internal void One(string str)
        {
            Console.WriteLine(str);
        }
    }

    /// <summary>
    /// 常规意义上为实例化对象准备方法
    /// </summary>
    public class DefaultFun
    {
        public string Name { get; set; } = "AMY";

        /// <summary>
        /// 可以由实例化对象调用的方法
        /// </summary>
        /// <param name="name"> 准备的新的属性Name的值 </param>
        internal void ChangeName(String name)
        {
            if (name.Length >= 3)
            {
                this.Name = name;
            }
        }
    }

    /// <summary>
    /// 抽象类，抽象类不能实例化
    /// </summary>
    public abstract class Human
    {
        private int _age = 1;

        public static int a = 1;

        /// <summary>
        /// 非抽象成员
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0)
                {
                    this._age = value;
                }
            }
        }

        /// <summary>
        /// 抽象属性,不能设定值
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract void AbstrractMethod();
    }

    /// <summary>
    /// 基类
    /// </summary>
    public class Person
    {
        public int _age = 10;

        private string _sex = "man";

        public Person()
        {
        }

        public Person(int age, string sex)
        {
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0)
                {
                    _age = value;
                }
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return _sex; }
            set
            {
                if (value == "man" | value == "woman")
                {
                    _sex = value;
                }
            }
        }

        /// <summary>
        /// 此类可以重写,virtual 关键字用于修改方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
        /// </summary>
        /// <param name="name"> 需要被打印的值 </param>
        public virtual void GetName(string name)
        {
            Console.WriteLine($"姓名是{name}");
        }

        /// <summary>
        /// 一个可以重写的方法
        /// </summary>
        public virtual void ProhibitDerived()
        {
            Console.WriteLine($"一个可以重写的方法\t{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 返回Json字符串
        /// </summary>
        /// <returns> </returns>
        public string ToJson()
        {
            // this表示对象
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return json;
        }

        /// <summary>
        /// 重写tostring
        /// </summary>
        /// <returns> </returns>
        public override string ToString()
        {
            return $"Age\t{this.Age}\nSex\t{this.Sex}";
        }
    }

    /// <summary>
    /// 派生类
    /// </summary>
    public class Students : Person
    {
        public Students()
        {
        }

        /// <summary>
        /// 调用基类的构造函数
        /// </summary>
        /// <param name="age"> 年龄 </param>
        /// <param name="sex"> 性别 </param>
        public Students(int age, string sex) : base(age, sex)
        {
        }

        /// <summary>
        /// 重写基类的方法
        /// </summary>
        /// <param name="name"> </param>
        public override void GetName(string name)
        {
            Console.WriteLine(base.Age);
            base.GetName(name);
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 禁止派生类重写此“在基类中允许重写”的方法
        /// </summary>
        public override sealed void ProhibitDerived()
        {
            Console.WriteLine("此方法禁止重写");
            base.ProhibitDerived();
        }

        /// <summary>
        /// 派生类自己的方法
        /// </summary>
        public void MyselfMethod()
        {
            Console.WriteLine("派生类自己的方法");
            Console.WriteLine(this._age);
        }
    }

    /// <summary>
    /// 抽象类的派生类，抽象类的派生类必须实现抽象类的所有抽象成员，sealed禁止此类有派生类
    /// </summary>
    public sealed class Tom : Human
    {

        public Tom()
        {
        }

        public Tom(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"> 姓名 </param>
        /// <param name="age"> 年龄 </param>
        public Tom(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string Name { get; set; } = "Tom";

        public override void AbstrractMethod()
        {
            Console.WriteLine("实现抽象类的抽象方法");
        }
    }

    /// <summary>
    /// 定义一个接口
    /// </summary>
    public interface IAllLIfe
    {
        private static string _aa;

        /// <summary>
        /// 接口可以包含静态字段，并可以为其赋值
        /// </summary>
        internal static string _school = "济钢高中";

        /// <summary>
        /// 接口可以包含常量，并可以为其赋值
        /// </summary>
        internal const string _Hi = "Hi！";

        /// <summary>
        /// 接口的属性成员
        /// </summary>
        public int Age { get; init; }

        /// <summary>
        /// 接口的方法成员
        /// </summary>
        /// <param name="name"> </param>
        public void PraiseLife(string name);

        /// <summary>
        /// 接口可以有默认实现
        /// </summary>
        public void Hh()
        {
            Console.WriteLine("接口的默认实现");
        }

        /// <summary>
        /// 静态属性可以提供默认值
        /// </summary>
        public static int MyProperty { get; set; } = 1;

        public static void CC()
        {
            Console.WriteLine("dsf");
        }

        public string AA
        {
            get
            {
                return _aa;
            }
            set
            {
                _aa = value;
            }
        }


    }

    public class Amy : IAllLIfe
    {
        private readonly string _name;

        /// <summary>
        /// 接口的派生类自己的属性
        /// </summary>
        public string Name
        {
            get { return _name; }
            init { _name = value; }
        }

        /// <summary>
        /// 实现接口的属性，不需要override
        /// </summary>
        public int Age { get; init; } = 1;

        /// <summary>
        /// 实现接口的方法
        /// </summary>
        /// <param name="name"></param>
        public void PraiseLife(string name)
        {
            Console.WriteLine($"赞美生命{name}");
        }

        public void Hh()
        {
            Console.WriteLine("对接口的默认实现进行重写");
        }

    }

    /// <summary>
    /// 基类
    /// </summary>
    public class ClassA
    {
        public int age = 10;
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public static int c = 0;

        /// <summary>
        /// 虚拟属性
        /// </summary>
        public virtual int Width { get; set; }

        public virtual void AMethod()
        {
            Console.WriteLine("基类的虚拟方法");
        }

        public override string ToString()
        {
            return $"此类被打印{MethodBase.GetCurrentMethod().DeclaringType.FullName}";
        }

        public void SuperMethod()
        {
            Console.WriteLine($"基类的方法{MethodBase.GetCurrentMethod().Name}");
        }


    }

    /// <summary>
    /// 派生类
    /// </summary>
    public class ClassB : ClassA
    {
        public int High { get; init; }

        /// <summary>
        /// 重写基类的虚拟方法
        /// </summary>
        public override void AMethod()
        {
            Console.WriteLine("重写基类的虚拟方法");
        }

        private int _width = 10;

        /// <summary>
        /// 重写基类的虚拟属性
        /// </summary>
        public override int Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (value >= 0)
                {
                    this._width = value;
                }
            }
        }

        public void TestBaseMethod()
        {

            Console.WriteLine($"派生类没有override的成员this.Score\t{this.Score}");
            Console.WriteLine($"通过base访问派生类没有override的成员base.Score\t{base.Score}");
            Console.WriteLine($"base.Score == this.Score\t{base.Score == this.Score}");
            Console.WriteLine($"派生类已经override的成员this.Width\t{this.Width}");
            Console.WriteLine($"通过base访问已经在派生类中重写的成员base.Width\t{base.Width}");
            Console.WriteLine($"base.Width==this.Width\t{base.Width == this.Width}");
            #region 结果

            /*
            派生类没有override的成员this.Score      0
            通过base访问派生类没有override的成员base.Score  0
            base.Score == this.Score        True
            派生类已经override的成员this.Width      10
            通过base访问已经在派生类中重写的成员base.Width  0
            base.Width==this.Width  False
             */
            #endregion
        }


        public void TestStatic()
        {
            Console.WriteLine(this);
            Console.WriteLine(base.Width);
            Console.WriteLine();
        }
    }

    public interface A
    {
        /// <summary>
        /// 接口的方法，并在接口中提供默认实现
        /// </summary>
        public void one()
        {
            Console.WriteLine($"接口成员的默认实现{MethodBase.GetCurrentMethod().DeclaringType.FullName}.{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 接口的属性
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 接口的常量
        /// </summary>
        public const string a = "接口的常量";

        /// <summary>
        /// c#8.0开始，接口中可以有静态字段
        /// </summary>
        public static int aa;

        /// <summary>
        /// 接口中可以有静态构造函数
        /// </summary>
        static A()
        {
            Console.WriteLine($"接口的静态构造函数{MethodBase.GetCurrentMethod().DeclaringType.FullName}+.+{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 非public、非私有、非静态成员
        /// </summary>
        void CDF();

        /// <summary>
        /// 接口的静态方法
        /// </summary>
        public static void HiH()
        {
            Console.WriteLine($"接口的静态方法{MethodBase.GetCurrentMethod().DeclaringType.FullName}.{MethodBase.GetCurrentMethod().Name}");
        }


    }

    public class B : A
    {
        public int Age { get; set; } = 1;

        /// <summary>
        /// 对默认实现进行重写(再次实现)
        /// </summary>
        public void one()
        {
            Console.WriteLine($"重写{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 实现非public、非私有、非静态成员不能有访问修饰符
        /// </summary>
        public void CDF()
        {
            Console.WriteLine("internal实现");
        }

    }

    public interface IA
    {
        void GO();
        void H();
        internal void Ha();
    }

    public class IAA : IA
    {
        public void GO()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}");
        }

        public void H()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 显式接口实现非public成员
        /// </summary>
        void IA.Ha()
        {
            throw new NotImplementedException();
        }
    }

    public interface IB
    {
        void GO();
        void H();
    }

    public class AB : IA, IB
    {
        /// <summary>
        /// 两个接口的GO方法的实现都是这一个方法
        /// </summary>
        public void GO()
        {
            Console.WriteLine($"方法{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 显示实现接口
        /// </summary>
        void IA.H()
        {
            Console.WriteLine($"显式实现IA的{MethodBase.GetCurrentMethod().Name}");
        }

        /// <summary>
        /// 显示实现接口
        /// </summary>
        void IB.H()
        {
            Console.WriteLine($"显式实现IB的{MethodBase.GetCurrentMethod().Name}");
        }

        void IA.Ha()
        {
            Console.WriteLine("实现的此成员在接口中不是public");
        }
    }

    public class TestA
    {
        /// <summary>
        /// 获取对象的属性和值
        /// </summary>
        /// <param name="obj"> 对象 </param>
        /// <returns> 返回属性与值一一对应的字典 </returns>
        public static Dictionary<string, string> GetPropertyValue<T>(T obj)
        {
            if (obj != null)
            {
                Dictionary<string, string> propertyValue = new Dictionary<string, string>();
                Type type = obj.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                foreach (PropertyInfo item in propertyInfos)
                {
                    propertyValue.Add(item.Name, (item.GetValue(obj, null) == null ? "" : item.GetValue(obj, null)).ToString());
                }

                return propertyValue;
            }
            return null;
        }

        /// <summary>
        /// 测试基类和派生类
        /// </summary>
        public void BaseAndPai()
        {
            // 向上转型，只能调用基类的成员，有助于成员的统一
            Person students = new Students();
            students.GetName("Tom");
            // 向下转型，可以调用子类的特殊方法
            Students studentsDerived = new Students();
            studentsDerived.MyselfMethod();
            // 派生类调用基类的字段
            Console.WriteLine(studentsDerived._age);
            // 向下转型，从父类转为子类
            ((Students)students).MyselfMethod();
            Human tom = new Tom();
            Console.WriteLine(tom.Age);
            IAllLIfe amy = new Amy();
            // 使用向下转型获取子类的独有属性
            amy.PraiseLife(((Amy)amy).Name);
            // call interface's static filed
            Console.WriteLine(IAllLIfe._school);
            Console.WriteLine(IAllLIfe._Hi);
            // 派生类调用接口的默认实现
            amy.Hh();
        }

        public void BaseAndPai2()
        {
            ClassB classB = new ClassB();
            ClassA classA = new ClassB();//向上转型
            ClassB classBDown = (ClassB)classA;//向下转型
            Console.WriteLine(classB);
            // 调用基类的方法
            classB.AMethod();
            Console.WriteLine("-=-=-=-=-=-=-=--=-=-=-=-=");
            classB.TestBaseMethod();
            Console.WriteLine("-=-=-=-=-=-=-=--=-=-=-=-=");
            classB.TestStatic();
            Console.WriteLine($"ClassB.c\t{ClassB.c}");
        }

        public void TestInterface()
        {
            // 实例化时，声明类型指向接口
            A a = new B();
            // 实例化时，声明类型指向实现类自己
            B b = new B();
            a.one();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine(A.a);
            A.HiH();
            //Console.WriteLine(B.a);
            /*
             接口的常量
             接口的静态构造函数ConsoleApp1.A+.+.cctor
             接口的静态方法ConsoleApp1.A.HiH
             */

        }

        public void TestInterface2()
        {
            AB a = new AB();
            IA b = new AB();
            IB c = new AB();
            //a.H(); 无法通过实现类调用显示接口实现，只能通过指向接口的实现类来调用显示接口实现
            b.H();
            c.H();

        }

        /// <summary>
        /// 集合类型的转换
        /// </summary>
        internal void Eight()
        {
            Hashtable hashtable = new Hashtable() {
                { 1,1},
                { 2,2}
            };
            // hashtable 转 Dict
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (DictionaryEntry item in hashtable)
            {
                dictionary.Add((int)item.Key, (int)item.Value);
            }
            // Dict转Hashtable
            Hashtable hashtable1 = new Hashtable(dictionary);

            foreach (var item in dictionary)
            {
                Console.WriteLine($"key:{item.Key}\tvalue:{item.Value}");
            }
        }

        /// <summary>
        /// 测试arrary，arrarylist、list
        /// </summary>
        internal void Five()
        {
            Console.WriteLine("==================================");
            // 声明arrary
            int[] vs = new int[10];
            Console.WriteLine(vs.Length);
            Console.WriteLine(vs.Count());
            // 赋值
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = (int)Math.Pow(i, 2);
            }
            Array.ForEach(vs, item => Console.WriteLine(item));
            // 方法 改
            vs[0] = 12;
            // 查
            Console.WriteLine(Array.IndexOf(vs, 12)); //0
            Console.WriteLine(vs.Contains(12)); // True
            // 切片
            Console.WriteLine(string.Join("\n", vs[1..5]));
            // array数据类型转换
            double[] vs3 = Array.ConvertAll(vs, item => (double)item);
            Console.WriteLine("arrarylist，长度和类型不受限制，性能受限制");
            // 多维数组 下面定义二维数组
            int[,] duoWei = new int[3, 4];
            Console.WriteLine($"多维数组的长度{duoWei.Length}");
            // 二维数组赋值
            Console.WriteLine("二维数组赋值");
            for (int i = 0; i < duoWei.GetLength(0); i++)
            {
                for (int j = 0; j < duoWei.GetLength(1); j++)
                {
                    duoWei[i, j] = i + j;
                }
            }
            // 读取多维数组的值
            Console.WriteLine($"读取多维数组的值duoWei[1,1]\t{duoWei[1, 1]}");
            duoWei[1, 2] = 3;
            // 定义多维数组要求每个维度的长度都相同 下面定义交错数组
            int[][] jiaoCuo = new int[3][]; // 该数组是由三个一维数组组成的
            // 交错数组赋值
            Console.WriteLine("交错数组循环赋值");
            // 先声明交错数组中每一个数组的长度
            for (int i = 0; i < 3; i++)
            {
                jiaoCuo[i] = new int[i + 1];
            }
            // 然后对交错数组中的每一个元素赋值
            for (int i = 0; i < jiaoCuo.Length; i++)
            {
                Console.WriteLine($"交错数组的第{i + 1}层");
                for (int j = 0; j < jiaoCuo[i].Length; j++)
                {
                    jiaoCuo[i][j] = i + j;
                    Console.WriteLine(jiaoCuo[i][j]);
                }
            }
            Console.WriteLine("交错数组循环赋值结束");
            jiaoCuo[1][1] = 2;
            // 可以采用下面的方式来获取单个元素和为单个元素单独赋值 一维数组
            Console.WriteLine(vs[1]);
            vs[1] = 2;
            // 多维数组
            Console.WriteLine(duoWei[1, 2]);
            duoWei[1, 2] = 3;
            // 交错数组
            Console.WriteLine(jiaoCuo[1][0]);
            jiaoCuo[1][0] = 0;

            // array声明和赋值
            ArrayList arrayList = new ArrayList(vs);

            #region 不同的赋值方法

            //ArrayList arrayList1 = new ArrayList() { 12, 334, 3, true };
            //ArrayList arrayList2 = new ArrayList(2);
            //Console.WriteLine("-=-=-=-=-=-=-=-=");
            //Console.WriteLine(arrayList2.Count);
            //Console.WriteLine(arrayList2.Capacity);
            //arrayList2.Add(12);
            //arrayList2.Add(30);
            //arrayList2.Add(40);
            //Console.WriteLine(arrayList2.Count);
            //Console.WriteLine(arrayList2.Capacity);
            //arrayList2.TrimToSize();
            //Console.WriteLine(arrayList2.Capacity);

            #endregion 不同的赋值方法

            Console.WriteLine("-=-=-=-=-=-=-=-=");

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            foreach (var item in vs)
            {
                arrayList.Add(item.ToString());
            }
            Console.WriteLine(arrayList.Count);
            // 切片,建议先转为arrary，再切片。如果不行才使用getrange
            Console.WriteLine("切片,建议先转为arrary，再切片。如果不行才使用getrange");
            try
            {
                object[] vs1 = arrayList.ToArray();
                // 下面这一步会报错，Unable to cast object of type 'System.String' to type 'System.Int32'.
                int[] vs2 = Array.ConvertAll(vs1, s => (int)s);
                Console.WriteLine(string.Join("\t", vs2[^3..]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(arrayList.GetRange(1, 7));
            }

            //List
            Console.WriteLine("List<T>");
            // 声明
            List<string> listA = new List<string>() { "hello", " ", "wrold" };
            // 属性 长度
            Console.WriteLine(listA.Count);
            // 属性 取值
            Console.WriteLine(listA[0]);
            // 循环
            var ia = 0;
            listA.ForEach(item =>
            {
                Console.WriteLine($"第{ia + 1}个");
                Console.WriteLine(item);
                ia++;
            });
            // 方法 增
            listA.Add("12");
            // 查
            Console.WriteLine(listA.IndexOf("12"));
            Console.WriteLine(listA.Contains("12"));
            // 删
            listA.Remove("12");
            listA.RemoveAt(1);
            // 转
            List<object> listObject = listA.ConvertAll(s => (object)s);
            // 改
            listA[1] = "改变";
            // 切片
            Console.WriteLine(listA.GetRange(1, 1).Count);
        }

        /// <summary>
        /// 格式化输出sjon
        /// </summary>
        internal void FormatJson()
        {
            // 先定义一个json字符串
            string jsonText = "{\"ClassName\":\"Science\",\"Final\":true,\"Semester\":\"2019-01-01\",\"Students\":[{\"Name\":\"John\",\"Grade\":94.3},{\"Name\":\"James\",\"Grade\":81.0},{\"Name\":\"Julia\",\"Grade\":91.9},{\"Name\":\"Jessica\",\"Grade\":72.4},{\"Name\":\"Johnathan\"}],\"Teacher'sName\":\"Jane\"}";
            Console.WriteLine(jsonText);
            // 将表示单个 JSON 字符串值的文本分析为 JsonDocument
            using (JsonDocument jsonDocument = JsonDocument.Parse(jsonText))
            {
                // 序列化
                string formatJson = JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions()
                {
                    // 整齐打印
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
                // 格式化输出
                Console.WriteLine(formatJson);
                // jsondocument 格式化输出为json字符串
                string a = jsonDocument.JDFormatToString();
                // 格式化字符串
                string b = jsonText.TOJsonString();
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }

        /// <summary>
        /// JsonDocument使用
        /// </summary>
        internal void FormatJson2()
        {
            Console.WriteLine("对json字符串进行dom操作");
            string jsonText = "{\"ClassName\":\"Science\",\"Final\":true,\"Semester\":\"2019-01-01\",\"Students\":[{\"Name\":\"John\",\"Grade\":94.3},{\"Name\":\"James\",\"Grade\":81.0},{\"Name\":\"Julia\",\"Grade\":91.9},{\"Name\":\"Jessica\",\"Grade\":72.4},{\"Name\":\"Johnathan\"}],\"Teacher'sName\":\"Jane\"}";
            using (JsonDocument jsonDocument = JsonDocument.Parse(jsonText))
            {
                JsonElement root = jsonDocument.RootElement;
                JsonElement students = root.GetProperty("Students");
                JsonElement semester = root.GetProperty("Semester");
                // 获取json的值类型
                Console.WriteLine(semester.ValueKind);
                Console.WriteLine(semester);
                // 检测json的值类型
                Console.WriteLine(students.ValueKind == JsonValueKind.Array);
                Console.WriteLine(semester.GetString());

                // 获取数组长度
                Console.WriteLine(students.GetArrayLength());
                // EnumerateArray 一个枚举器，它用于枚举由该 JsonElement 表示的 JSON 数组中的值。
                foreach (JsonElement student in students.EnumerateArray())
                {
                    Console.WriteLine(student);
                    Console.WriteLine(student.ValueKind);// object
                    // 获取属性Name的string值
                    Console.WriteLine(student.GetProperty("Name").GetString());
                    //Console.WriteLine(student.GetProperty("Grade").GetDouble());
                }
                Console.WriteLine("关于搜索不好的示范");
                Console.WriteLine(students[1]);
                Console.WriteLine("示范结束");
                Console.WriteLine(root.TryGetProperty("Semester", out JsonElement value));
                Console.WriteLine(value.GetString());
            }
        }

        /// <summary>
        /// 调用有参拓展方法
        /// </summary>
        internal void Four()
        {
            var str = "你好世界";
            ArrayList arrayList = str.GetArrayList(12);
            foreach (var item in arrayList)
            {
                Console.WriteLine($"{item.GetType()}\t{item}");
            }
        }

        /// <summary>
        /// 混合使用构造器和初始化器
        /// </summary>
        internal void One()
        {
            // TODO 混合使用构造器和初始化器
            BookA book = new BookA("《123》", 12)
            {
                Author = "ASir"
            };

            Console.WriteLine(book);
        }

        /// <summary>
        /// 集合
        /// </summary>
        internal void Seven()
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < 10; i++)
            {
                hashtable.Add(i, i.ToString() + "值");
            }
            Console.WriteLine(hashtable);
            Console.WriteLine(hashtable[1].GetType());
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
                /*

                 System.Collections.DictionaryEntry
                 5
                 5值
                 */
                Console.WriteLine("-=-=-=-=-=-=-=-=-=");
            }
            Console.WriteLine("sortedList");
            SortedList sortedList = new SortedList();
            for (var i = 0; i < 10; i++)
            {
                sortedList.Add(i, i.ToString());
            }
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine($"{sortedList.GetKey(i)}\t{sortedList.GetByIndex(i)}");
            }
            Console.WriteLine("HashSet<T>");
            HashSet<int?> setA = new HashSet<int?>() { 1, 2, 3 };
            HashSet<int?> setB = new HashSet<int?>() { 1, 2, 3, 4, 5 };
            HashSet<int?> setC = setB;
            // 确定setA是否为setB的真子集
            Console.WriteLine(setA.IsProperSubsetOf(setB)); // True
            Console.WriteLine(setC.IsProperSubsetOf(setB)); // False
            setA.Add(null);
            // 求两个的并集
            setA.UnionWith(setB);
            // 现在setA就是两个集合的并集
            foreach (var item in setA)
            {
                Console.WriteLine(item);
            }
            // 求交集
            setA.IntersectWith(setB);
            // 现在setA就是两个的交集
            foreach (var item in setA)
            {
                Console.WriteLine(item);
            }
            // 去除交集，从当前 HashSet<T> 对象中移除指定集合中的所有元素。
            setA.ExceptWith(setB);
            foreach (var item in setA)
            {
                Console.WriteLine(item);
            }
            //仅包含存在于该对象中或存在于指定集合中的元素（但并非两者）。
            setA.SymmetricExceptWith(setB);
            foreach (var item in setA)
            {
                Console.WriteLine(item);
            }

            Dictionary<int, string> dictionary = new Dictionary<int, string>() {
                { 1,"Hello"},
                { 2," "},
                { 3,"world"}
            };
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}\tover");
            }
        }

        /// <summary>
        /// 测试arrary，arrarylist、list之间的转换
        /// </summary>
        internal void SixDifference()
        {
            // 声明数组
            int[] a = new int[] { 1, 3, 4, 5, 656, -1 };

            // 声明多维数组
            int[,] aD = new int[,] { { 1, 2 }, { 3, 4 } };
            // 声明交错数组
            int[][] aJ = new int[][] {
                new int[]{ 1,2,3},
                new int[]{ 1}
            };
            // 声明ArrayList
            ArrayList b = new ArrayList() { 1, 2, 344, "233", true };
            Console.WriteLine(b[3].GetType()); //System.String
            // 声明List<T>
            List<int> c = new List<int>();

            // 数组转ArrayList
            ArrayList aToArrayList = new ArrayList(a);
            // 数组转List<T>
            List<int> aToList = new List<int>(a);
            List<int> aToLista = a.ToList();
            // List<T>转数组
            int[] cToList = c.ToArray();
            // List<T>转ArrayList
            ArrayList cToArrayList = new ArrayList(c);
            // ArrayList转Array
            object[] bToArray = b.ToArray();
            // 数组的打印
            Console.WriteLine("数组的打印");
            // 调用Array.ForEach
            Array.ForEach(a, item => Console.WriteLine(item));
            // 传统forEach
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            // 传统for
            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine(a[i]);
            }
            // string.Join
            Console.WriteLine(string.Join("\t", a));
            // ArrayList的打印
            Console.WriteLine("ArrayList的打印");
        }

        /// <summary>
        /// 运行解答cnblog朋友的疑惑
        /// </summary>
        internal void TestCnBlog()
        {
            // 实例化对象
            BookA bookA = new BookA();
            // details的set为private，有JsonInclude特性来修饰，正常情况下，在类外面只能读，不能写
            Dictionary<string, int> details = bookA.Details;
            // 读取并打印details
            foreach (var item in details)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            // 实例化JsonSerializerOptions
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };
            // 将实例化对象bookA序列成json字符串
            string bookaJson = JsonSerializer.Serialize(bookA, options);
            // 里面包含details的各种内容
            Console.WriteLine(bookaJson);
            // 将之前序列化之后获得的字符串进行反序列化
            BookA bookA1 = JsonSerializer.Deserialize<BookA>(bookaJson, options);
            // 自定义的方法，获取类的所有属性
            Dictionary<string, string> bookA1Prop = GetPropertyValue<BookA>(bookA1);
            // private set属性访问器的字典details被成功反序列化
            foreach (var item in bookA1Prop)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }

        /// <summary>
        /// Json
        /// </summary>
        internal void TestJson()
        {
            BookA bookA = new BookA()
            {
                Author = "Amy",
                OutCompany = "123",
            };
            // 序列化
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                // 整齐打印
                WriteIndented = true,
                // 忽略值为Null的属性
                IgnoreNullValues = true,

                #region 设置字符集

                // 设置Json字符串支持的编码，默认情况下，序列化程序会转义所有非 ASCII 字符。 即，会将它们替换为 \uxxxx，其中 xxxx 为字符的 Unicode
                // 代码。 可以通过设置Encoder来让生成的josn字符串不转义指定的字符集而进行序列化 下面指定了基础拉丁字母和中日韩统一表意文字的基础Unicode 块
                // (U+4E00-U+9FCC)。 基本涵盖了除使用西里尔字母以外所有西方国家的文字和亚洲中日韩越的文字

                #endregion 设置字符集

                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs, UnicodeRanges.CjkSymbolsandPunctuation),
                // 反序列化不区分大小写
                PropertyNameCaseInsensitive = true,
                // 驼峰命名
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                // 对字典的键进行驼峰命名
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                // 序列化的时候不忽略属性
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                // 忽略只读属性，因为只读属性只能序列化而不能反序列化，所以在以json为储存数据的介质的时候，序列化只读属性意义不大
                IgnoreReadOnlyFields = true,
                // 不允许结尾有逗号的不标准json
                AllowTrailingCommas = false,
                // 不允许有注释的不标准json
                ReadCommentHandling = JsonCommentHandling.Disallow,
                // 允许在反序列化的时候原本应为数字的字符串（带引号的数字）转为数字
                NumberHandling = JsonNumberHandling.AllowReadingFromString
                // 处理循环引用类型，比如Book类里面有一个属性也是Book类
                //ReferenceHandler = ReferenceHandler.Preserve
            };

            string jsonBookA = JsonSerializer.Serialize(bookA, jsonSerializerOptions);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(jsonBookA);
            // 反序列化
            BookA bookA1 = JsonSerializer.Deserialize<BookA>(jsonBookA, jsonSerializerOptions);
            Console.WriteLine(bookA1);
            //Console.WriteLine(bookA1.Name);
            Dictionary<string, string> dictionary = GetPropertyValue(bookA1);
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }

        /// <summary>
        /// 调用无参拓展方法
        /// </summary>
        internal void Three()
        {
            var str = "1234";
            //在使用的时候直接调用就行，直接在实例化对象后面接方法名就行，不用带拓展方法所属于的静态类名
            int v = str.GetTheDoubleLength();
            Console.WriteLine(v);
        }

        /// <summary>
        /// 常规方法实例化对象和调用方法
        /// </summary>
        internal void Two()
        {
            //实例化对象
            DefaultFun defaultFun = new DefaultFun();
            //调用实例化对象的方法
            defaultFun.ChangeName("新的Name");
        }
    }
}