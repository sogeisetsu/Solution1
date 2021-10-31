using System;

namespace ShowCase
{
    class AsIs
    {
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
    }
}
