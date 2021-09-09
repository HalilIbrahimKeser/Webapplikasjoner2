using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EnKlasse x;
            EnKlasse obj1 = new EnKlasse(100);
            EnKlasse obj2 = new EnKlasse(200);

            x = obj1;
            obj1 = obj2;

            x.Print();
            obj1.Print();
            obj2.Print();
        }
    }

    class EnKlasse
    {
        private int tall;

        public EnKlasse(int _tall) { tall = _tall; }

        public void Print()
        {
            Console.WriteLine("{0}", tall);
            Console.ReadLine();
        }
    }
}
