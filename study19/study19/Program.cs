

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study19
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current Date and Time : {now}"); // 현재 날짜 시간

            TimeSpan duration = new TimeSpan(1, 30, 0); // 1시간 30분
            Console.WriteLine($"Duration : {duration}");
        }
    }
}
