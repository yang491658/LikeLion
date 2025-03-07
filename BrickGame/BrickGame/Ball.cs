using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrickGame
{
    public class Ball
    {
        BallData ballData = new BallData();

        // 공의 방향 배열 정의
        int[,] wallCollision = new int[4, 6]
        {
            {  3,  2, -1, -1, -1,  4 }, // 0 : 위쪽 벽
            { -1, -1, -1, -1,  2,  1 }, // 1 : 왼쪽 벽
            { -1,  5,  4, -1, -1, -1 }, // 2 : 오른쪽 벽
            { -1, -1,  1,  0,  5, -1 }  // 3 : 아래 벽
        };

        // 공이 벽에 충돌
        public int Collision(int X, int Y)
        {
            if (Y == 0) // 위쪽 벽
            {
                ballData.direct = wallCollision[0, ballData.direct];
                return 1; // 충돌 발생 시 1 리턴
            }

            if (X == 1) // 왼쪽 벽
            {
                ballData.direct = wallCollision[1, ballData.direct];
                return 1;
            }

            if (X == 78) // 오른쪽 벽
            {
                ballData.direct = wallCollision[2, ballData.direct];
                return 1;
            }

            if (Y == 23) // 아래 벽
            {
                ballData.direct = wallCollision[3, ballData.direct];
                return 1;
            }

            // Bar와 충돌 처리
            if (X >= bar.barData.x[0] - 1
                && X <= bar.barData.x[2] + 1 &&
                Y == bar.barData.y) // Bar 위 충돌
            {
                if (ballData.direct == 1)
                    ballData.direct = 2;
                else if (ballData.direct == 2)
                    ballData.direct = 1;
                else if (ballData.direct == 5)
                    ballData.direct = 4;
                else if (ballData.direct == 4)
                    ballData.direct = 5;

                return 1;
            }

            if (X >= bar.barData.x[0] - 1
                && X <= bar.barData.x[2] + 1 &&
                Y == bar.barData.y + 1) // Bar 위 충돌
            {
                if (ballData.direct == 1)
                    ballData.direct = 2;
                else if (ballData.direct == 2)
                    ballData.direct = 1;
                else if (ballData.direct == 5)
                    ballData.direct = 4;
                else if (ballData.direct == 4)
                    ballData.direct = 5;

                return 1;
            }

            return 0; // 충돌 미발생 시 0 리턴
        }

        // 스크린 벽
        public void ScreenWall()
        {
            int width = 80, height = 25;
            for (int y = 0; y < height - 1; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Program.gotoXY(x, y);
                    if (x == 0 && y == 0) Console.Write("┏");
                    else if (x == width - 1 && y == 0) Console.Write("┓");
                    else if (x == 0 && y == height - 2) Console.Write("┗");
                    else if (x == width - 1 && y == height - 2) Console.Write("┛");
                    else if (x == 0 || x == width - 1) Console.Write("┃");
                    else if (y == 0 || y == height - 2) Console.Write("━");
                }
                Console.WriteLine();
            }
        }

        // 움직이는 바
        Bar bar;
        public void SetBar(Bar BAR) { bar = BAR; }

        // 블럭


        // Getter와 Setter 함수
        public BallData GetBall() { return ballData; }
        public void SetX(int X) { ballData.x += X; }
        public void SetY(int Y) { ballData.y += Y; }
        public void SetBall(BallData BALLDATA) { ballData = BALLDATA; }
        public void SetReady(int READY) { ballData.ready = READY; }

        // 초기화
        public void Initialize()
        {
            ballData.ready = 0; // 0 = 공 움직임 , 1 = 공 멈춤
            ballData.direct = 1;
            ballData.x = 30;
            ballData.y = 10;

            // 커서 숨김
            Console.CursorVisible = false;
        }

        // 진행
        public void Progress()
        {
            if (ballData.ready == 0)
            {
                switch (ballData.direct)
                {
                    case 0: // 위
                        if (Collision(ballData.x, ballData.y - 1) == 0)
                            ballData.y--;
                        break;
                    case 1: // 오른쪽 위
                        if (Collision(ballData.x + 1, ballData.y - 1) == 0)
                        {
                            ballData.x++;
                            ballData.y--;
                        }
                        break;
                    case 2: // 오른쪽 아래
                        if (Collision(ballData.x + 1, ballData.y + 1) == 0)
                        {
                            ballData.x++;
                            ballData.y++;
                        }
                        break;
                    case 3: // 아래
                        if (Collision(ballData.x, ballData.y + 1) == 0)
                            ballData.y++;
                        break;
                    case 4: // 왼쪽 아래
                        if (Collision(ballData.x - 1, ballData.y + 1) == 0)
                        {
                            ballData.x--;
                            ballData.y++;
                        }
                        break;
                    case 5: // 왼쪽 위
                        if (Collision(ballData.x - 1, ballData.y - 1) == 0)
                        {
                            ballData.x--;
                            ballData.y--;
                        }
                        break;
                }
            }
        }

        // 출력
        public void Render()
        {
            ScreenWall();
            Program.gotoXY(ballData.x, ballData.y);
            Console.WriteLine("●");
        }

        // 방출
        public void Realese() { }
    }
}
