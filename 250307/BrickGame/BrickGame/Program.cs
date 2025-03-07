using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch(); // C언어 함수 가져옴

        public static void gotoXY(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            GameManager gm = new GameManager();
            gm.Initialize();

            int currentTime = Environment.TickCount;

            while (true)
            {
                if (currentTime + 50 < Environment.TickCount)
                {
                    currentTime = Environment.TickCount;

                    gm.Progress();
                    gm.Render();
                }
            }
        }
    }
}
