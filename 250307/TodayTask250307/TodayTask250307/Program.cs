using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250307
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
            int width = 80, height = 25;

            Console.SetWindowSize(width, height + 1);
            Console.SetBufferSize(width, height + 1);
            Console.CursorVisible = false;

            Game game = new Game(width, height);
            game.Initialize();

            int currentTime = Environment.TickCount;

            while (true)
            {
                if (currentTime + 50 < Environment.TickCount)
                {
                    currentTime = Environment.TickCount;

                    game.Progress();
                    game.Render();
                }
            }
        }
    }
}
