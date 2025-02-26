using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[5, 5]; // 5x5 빙고판
            bool[,] marked = new bool[5, 5]; // 선택된 숫자 표시

            int bingoCount = 0;

            Random rand = new Random();

            // 빙고판 초기화
            int[] numbers = new int[25];

            for (int i = 0; i < 25; i++)
                numbers[i] = i + 1;

            // C#의 튜플(Tuple) 문법을 활용하여 두 변수의 값을 교환(Swap)하는 방법
            for (int i = 0; i < 100; i++)
            {
                int a = rand.Next(25);
                int b = rand.Next(25);

                (numbers[a], numbers[b]) = (numbers[b], numbers[a]);
            }

            // 2차원 배열로 변환
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = numbers[index++];
                }
            }

            // 게임 시작
            while (bingoCount < 5)
            {
                Console.Clear();
                // 빙고판 출력
                Console.WriteLine("현재 빙고판\n");

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write("  ");
                        if (marked[i, j])
                            Console.Write("  X ");
                        else
                            Console.Write($" {board[i, j],2} ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine($"\n현재 빙고 개수 : {bingoCount}");

                // 숫자 입력
                Console.Write("\n숫자를 입력하세요 (1~25) : ");
                int number = int.Parse(Console.ReadLine());

                bool found = false;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j] == number)
                        {
                            marked[i, j] = true; // 숫자를 X로 변경
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }

                // 빙고 개수 체크
                bingoCount = 0;

                // 가로 체크
                for (int i = 0; i < 5; i++)
                {
                    bool rowBinggo = true;

                    // 한 행에서 미표시(false)가 있으면 빙고 X으로 초기화 (false)
                    for (int j = 0; j < 5; j++)
                        if (!marked[i, j]) rowBinggo = false;

                    // 빙고(true)이면 개수 상승
                    if (rowBinggo) bingoCount++;
                }

                // 세로  체크
                for (int j = 0; j < 5; j++)
                {
                    bool colBingo = true;

                    // 한 열에서 미표시(false)가 있으면 빙고 X으로 초기화 (false)
                    for (int i = 0; i < 5; i++)
                        if (!marked[i, j]) colBingo = false;

                    // 빙고(true)이면 개수 상승
                    if (colBingo) bingoCount++;
                }

                // 대각선 체크 (좌상단 -> 우하단)
                bool diag1Bingo = true;
                for (int i = 0; i < 5; i++)
                    if (!marked[i, i]) diag1Bingo = false;
                if (diag1Bingo) bingoCount++;


                // 대각선 체크 (우상단 -> 좌하단)
                bool diag2Bingo = true;
                for (int i = 0; i < 5; i++)
                    if (!marked[i, 4 - i]) diag2Bingo = false;
                if (diag2Bingo) bingoCount++;
            }

            // 빙고 성공
            Console.Clear();
            Console.WriteLine("현재 빙고판\n");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("  ");
                    if (marked[i, j])
                        Console.Write("  X ");
                    else
                        Console.Write($" {board[i, j],2} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("\n빙고 성공");
        }
    }
}
