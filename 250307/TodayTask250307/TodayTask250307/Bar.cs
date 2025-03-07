using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250307
{
    class Bar
    {
        int width, height;

        public int[] x = new int[5];
        public int y;
        public bool catchOn = false;

        public void SetSize(int WIDTH, int HEIGHT)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
        }

        // 초기화
        public void Initialize()
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = width / 2 - x.Length + i;
            }
            y = height * 7 / 10 + 1;
        }

        // 출력
        public void Render()
        {
            for (int i = 0; i < x.Length; i++)
            {
                Program.gotoXY(x[i], y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("■");
                Console.ResetColor();
            }
        }

        // 진행
        public void Progress(Ball BALL)
        {
            int key = 0;

            if (Console.KeyAvailable)
            {
                key = Program._getch(); // 키 눌림 값
                if (key == 224 || key == 0) key = Program._getch();

                switch (key)
                {
                    case 75: // 왼쪽 방향키
                        if (x[0] - 1 <= 0) break;

                        for (int i = 0; i < x.Length; i++) x[i] -= 2;

                        if (!BALL.actOn) BALL.x -= 2;

                        break;
                    case 77: // 오른쪽 방향키
                        if (x[x.Length - 1] + 1 >= width - 1) break;

                        for (int i = 0; i < x.Length; i++) x[i] += 2;

                        if (!BALL.actOn) BALL.x += 2;

                        break;
                    case 32: // 스페이스 : 잡기 혹은 발사
                        // 잡기
                        if (!catchOn)
                            catchOn = true;
                        // 발사
                        else if (catchOn && !BALL.actOn)
                        {
                            catchOn = false;
                            BALL.actOn = true;
                            BALL.directionY = 1;
                        }

                        break;
                    case 27: // ESC : 종료
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // 종료
        public void Release() { }
    }
}
