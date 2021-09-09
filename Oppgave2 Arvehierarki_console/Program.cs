using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2_console
{
    public class Livsform 
    {
        public virtual void Laglyd() 
        {
            Console.WriteLine("lyd");
        }

    }

    public class Pattedyr : Livsform
    {
        public override void Laglyd()
        {
            Console.WriteLine("Jeg er et pattedyr");
        }

    }

    public class Amfibie : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("Jeg er et Amfibie");
        }

    }

    public class Insekt : Amfibie
    {
        public override void Laglyd()
        {
            Console.WriteLine("Pip pip");
        }

    }

    public class Menneske : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("Hei hei heisann jeg er menneske og kommer fra apene");
        }

    }

    public class Hund : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("Woff woff");
        }

    }

    public class Sau : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("Mææææææææ");
        }

    }

    public class Apekatt : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("A aaa aaa");
        }

    }

    public class Slange : Pattedyr
    {
        public override void Laglyd()
        {
            Console.WriteLine("Sssssssss");
        }

    }

    public class Edderkopp : Amfibie
    {
        public override void Laglyd()
        {
            Console.WriteLine("pip pip");
        }

    }

    public class Frosk : Amfibie
    {
        public override void Laglyd()
        {
            Console.WriteLine("kvak kvak");
        }

    }

    public class Mygg : Insekt
    {
        public override void Laglyd()
        {
            Console.WriteLine("Zzzzzzzzzzzzzzzzz");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Insekt insekt1 = new Insekt();
            Menneske menneske1 = new Menneske();
            Hund hund1 = new Hund();
            Sau sau1 = new Sau();
            Apekatt apeatt1 = new Apekatt();
            Slange slange1 = new Slange();
            Edderkopp edderkopp1 = new Edderkopp();
            Frosk frosk1 = new Frosk();
            Mygg mygg1 = new Mygg();
            
            Livsform[] livsformArray = new Livsform [9];
            livsformArray[0] = insekt1;
            livsformArray[1] = menneske1;
            livsformArray[2] = hund1;
            livsformArray[3] = sau1;
            livsformArray[4] = apeatt1;
            livsformArray[5] = slange1;
            livsformArray[6] = edderkopp1;
            livsformArray[7] = frosk1;
            livsformArray[8] = mygg1;


            foreach (Livsform element in livsformArray)
            {
                if (element != null) // Avoid NullReferenceException
                {
                    element.Laglyd();
                }
            }
            Console.ReadLine();
        }
    }
}
