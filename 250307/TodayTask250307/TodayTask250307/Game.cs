using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250307
{
    class Game
    {
        int width, height;

        Ball ball = null;
        Bar bar = null;
        Block block = null;

        // 생성자
        public Game(int WIDTH, int HEIGHT)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
        }

        // 벽
        public void ScreenWall()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Program.gotoXY(x, y);
                    if (x == 0 && y == 0) Console.Write("┏");
                    else if (x == width - 1 && y == 0) Console.Write("┓");
                    else if (x == 0 && y == height - 1) Console.Write("┗");
                    else if (x == width - 1 && y == height - 1) Console.Write("┛");
                    else if (x == 0 || x == width - 1) Console.Write("┃");
                    else if (y == 0 || y == height - 1) Console.Write("━");
                }
                Console.WriteLine();
            }
        }

        // 초기화
        public void Initialize()
        {
            // Ball 초기화
            if (ball == null)
            {
                ball = new Ball();
                ball.SetSize(width, height);
                ball.Initialize();
            }

            // Bar 초기화
            if (bar == null)
            {
                bar = new Bar();
                bar.SetSize(width, height);
                bar.Initialize();
            }

            // Block 초기화
            if (block == null)
            {
                block = new Block();
                block.SetSize(width, height);
                block.Initialize();
            }
        }

        // 진행
        public void Progress()
        {
            ball.Progress(bar, block);
            bar.Progress(ball);
        }

        // 출력
        public void Render()
        {
            Console.Clear();
            ScreenWall();
            ball.Render();
            bar.Render();
            block.Render();
        }

        // 종료
        public void Release()
        {
            ball.Release();
            bar.Release();
            block.Release();
        }
    }
}
