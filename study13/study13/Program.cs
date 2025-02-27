using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study13
{
    class Program
    {
        // 9. params 키워드 : 가변 매개변수
        static int Sum(params int[] numbers)
        {
            int total = 0;

            foreach (int num in numbers)
            {
                total += num;
            }

            return total;
        }

        // 10. 재귀함수 : 자기 자신을 호출
        static void Print()
        {
            Console.WriteLine("나는 재귀함수다.");
            Print(); // 반복문의 기능 , 무한히 반복될 수 있으므로 탈출 조건 필요
        }

        static int Factorial(int n)
        {
            if (n <= 1)
            {
                Console.Write(n + " = ");
                return 1; // 출력 및 탈출
            }

            Console.Write(n + " × ");

            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Sum(1, 2, 3));
            //Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7, 8, 9));

            //Print();

            Console.Write("5! = ");
            Console.WriteLine(Factorial(5)); // Factorial(5) = 5 * 4 * 3 * 2 * 1 = 120
        }
    }
}
