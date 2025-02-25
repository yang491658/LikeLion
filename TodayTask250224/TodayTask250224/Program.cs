using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250224
{
    class Program
    {
        static void Main(string[] args)
        {
            // 일일 과제 250224-1 : 세 정수의 최대값
            // 사용자로부터 3개의 정수 입력 받아 그 중  가장 큰 값 출력
            // 3개의 정수 입력 / if문 사용하여 가장 큰 정수 결정 / 결과를 "최대값 : x"의 형식으로 출력
            Console.WriteLine("일일 과제 25024-1");
            Console.Write("첫 번째 정수를 입력하세요. : ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("두 번째 정수를 입력하세요. : ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("세 번째 정수를 입력하세요. : ");
            int c = int.Parse(Console.ReadLine());

            int max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            Console.WriteLine("\n최대값 : " + max);

            Console.Write("\n엔터 입력 시 다음 과제로 넘어갑니다");
            Console.ReadLine();
            Console.Clear();

            // 일일 과제 250224-2 : 점수에 따른 학점 평가
            // 학생의 점수를 입력받아 아래 기준에 따라 학점 출력
            // A학점 : 90 이상
            // B학점 : 80 이상 90 미만
            // C학점 : 70 이상 80 미만
            // D학점 : 60 이상 70 미만
            // F학점 : 60 미만
            Console.WriteLine("일일 과제 25024-1");
            Console.Write("점수를 입력하세요. : ");
            int score = int.Parse(Console.ReadLine());

            char grade = default;
            if (score >= 90)
            {
                grade = 'A';
            }
            else if (score >= 80)
            {
                grade = 'B';
            }
            else if (score >= 70)
            {
                grade = 'C';
            }
            else if (score >= 60)
            {
                grade = 'D';
            }
            else
            {
                grade = 'F';
            }
            Console.WriteLine($"\n학생의 점수 : {score}점 / 학점 : {grade}학점");

            Console.Write("\n엔터 입력 시 다음 과제로 넘어갑니다");
            Console.ReadLine();
            Console.Clear();

            // 일일 과제 250224-3 : 간단한 사칙연산 계산기
            // 사용자로부터 2개의 숫자와 연산자 입력 받아 해당 연산을 수행하고 결과를 출력하는 계산기 프로그램을 작성
            // 2개의 숫자와 연산자 기호 입력 / if문 사용하여 연산자를 확인 수행 / 나눗셈의 경우 0으로 나누는 상황에는 에러 메시지
            Console.WriteLine("일일 과제 25024-1");
            Console.Write("첫 번째 숫자를 입력하세요. : ");
            double num1 = int.Parse(Console.ReadLine());
            Console.Write("두 번째 숫자를 입력하세요. : ");
            double num2 = int.Parse(Console.ReadLine());
            Console.Write("계산하고자 하는 연산자를 입력하세요. + , - , * , /  : ");
            string op = Console.ReadLine();

            double result = default;
            bool isErr = false;
            if (op == "+")
            {
                result = num1 + num2;
            }
            else if (op == "-")
            {
                result = num1 - num2;
            }
            else if (op == "*")
            {
                result = num1 * num2;
            }
            else if (op == "/" && num2 != 0)
            {
                result = num1 / num2;
            }
            else
            {
                isErr = true;
            }

            if (!isErr)
            {
                Console.WriteLine($"\n연산 : {num1} {op} {num2} \n결과 : {result:F3}");
            }
            else
            {
                Console.WriteLine($"\n잘못된 값을 입력하여 에러가 발생했습니다.");
            }
        }
    }
}
