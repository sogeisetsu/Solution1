using System;
using System.Diagnostics;
using System.Reflection;

namespace ShowCase
{
    /// <summary>
    /// 调用类
    /// </summary>
    public class DY
    {
        /// <summary>
        /// 调用类的成员
        /// </summary>
        internal void One()
        {
            CC cC = new() { High = 12.4, Name = nameof(One), Sex = "woman" };
        }

        /// <summary>
        /// 调用构造函数
        /// </summary>
        internal void two()
        {
            GZ gZ = new GZ();
            Console.WriteLine(gZ.methodName());
            Console.WriteLine(GZ.ss);
        }

        /// <summary>
        /// 测试vs 反编译的能力
        /// </summary>
        internal void UseDllTwo()
        {
            new DllTwo.Class1().getName();
        }

        /// <summary>
        /// 验证隐式变换
        /// </summary>
        internal void YinShiChange()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=");
            var a = 1;
            //a += "121"; 这是错误的
            Console.WriteLine(a.GetType());
            //在打印的时候是可以的，这时候是将所有的都转换成字符串
            Console.WriteLine(a + "123");
            var v = Convert.ToString(a);
            Console.WriteLine(v.GetType());
            Type intType = typeof(int);
            Console.WriteLine(intType == a.GetType());
            // 值类型的隐式转换
            var aa = 1;
            Console.WriteLine(intType == aa.GetType());
            double cc = aa;
            Console.WriteLine(cc.GetType() + "\t" + (cc.GetType() == typeof(double)));

            #region
            /*
            -=-=-=-=-=-=-=-=-=-=-=-=
            System.Int32
            1123
            System.String
            True
            True
            System.Double   True
            按下任何键去停止并退出程序
             */
            #endregion
        }

        /// <summary>
        /// 调用无参构造函数使私有成员的类
        /// </summary>
        internal void Three()
        {
            PrivateGZ privateGZ = new PrivateGZ(2);
            Console.WriteLine(privateGZ.Id);
        }
    }

    #region 构造函数大全

    /// <summary>
    /// 类的成员，类的默认访问修饰符为internal、类的成员的默认访问修饰符为private
    /// </summary>
    internal class CC
    {
        /// <summary>
        /// 只读字段，只能在声明和构造器中赋值，装饰字段时这个从易用性上比不上init访问器
        /// </summary>
        public readonly int Z = 1;

        /// <summary>
        /// 常量
        /// </summary>
        internal const string ChL = "常量";

        /// <summary>
        /// 字段基本上可以对应java的变量，但是建议字段的数据不要直接像客户端公开，而是用方法、属性等公开。 访问修饰符建议为private或protected
        /// </summary>
        protected double high = 12.3;

        /// <summary>
        /// 字段
        /// </summary>
        protected double pang = 100;

        /// <summary>
        /// 无参构造,可以不定义，但是一旦行医有参构造，则如果还想使用无参，必须定义
        /// </summary>
        public CC()
        {
        }

        public CC(int z, double high, double pang, string name, int score, string sex)
        {
            Z = z;
            High = high;
            this.pang = pang;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Score = score;
            Sex = sex ?? throw new ArgumentNullException(nameof(sex));
        }

        /// <summary>
        /// 普通属性，将字段的读写操作披露到属性
        /// </summary>
        public double High { get => high; set => high = value; }

        /// <summary>
        /// 自动属性，无需定义字段
        /// </summary>
        public string Name { get; set; } = "Class";

        /// <summary>
        /// 修改可访问性的自动属性，该属性只能在本类中进行写操作，却可以公开进行读操作
        /// </summary>
        public int Score { get; private set; } = 90;

        /// <summary>
        /// 使用init访问器的自动属性，只能在声明、构造器和初始化器中设置值
        /// </summary>
        public string Sex { get; init; } = "男";

        /// <summary>
        /// 修改属性的读写,没有set，故而该属性只能获得不能设置，有点像常量， 但是属性背后的字段在符合条件的时候是可以修改的，这点就和常量不一样了
        /// </summary>
        internal double Pang
        {
            get => pang;
        }
    }

    /// <summary>
    /// 构造函数和构造函数的overload
    /// </summary>
    internal class GZ
    {
        private int age = 12;
        protected bool ifMan = true;
        protected string name = "123";
        protected double price = 12.657;
        internal static string ss;

        /// <summary>
        /// 获取方法名称
        /// </summary>
        internal Func<string> methodName = new Func<string>(new StackTrace().GetFrame(1).GetMethod().ToString);

        protected int Age { get => age; set => age = value; }

        public GZ()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 静态构造函数 将在创建第一个实例或引用任何静态成员之前自动调用静态构造函数。无法直接调用 静态构造函数不使用访问修饰符或不具有参数。
        /// </summary>
        static GZ()
        {
            Console.WriteLine("静态构造函数");
        }

        public GZ(string name, int age)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.Age = age;
        }

        /// <summary>
        /// 构造函数可以使用 this 关键字调用同一对象中的另一构造函数
        /// </summary>
        /// <param name="name"> </param>
        /// <param name="age"> </param>
        /// <param name="price"> </param>
        /// <param name="ifMan"> </param>
        public GZ(string name, int age, double price, bool ifMan) : this(name, age)
        {
            this.price = price;
            this.ifMan = ifMan;
        }
    }

    /// <summary>
    /// 私有构造函数，作用是使类无法正常实例化
    /// </summary>
    internal class PrivateGZ
    {
        internal int Id { get; set; } = 1;
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private PrivateGZ()
        {
        }
        /// <summary>
        /// 公开的构造函数，只能以这种方式实例化
        /// </summary>
        /// <param name="id">id</param>
        public PrivateGZ(int id)
        {
            Id = id;
        }
    }

    #endregion
}

/// <summary>
/// 定义新的命名空间
/// </summary>
namespace HEIE
{
    public class Hello
    {
        static Hello()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        }
    }
}