using System;

namespace Bintall
{
    class Bintall
    {
        private int number;
        private int binaryNumber;
        private String bits;

        public Bintall(int number)
        {
            this.number = number;

            this.bits = Convert.ToString(number, 2);
        }

        public Bintall(String binarynumber)
        {
            String binaryString = binarynumber;

            int integerNumber = Convert.ToInt32(binaryString, 2);
            this.binaryNumber = integerNumber;

            this.number = integerNumber;

            this.bits = binarynumber;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static Bintall operator +(Bintall tall1, Bintall tall2)
        {
            Bintall tall3 = new Bintall(0);
            tall3.number = tall1.number + tall2.number;
            return tall3;
        }

        public static Bintall operator -(Bintall tall1, Bintall tall2)
        {
            Bintall tall4 = new Bintall(0);
            tall4.number = tall1.number - tall2.number;
            return tall4;

        }

        public static Bintall operator *(Bintall tall1, Bintall tall2)
        {
            Bintall tall3 = new Bintall(0);
            tall3.number = tall1.number * tall2.number;
            return tall3;

        }

        public static Bintall operator +(int tall1, Bintall tall2)
        {
            Bintall tall3 = new Bintall(0);
            tall3.number = tall1 + tall2.number;
            return tall3;
        }

        public static Bintall operator +(Bintall tall1, int tall2)
        {
            Bintall tall3 = new Bintall(0);
            tall3.number = tall1.number + tall2;
            return tall3;
        }

        static void Main(string[] args)
        {
            Bintall number1 = new Bintall(25);
            Bintall number2 = new Bintall(50);
            Bintall result = new Bintall(0);
            Bintall binaertall1 = new Bintall("1010"); // 10
            Bintall binaertall2 = new Bintall("1000"); //  8
            int integerTall = 20;

            result = number1 + number2;
            Calculate(number1, number2, result, "+");


            result = number2 - number1;
            Calculate(number2, number1, result, "-");


            result = binaertall1 + integerTall;
            Calculate1(binaertall1, integerTall, result, "+");


            result = integerTall + binaertall2;
            Calculate2(integerTall, binaertall2, result, "+");

            Console.ReadKey();
        }

        static void Calculate(Bintall number1, Bintall number2, Bintall result, String operand)
        {
            String toPrint = "Result: " + number1.number + " " + operand + " " + number2.number + " = " + result.number;
            Console.WriteLine("Nummer 1 som integer: " + number1.number + " og i bits: " + number1.bits);
            Console.WriteLine("Nummer 2 som integer: " + number2.number + " og i bits: " + number2.bits);
            Console.WriteLine(toPrint);
            Console.WriteLine();
        }
        static void Calculate1(Bintall number1, int number2, Bintall result, String operand)
        {
            String toPrint = "Result: " + number1.number + " " + operand + " " + number2 + " = " + result.number;
            Console.WriteLine("Nummer 1 som integer: " + number1.number + " og i bits: " + number1.bits);
            Console.WriteLine("Nummer 2 som integer: " + number2 + " og i bits: " + Convert.ToString(number2, 2));
            Console.WriteLine(toPrint);
            Console.WriteLine();
        }
        static void Calculate2(int number2, Bintall number1, Bintall result, String operand)
        {
            String toPrint = "Result: " + number2 + " " + operand + " " + number1.number + " = " + result.number;
            Console.WriteLine("Nummer 1 som integer: " + number2 + " og i bits: " + Convert.ToString(number2, 2));
            Console.WriteLine("Nummer 2 som integer: " + number1.number + " og i bits: " + number1.bits);
            Console.WriteLine(toPrint);
            Console.WriteLine();
        }
    }
}
