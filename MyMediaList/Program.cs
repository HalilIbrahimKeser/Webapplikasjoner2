using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMediaList
{
    public class MyMediaList : IEnumerable
    {

        static string[] objects = { "lydspor", "videosnutter", "stillbildevisning " };
        private LinkedList<String> strings = new LinkedList<string>(objects);
        private string v;

        public MyMediaList(string v)
        {
            this.v = v;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string s in objects)
            {
                yield return s;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {

            List<String> str = new List<string>();
            str.Add("Maho");

            LinkedList<MyMediaList> mineObjecter = new LinkedList<MyMediaList>();
            mineObjecter.AddLast(new MyMediaList("ee"));
            foreach (Object s in mineObjecter)
            {
                Console.WriteLine(mineObjecter);
                Console.ReadKey();
            }


        }

    }
}
