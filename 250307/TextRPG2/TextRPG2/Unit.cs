using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG2
{
    public class Unit
    {
        public string name { get; set; }
        public int health { get; set; }
        public int damage { get; set; }

        public void Print()
        {
            Console.WriteLine($"==============================");
            Console.WriteLine($"직업 : {name}\n체력 : {health}  데미지 : {damage}");
        }
    }
}
