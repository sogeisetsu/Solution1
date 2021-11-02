using System;
using System.Reflection;

namespace ClassLibrary1
{
    public class LibraryOne
    {
        /// <summary>
        /// 构建函数
        /// </summary>
        public LibraryOne()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("创建类库");
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        }

        /// <summary>
        /// 打印输入的字符串
        /// </summary>
        /// <param name="arg"></param>
        public void One(string arg)
        {
            Console.WriteLine($"{arg}");
        }
    }
}