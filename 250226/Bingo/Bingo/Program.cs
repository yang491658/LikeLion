using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[25];

            //// 스왑
            //int a = 10;
            //int b = 20;
            //int t = 0;
            //t = a; a = b; b = t;
            //Console.WriteLine($"a : {a} / b : {b}");

            for (int i = 0; i < 25; i++)
            {
                iArray[i] = i + 1;
            }

            // 1차원 배열을 사용한 2차원 배열처럼 표현
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(iArray[i * 5 + j].ToString("D2") + " ");
                }
                Console.WriteLine();
            }

            // 셔플 - 스왑의 활용
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int iA = rand.Next(0, 25);
                int iB = rand.Next(0, 25);
                int iT = 0;

                iT = iArray[iA];
                iArray[iA] = iArray[iB];
                iArray[iB] = iT;
            }

            int input = 0;
            int iBingo = 0;
            int iCount = 0;

            while (true)
            {
                Console.Clear();

                // 빙고판
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i * 5 + j] == 0) // 0일 경우 표시
                        {
                            Console.Write(" * ");
                        }
                        else
                        {
                            Console.Write(iArray[i * 5 + j].ToString("D2") + " ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n빙고 : " + iBingo);

                // 숫자 입력
                Console.WriteLine("\n숫자를 입력하세요. : ");
                input = int.Parse(Console.ReadLine());
                for (int i = 0; i < 25; i++)
                {
                    if (iArray[i] == input)
                    {
                        iArray[i] = 0;
                        break;
                    }
                }

                // 빙고 체크
                iBingo = 0;

                // 가로
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i * 5 + j] == 0)
                        {
                            ++iCount;
                        }
                        if (iCount == 5)
                        {
                            ++iBingo;
                        }
                    }
                    iCount = 0;
                }

                // 세로
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (iArray[i + j * 5] == 0)
                        {
                            ++iCount;
                        }
                        if (iCount == 5)
                        {
                            ++iBingo;
                        }
                    }
                    iCount = 0;
                }

                // 대각선 1 - 오른쪽 위
                for (int i = 0; i < 5; i++)
                {
                    if (iArray[i * 4 + 4] == 0)
                    {
                        ++iCount;
                    }
                    if (iCount == 5)
                    {
                        ++iBingo;
                    }
                }
                iCount = 0;

                // 대각선 2 - 오른쪽 아래
                for (int i = 0; i < 5; i++)
                {
                    if (iArray[i * 6] == 0)
                    {
                        ++iCount;
                    }
                    if (iCount == 5)
                    {
                        ++iBingo;
                    }
                }
                iCount = 0;

                // 빙고 체크
                if (iBingo >= 5)
                {
                    Console.Clear();
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (iArray[i * 5 + j] == 0) // 0일 경우 표시
                            {
                                Console.Write(" * ");
                            }
                            else
                            {
                                Console.Write(iArray[i * 5 + j].ToString("D2") + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n빙고 성공");
                    break;
                }
            }
        }
    }
}
