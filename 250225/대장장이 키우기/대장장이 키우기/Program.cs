using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 대장장이_키우기
{
    class Program
    {
        static void Main(string[] args)
        {
            // 랜덤
            Random rand = new Random();

            Console.WriteLine(" 대장장이 키우기 ");

            int pmoney = 100;
            int input;
            int rnd;

            Thread.Sleep(500);

            while (true)
            {
                Console.Clear(); // 화면 지우기
                Console.WriteLine("1. 나무캐기");
                Console.WriteLine("2. 장비뽑기");
                Console.WriteLine("3. 나가기");
                input = int.Parse(Console.ReadLine()); // input 변수에 키로 눌린 숫자 저장

                if (input == 1)
                {
                    // 1. 나무캐기
                    while (true)
                    {
                        Console.WriteLine("나무캐기 (엔터)");
                        Console.WriteLine("뒤로가기 x");

                        string str = Console.ReadLine();

                        pmoney += 100;
                        Console.WriteLine("소지금 : " + pmoney);
                        if (str == "x") // x 입력 시 뒤로가기
                        {
                            Console.WriteLine("뒤로가기");
                            break;
                        }
                    }
                }
                else if (input == 2)
                {
                    // 2. 장비뽑기
                    if (pmoney >= 1000) // 소지금 확인 후 뽑기
                    {
                        pmoney -= 1000;

                        for (int i = 1; i <= 20; i++) // 20회 뽑기
                        {
                            rnd = rand.Next(1, 101);
                            if (rnd == 1) // 1퍼센트
                            {
                                Console.WriteLine("도끼등급 SSS");
                            }
                            else if (rnd <= 6) // 5퍼센트
                            {
                                Console.WriteLine("도끼등급 SS");
                            }
                            else if (rnd <= 17) // 11퍼센트
                            {
                                Console.WriteLine("도끼등급 S");
                            }
                            else if (rnd <= 38) // 21퍼센트
                            {
                                Console.WriteLine("도끼등급 A");
                            }
                            else if (rnd <= 69) // 31퍼센트
                            {
                                Console.WriteLine("도끼등급 B");
                            }
                            else // 31퍼센트
                            {
                                Console.WriteLine("도끼등급 C");
                            }
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("돈이 부족합니다. \n");
                        Thread.Sleep(1000);
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("나갑니다.");
                    Environment.Exit(0);
                }
            }
        }
    }
}
