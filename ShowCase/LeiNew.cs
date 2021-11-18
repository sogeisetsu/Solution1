using System;

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
    }

    internal class TestA
    {
        internal void One()
        {
            // TODO 混合使用构造器和初始化器
            BookA book = new BookA("《123》", 12)
            {
                Author = "ASir"
            };

            Console.WriteLine(book);
        }
    }
}