using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HEIE
{
    public delegate void WTuo();

    internal class BookA
    {
        private string _author;

        private string _outCompany;

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
        /// 作者
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// 书的出版商
        /// </summary>
        public string OutCompany { get => _outCompany; set => _outCompany = value; }

        /// <summary>
        /// 书的名称
        /// </summary>
        protected string Name { get; set; } = "《书名》";

        /// <summary>
        /// 书的价格
        /// </summary>
        protected int Peices { get; init; } = 0;

        /// <summary>
        /// 析构函数（终结器）
        /// </summary>
        ~BookA()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
            Console.WriteLine("终结器\t在整个程序结束的时候运行");
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
    internal class DefaultFun
    {
        internal string Name { get; set; }

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
    /// 为string类型增加拓展方法
    /// </summary>
    internal static class stringExtensions
    {
        /// <summary>
        /// demo，试图获取string实例化对象长度的两倍
        /// </summary>
        /// <param name="str"> 此方法的第一个参数指定方法所操作的类型；此参数前面必须加上 this 修饰符。 </param>
        /// <returns> 原来长度的两倍 </returns>
        internal static int GetTheDoubleLength(this string str)
        {
            return str.Length * 2;
        }

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
    }

    internal class TestA
    {
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
        /// 常规方法实例化对象和调用方法
        /// </summary>
        internal void Two()
        {
            //实例化对象
            DefaultFun defaultFun = new DefaultFun();
            //调用实例化对象的方法
            defaultFun.ChangeName("新的Name");
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
            // 方法
            // 改
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
            // 可以采用下面的方式来获取单个元素和为单个元素单独赋值
            // 一维数组
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
            // 方法
            // 增
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
        }


    }
}