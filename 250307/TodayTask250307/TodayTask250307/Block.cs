using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250307
{
    class Block
    {
        int width, height;

        Random rand = new Random();

        public int[] x;
        public int[] y;
        public int count = 15;

        public void SetSize(int WIDTH, int HEIGHT)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
        }

        // 초기화
        public void Initialize()
        {
            x = new int[count];
            y = new int[count];

            for (int i = 0; i < count; i++)
            {
                Create(ref x[i], ref y[i]);
            }
        }

        public void Create(ref int X, ref int Y)
        {
            X = rand.Next(2, width - 3);
            Y = rand.Next(2, height - 2);
        }

        // 출력
        public void Render()
        {
            for (int i = 0; i < count; i++)
            {
                Program.gotoXY(x[i], y[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■");
                Console.ResetColor();
            }
        }

        // 종료
        public void Release() { }
    }
}
