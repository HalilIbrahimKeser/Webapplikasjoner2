using System;

namespace oppgave1a
{
    class Program
    {
        static void Main(string[] args)
        {
            int height;
            int width;
            Console.WriteLine("Enter height");
            height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter width");
            width = Convert.ToInt32(Console.ReadLine());

            int areal = height * width;
            int perimeter = (2 * height) + (2 * width);

            Console.WriteLine("Arealet er: " + areal + " og omkretsen er : " + perimeter);


        }
    }
}
