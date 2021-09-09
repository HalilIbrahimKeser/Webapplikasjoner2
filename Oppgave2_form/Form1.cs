using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oppgave2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            static void Main(string[] args)
        {
            double height;
            double weight;
            Console.WriteLine("Enter height");
            height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter weight");
            weight = Convert.ToDouble(Console.ReadLine());

            double BMI = (weight / (height * height));

            if (BMI < 18.5)
            {
                Console.WriteLine("Du er undervektig");
            }
            else if (BMI < 24.9 || BMI > 18.5)
            {
                Console.WriteLine("Du har normalvekt");
            }
            else if (BMI < 29.9 || BMI > 25)
            {
                Console.WriteLine("Du er overvektig");
            }
            else if (BMI > 30)
            {
                Console.WriteLine("Du er fedme, gå til legen for å få råd");
            }
            else
            {
                Console.WriteLine("Utenfor...");
            }
        }
        }

    }
}
