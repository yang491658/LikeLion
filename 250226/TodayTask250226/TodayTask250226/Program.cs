using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250226
{
    class Program
    {
        // 일일 과제 250226-7 : 두 수의 합 함수
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }

        // 일일 과제 250226-8 : 문자열 길이 반환 함수
        static int length(string text)
        {
            return text.Length;
        }

        // 일일 과제 250226-9 : 가장 큰 수 반환 함수
        static int maximum(int[] num)
        {
            int temp = 0;
            for (int i = 0; i < num.Length; i++)
                temp = temp > num[i] ? temp : num[i];
            return temp;
        }

        static void Main(string[] args)
        {
            // 일일 과제 250226-1 : 배열 요소
            // 크기가 5인 정수 배열 10~50 저장 후 출력
            int[] num1 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                num1[i] = (i + 1) * 10;
                Console.Write(num1[i] + " ");
            }

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-2 : 배열 요소 합
            // 사용자가 5개의 정수 입력하여 배열 저장, 모든 수의 합 출력
            int[] num2 = new int[5];
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write((i + 1) + "번째 정수를 입력하세요 : ");
                num2[i] = int.Parse(Console.ReadLine());
                sum += num2[i];
            }
            Console.WriteLine("\n정수의 합 : " + sum);

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-3 : 최대값 찾기
            // 정수 배열 { 3, 8, 15, 6, 2 } 중 가장 큰 값
            int[] num3 = { 3, 8, 15, 6, 2 };
            int max = 0;
            for (int i = 0; i < num3.Length; i++)
            {
                max = num3[i] > max ? num3[i] : max;
                Console.Write(num3[i] + " ");
            }
            Console.WriteLine("중 최대값 : " + max);

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-4 : for문
            // for문을 사용하여 1부터 10까지 출력
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + 1 + " ");
            }

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-5 : while문
            // while문을 사용하여 1부터 10까지 짝수만 출력
            int index = 1;
            while (index <= 10)
            {
                if (index % 2 == 0)
                    Console.Write(index + " ");
                index++;
            }

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-6 : foreach문
            // foreach문을 사용하여 배열 { 1, 2, 3, 4, 5 } 출력
            int[] numbers = { 1, 2, 3, 4, 5 };
            foreach (int number in numbers)
            {
                Console.WriteLine(number + " ");
            }

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-7 : 두 수의 합 함수
            // 두 개의 정수를 입력받아 합을 반환하는 함수 작성
            Console.Write("첫 번째 정수를 입력하세요 : ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("두 번째 정수를 입력하세요 : ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n{a}과 {b}의 합 : {add(a, b)}");

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-8 : 문자열 길이 반환 함수
            // 문자열을 입력받아 길이를 반환하는 함수
            Console.Write("문자열 입력 : ");
            string text = Console.ReadLine();
            Console.WriteLine("문자열 길이 : " + length(text));

            Thread.Sleep(1000);
            Console.Clear();

            // 일일 과제 250226-9 : 가장 큰 수 반환 함수
            // 세 개의 정수를 입력받아 가장 큰 값을 반환하는 함수
            int[] num9 = new int[3];
            for (int i = 0; i < num9.Length; i++)
            {
                Console.Write(i + 1 + "번째 정수를 입력하세요 : ");
                num9[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n가장 큰 수 : " + maximum(num9));
        }
    }
}
