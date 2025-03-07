using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study9
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 조건문 switch
            //int day = 3;
            //switch (day)
            //{
            //    case 1:
            //        Console.WriteLine("월요일");
            //        break;
            //    case 2:
            //        Console.WriteLine("화요일");
            //        break;
            //    case 3:
            //        Console.WriteLine("수요일");
            //        break;
            //    case 4:
            //        Console.WriteLine("목요일");
            //        break;
            //    case 5:
            //        Console.WriteLine("금요일");
            //        break;
            //    default:
            //        Console.WriteLine("주말");
            //        break;
            //} // 결과 출력 : 수요일

            //// 예시 : 캐릭턴 선택
            //Console.Write("캐릭터를 선택해주세요. (1. 검사  2. 마법사  3. 도적) : ");
            //int input = int.Parse(Console.ReadLine());
            //string job = default;
            //int att = default, def = default;
            //switch (input)
            //{
            //    case 1: 
            //        job = "검사";
            //        att = 100; 
            //        def = 90;
            //        break;
            //    case 2: 
            //        job = "마법사";
            //        att = 110; 
            //        def = 80;
            //        break;
            //    case 3:
            //        job = "도적";
            //        att = 1115;
            //        def = 70;
            //        break;
            //    default:
            //        break;
            //}
            //Console.WriteLine($"\n{job} \n공격력 : {att} \n방어력 : {def}");

            //// 반복문 for
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("숫자 : " + i);
            //}

            //// 무한 루프
            //for (; ; )
            //{
            //    Console.WriteLine("중요한건 꺽이지 않는 마음");
            //}

            //// 예시 : 0부터 9까지 출력
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //// 예시 : 1 ~ 10의까지 합
            //int sum = 0;
            //for (int i = 1; i <= 10; i++)
            //{
            //    sum += i; // sum = sum + i
            //    Console.WriteLine($"1부터 {i}까지의 합 : {sum}");
            //}
            //Console.WriteLine("\n1부터 10까지의 합 : " + sum);

            //// 반복문 while
            //int count = 1; // 초기화
            //while (count <= 5) // 조건식
            //{
            //    Console.WriteLine("Count : " + count);
            //    count++; // 증가, 감소

            //    if (count == 3)
            //    {
            //        Console.WriteLine("3일때, 반복문 탈출");
            //        break;
            //    }
            //}
            //Console.WriteLine("Count : " + count);

            //// 랜덤값
            //Random rand = new Random(); // Random 객체를 생성한다.
            //// 0 이상 10 미만의 랜덤 정수 생성
            //for (int i = 0; i < 10; i++)
            //{
            //    int randomNumber = rand.Next(0, 10); // 0 ~ 9
            //    Console.WriteLine("0 이상 10 미만의 랜덤 정수 : " + randomNumber);
            //}
            //// 랜덤 실수
            //for (int i = 0; i < 10; i++)
            //{
            //    double randomNumber = rand.NextDouble();
            //    Console.WriteLine(randomNumber);
            //}
            //// 특정 범위
            //for (int i = 0; i < 10; i++)
            //{
            //    int randomNumber = rand.Next(5, 15);
            //    Console.WriteLine("5부터 14까지 : " + randomNumber);
            //}

            //// 예시 : 대장장이 키우기
            //// 도끼등급 SSS (10%) , SS (40%) , S (50%)
            //Random rand = new Random();
            //int rnd = 0;
            //for (int i = 0; i < 20; i++)
            //{
            //    rnd = rand.Next(1, 101); // 1~100
            //    if (rnd <= 10)
            //    {
            //        Console.WriteLine("도끼 등급 SSS");
            //    }
            //    else if (rnd <= 40)
            //    {
            //        Console.WriteLine("도끼 등급 SS");
            //    }
            //    else
            //    {
            //        Console.WriteLine("도끼 등급 S");
            //    }
            //    Thread.Sleep(500);
            //}

            //// 반복문 do while : 한 번은 반드시 실행, 그 후 while문과 동일
            //int x = 5;
            //do
            //{
            //    Console.WriteLine("최소 한 번은 실행됩니다.");
            //    x--;
            //} while (x > 0);

            //// 반복문 제어 : 중단 break
            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i == 5)
            //        break;
            //    Console.WriteLine(i);
            //}

            //// 반복문 제어 : 건너뛰기 continue
            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i % 2 == 0) // 짝수는 건너뛰기
            //        continue;
            //    Console.WriteLine(i); // 홀수만 출력
            //}

            // 반복문 제어 : 레이블 이동 goto
            int n = 1;
start:
            if (n <= 5)
            {
                Console.WriteLine(n);
                n++;
                goto start; // 레이블로 이동
            }
        }
    }
}
