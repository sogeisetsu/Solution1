using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class FanXing
    {
        public List<Object> ListObj { get; set; }

        /// <summary>
        /// 泛型方法
        /// </summary>
        /// <typeparam name="T">泛型参数，示意任意类型</typeparam>
        /// <param name="value">泛型参数的实例化对象</param>
        public void A<T>(T value)
        {
            ListObj.Add(value);
        }

    }

    class A<T>
    {
        public void GetTAndTest(T value)
        {
            Console.WriteLine(value.GetType());
            Console.WriteLine(typeof(T) == value.GetType());
            // System.Int32
            // True
        }
    }

    class A
    {
        public void GetTAndTest(int value)
        {
            Console.WriteLine(value.GetType());
        }
    }

    class B<T> where T : new()
    {
        public B()
        {
        }
        public B(T value)
        {
            Console.WriteLine(value);
        }
    }

    public abstract class AbB
    {
        internal abstract void A();
    }

    public class AbBExtend : AbB
    {
        internal override void A()
        {
            Console.WriteLine("测试泛型的NEW 约束");
        }
    }

    public interface C { }


    /// <summary>
    /// 泛型参数必须为引用数据类型
    /// </summary>
    /// <typeparam name="T">引用数据类型</typeparam>
    public class D<T> where T : class, new()
    {

    }

    public interface IJK<T>
    {
        void One(T value);

        T Two();

        public int MyProperty { get; set; }
    }

    /// <summary>
    /// 实现泛型接口
    /// </summary>
    /// <typeparam name="T">泛型参数</typeparam>
    public class Jk<T> : IJK<T>
    {
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void One(T value)
        {
            throw new NotImplementedException();
        }

        public T Two()
        {
            throw new NotImplementedException();
        }
    }



    class Test
    {
        public void One()
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < 10000; i++)
            {
                arrayList.Add(i);
            }
            Console.WriteLine(arrayList[1].GetType()); // System.Int32

            List<int> list = new List<int>();
            list.Add(12);
            //list.Add("12") error
        }
        public void Two()
        {
            A<int> a = new A<int>();
            a.GetTAndTest(12);
        }

        public void Three()
        {
            // 实例化类
            FanXing fanXing = new FanXing()
            {
                ListObj = new List<object>()
            };
            // 调用泛型方法
            fanXing.A("1234");
            // 打印
            fanXing.ListObj.ForEach(item =>
            {
                Console.WriteLine(item);
            });
        }

        public void Four()
        {
            // AdB为抽象类
            //B<AbB>(); error

            // AbBExtend为AdB抽象类的实现类
            new B<AbBExtend>(); // right

            // C为接口
            //new B<C>(); error


        }
    }
}
