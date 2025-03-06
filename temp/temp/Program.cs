using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int a;
            while(true)
            {
                a = rand.Next(60,111);
                Console.WriteLine(a);

                if (a == 111) break;
            }
        }
    }
}
