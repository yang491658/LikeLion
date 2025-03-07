using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250307
{
    class Ball
    {
        int width, height;

        public bool actOn;
        public int x;
        public int y;
        public int directionX;
        public int directionY;

        public void SetSize(int WIDTH, int HEIGHT)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
        }

        // 초기화
        public void Initialize()
        {
            actOn = true; // 0 = 공 멈춤 , 1 = 공 움직임
            x = width / 2;
            y = height * 7 / 10;
            directionX = -1; // -1 , 0 , +1
            directionY = -1; // -1 , +1
        }

        // 출력
        public void Render()
        {
            Program.gotoXY(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("●");
            Console.ResetColor();
        }

        // 진행
        public void Progress(Bar BAR, Block BLOCK)
        {
            if (actOn)
            {
                // 충돌
                Collision(BAR, BLOCK);

                // Ball 이동
                x += directionX;
                y += directionY;
            }
        }

        // 충돌
        public void Collision(Bar BAR, Block BLOCK)
        {
            // 좌우 충돌 -> 방향 전환
            if (x <= 1 || x >= width - 2)
                directionX *= -1;

            // 상하 충돌 -> 방향 전환
            if (y <= 1 || y >= height - 2)
                directionY *= -1;

            // 바 충돌
            if (x >= BAR.x[0] - 1 && x <= BAR.x[BAR.x.Length - 1] + 1 && y == BAR.y)
            {
                if (BAR.catchOn && directionY == 1) actOn = false;
                directionY *= -1;
            }

            // 블럭 충돌
            for (int i = 0; i < BLOCK.x.Length; i++)
            {
                // 블럭 위 충돌
                if (x == BLOCK.x[i] && y >= BLOCK.y[i] - 1 && y <= BLOCK.y[i])
                {
                    directionY *= -1;
                    BLOCK.Create(ref BLOCK.x[i], ref BLOCK.y[i]);
                }
                // 블럭 아래 충돌
                else if (x == BLOCK.x[i] && y >= BLOCK.y[i] && y <= BLOCK.y[i] + 1)
                {
                    directionY *= -1;
                    BLOCK.Create(ref BLOCK.x[i], ref BLOCK.y[i]);
                }
                // 블럭 왼쪽 충돌
                else if (x == BLOCK.x[i] - 1 && y == BLOCK.y[i])
                {
                    directionX *= -1;
                    BLOCK.Create(ref BLOCK.x[i], ref BLOCK.y[i]);
                }
                // 블럭 오른쪽 충돌
                else if (x == BLOCK.x[i] + 1 && y == BLOCK.y[i])
                {
                    directionX *= -1;
                    BLOCK.Create(ref BLOCK.x[i], ref BLOCK.y[i]);
                }
            }
        }

        // 종료
        public void Release() { }
    }
}
