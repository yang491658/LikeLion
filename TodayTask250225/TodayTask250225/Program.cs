using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250225
{
    class Program
    {
        static void Main(string[] args)
        {
            // 일일 과제 250225 : 나만의 게임 만들기 ~ 조건문, 반복문, 콘솔 좌표
            int w = 100, h = 30, hm = 7;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);

            for (int y = 1; y < h - hm; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 && y == 1)
                        Console.Write("┏");
                    else if (x == w - 1 && y == 1)
                        Console.Write("┓");
                    else if (x == 0 && y == h - hm - 1)
                        Console.Write("┗");
                    else if (x == w - 1 && y == h - hm - 1)
                        Console.Write("┛");
                    else if (x == 0 || x == w - 1)
                        Console.Write("┃");
                    else if (y == 1 || y == h - hm - 1)
                        Console.Write("━");
                    else if (x == (w - 1 - 25) / 2 && y == (h - hm - 1) / 2)
                        Console.Write("2025년 2월 25일 미니게임");
                }
                Console.WriteLine();
            }
            Console.Write("시작하려면 엔터 입력");
            Console.ReadLine();

            int iX = w / 2, iY = (h - hm) / 2;
            int score = 0;
            Random rand = new Random();
            int rX = 0, rY = 0, rnd, rScore = 1;
            string input = default;
            int mX = 6, mY = 2;

            while (true)
            {
                Console.Clear();
                if (rX == 0 || rY == 0)
                {
                    rX = w / 2 + mX * rand.Next(-((w / 2) / mX) + 1, ((w / 2) / mX));
                    rY = (h - hm) / 2 + mY * rand.Next(-((h - hm) / 2 / mY) + 1, ((h - hm) / 2 / mY) + 1);

                    rnd = rand.Next(1, 101);
                    if (rnd <= 10) rScore = 100;
                    else if (rnd <= 30) rScore = 50;
                    else if (rnd <= 60) rScore = 30;
                    else rScore = 10;
                }

                for (int y = 0; y < h - hm; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Console.SetCursorPosition(x, y);
                        if (x == 0 && y == 0)
                            Console.Write($"현재 점수 : " + score);
                        else if (x == 0 && y == 1)
                            Console.Write("┏");
                        else if (x == w - 1 && y == 1)
                            Console.Write("┓");
                        else if (x == 0 && y == h - hm - 1)
                            Console.Write("┗");
                        else if (x == w - 1 && y == h - hm - 1)
                            Console.Write("┛");
                        else if (x == 0 || x == w - 1 && y != 0)
                            Console.Write("┃");
                        else if (y == 1 || y == h - hm - 1)
                            Console.Write("━");
                        else if (x == iX && y == iY)
                            Console.Write("●");
                        else if (x == rX && y == rY)
                            Console.Write(rScore);
                    }
                    Console.WriteLine();
                }

                Console.Write("방향키로 이동하여 점수를 획득하세요! (x를 누르면 종료합니다.)");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.X)
                {
                    Console.WriteLine("\n게임을 종료합니다. 최종 점수 : " + score);
                    break;
                }
                else if (key == ConsoleKey.UpArrow) iY -= mY;
                else if (key == ConsoleKey.DownArrow) iY += mY;
                else if (key == ConsoleKey.LeftArrow) iX -= mX;
                else if (key == ConsoleKey.RightArrow) iX += mX;
                else
                {
                    Console.WriteLine("\n잘못된 명령어입니다. 다시 입력하세요.");
                    Thread.Sleep(500);
                }

                if (iX < 2 || iX > w - 1 || iY < 3 || iY > h - hm - 1)
                {
                    Console.WriteLine("\n세상 밖으로 떨어졌습니다. 최종 점수 : " + score);
                    break;
                }

                if (iX == rX && iY == rY)
                {
                    Console.WriteLine("점수 획득 +100");
                    score += rScore;
                    rX = 0;
                    rY = 0;
                }
            }
        }
    }
}
