using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class Bar
    {
        public BarData barData = new BarData();
        int ballCatch; // 공을 잡았는지 체크

        public void Initialize()
        {
            ballCatch = 0;

            barData.x[0] = 12;
            barData.x[1] = 14;
            barData.x[2] = 16;
            barData.y = 18;
        }

        // 공의 객체를 가지고와서 잡았는지 판단하고 움직임도 줘야함
        // -> ref 인자값 전달 참조 
        public void Progress(ref Ball BALL)
        {
            int key = 0;

            if (Console.KeyAvailable)
            {
                key = Program._getch(); // 키 눌림 값
                if (key == 224 || key == 0) key = Program._getch();

                switch (key)
                {
                    case 75: // 왼쪽 
                        if (barData.x[0] - 2 < 0) break;

                        barData.x[0]--;
                        barData.x[1]--;
                        barData.x[2]--;

                        // 공이 잡힌상태
                        if (BALL.GetBall().ready == 1 && ballCatch == 1)
                        {
                            BALL.SetX(-1); // 공이 왼쪽으로 움직이게 값주기
                        }

                        break;
                    case 77: // 오른쪽
                        if (barData.x[2] + 4 > 80) break;

                        barData.x[0]++;
                        barData.x[1]++;
                        barData.x[2]++;

                        // 공이 잡힌상태
                        if (BALL.GetBall().ready == 1 && ballCatch == 1)
                        {
                            BALL.SetX(1);// 공이 오른쪽으로 움직이게 값주기
                        }

                        break;
                    case 'a': // 발사
                        BALL.SetReady(0); // 공이 움직임 

                        ballCatch = 0;

                        break;
                    case 's': // 잡기
                        if (BALL.GetBall().x >= barData.x[0] - 1 &&
                            BALL.GetBall().x <= barData.x[2] + 1 &&
                            BALL.GetBall().y == (barData.y - 1))
                        {
                            BALL.SetReady(1);
                            ballCatch = 1;
                        }

                        break;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Program.gotoXY(barData.x[i], barData.y);
                Console.Write("▥");
                Console.Write("▥");
            }
        }

        public void Release() { }
    }
}
