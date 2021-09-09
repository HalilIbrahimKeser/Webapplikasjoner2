using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2_Referanseoverføring_primitive_typer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter y:");
            int y = int.Parse(Console.ReadLine());

            Console.Write("\nBefore Swapping : ");
            Console.WriteLine("\n x = " + x + ", " + "y = " + y);

            var swap = new Program();
            swap.Swap(ref x, ref y);

            Console.Write("\nAfter Swapping : ");
            Console.WriteLine("\n x = " + x + ", " + "y = " + y);
            Console.Read();

        }

        void Swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
           
        }
    }
}
