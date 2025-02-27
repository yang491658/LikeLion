using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250227_ShootingGame
{
    struct Player
    {
        public int playerX;
        public int playerY;
        public string[] plane;
        public Player(int x = 0, int y = 12) // 생성자
        {
            playerX = x;
            playerY = y;
            plane = new string[]
            {
                    "->",
                    ">>>",
                    "->"
            };
        }

        public void Move(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (playerY > 0) playerY--; break;
                case ConsoleKey.DownArrow: if (playerY < Console.WindowHeight - plane.Length) playerY++; break;
                case ConsoleKey.LeftArrow: if (playerX > 0) playerX--; break;
                case ConsoleKey.RightArrow: if (playerX < Console.WindowWidth - 3) playerX++; break;
                case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
                case ConsoleKey.Escape: return;
            }
        }

        public void Print()
        {
            for (int i = 0; i < plane.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(plane[i]);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); // 콘솔 창 크기 설정 (가로 80 세로 25)
            Console.SetBufferSize(80, 25); // 버퍼 크기도 동일하게 설정 (스크롤 방지)
            Console.CursorVisible = false;

            Player player = new Player(0, 3);

            ConsoleKeyInfo keyInfo;

            // 시간 1초 루프
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long prevSecond = stopwatch.ElapsedMilliseconds; // 이전 시간 (1ms 단위)

            while (true)
            {
                long currentSecond = stopwatch.ElapsedMilliseconds; // 현재 시간 가져오기

                if (currentSecond - prevSecond >= 100)
                {
                    Console.Clear();
                    if (Console.KeyAvailable)
                    {

                        keyInfo = Console.ReadKey(true); // 키 입력 받기 (화면 출력 x)
                        player.Move(keyInfo);
                        player.Print();

                        prevSecond = currentSecond; // 이전 시간 업데이트
                    }
                }
            }
        }
    }
}

