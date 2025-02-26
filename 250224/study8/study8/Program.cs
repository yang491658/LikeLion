using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study8
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 관계형 연산자
            //// 두 값을 비교하여 관계를 평가
            //// == 같다 , != 같지않다 , < , > , <= , >= 
            //int x = 5, y = 10;
            //Console.WriteLine(x == y); // False
            //Console.WriteLine(x != y); // True
            //Console.WriteLine(x < y); // True
            //Console.WriteLine(x > y); // False
            //Console.WriteLine(x >= y); // False
            //Console.WriteLine(x <= y); // True

            //// 논리 연산자
            //bool a = true, b = false;
            //// AND (논리곱) : 둘 다 True일 경우 True, 그 외 False
            //// 1 && 1 = True , 1 && 0 = False , 0 && 1 = False , 0 && 0 = False ~ 곱하기
            //Console.WriteLine(a && b); // 출력 : False
            //// OR (논리합) : 둘 중 하나라도 True일 경우 True, 그 외 False
            //// 1 || 1 = True , 1 || 0 = True , 0 || 1 = True , 0 || 0 = False ~ 더하기
            //Console.WriteLine(a || b); // 출력 : True
            //// NOT (부정)
            //Console.WriteLine(!a); // False

            //// 비트 연산자
            //int x = 5; // 0101
            //int y = 3; // 0011
            //Console.WriteLine(x & y); // AND : 1 (0001)
            //Console.WriteLine(x | y); // OR : 7 (0111)
            //Console.WriteLine(x ^ y); // XOR : 6 (0110) : 둘의 값이 다를 경우 True, 같은 경우 False
            //Console.WriteLine(~x); // NOT : -6 (1111 1010)

            //// 시프트 연산자 : 비트의 좌우 이동
            //int value = 4; // 0100
            //Console.WriteLine(value << 1); // 왼쪽 이동 : 8 (1000) ~ 곱하기 2
            //Console.WriteLine(value >> 1); // 왼쪽 이동 : 2 (0010) ~ 나누기 2 (나머지 버림)

            //// 기타 연산자
            //int a = 10, b = 20;
            //int max = (a > b) ? a : b; // 삼항 연산자 ~ (비교) ? (참일 경우) : (거짓일 경우)
            //Console.WriteLine(max); // 출력 : 20 ~ a > b가 False이므로 max = b가 적용됨
            //// 예시
            //int key = 1;
            //string str;
            //str = (key == 2) ? "문이 열렸습니다." : "문을 열지 못했습니다.";
            //Console.WriteLine(str);

            //// 연산자 우선순위
            //int result = 10 + 2 * 5; // 곱셈이 덧셈보다 우선
            //Console.WriteLine(result); // 출력 : 20
            //int adjustedResult = (10 + 2) * 5; // 괄호로 우선순위 변경
            //Console.WriteLine(adjustedResult); // 출력 : 60

            //// 제어문 - 조건문
            //int score = 85;
            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else
            //{
            //    Console.WriteLine("90점 미만");
            //}
            //// 예시
            //string GameID = "가나다라";
            //if (GameID == "가나다라")
            //{
            //    Console.WriteLine("아이디가 일치합니다.");
            //}
            //else
            //{
            //    Console.WriteLine("아이디가 일치하지 않습니다.");
            //}
            //// 다중 조건
            //int score = 75;
            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else if (score >= 80)
            //{
            //    Console.WriteLine("B 학점");
            //}
            //else if (score >= 70)
            //{
            //    Console.WriteLine("C 학점");
            //}
            //else
            //{
            //    Console.WriteLine("F 학점");
            //}

            // 중간 과제 1
            // 가지고 있는 소지금 입력
            // 0~100 무한의 대검 +1 / 101~200 카타나 +2 / 201~300 진은검 +3 / 301~400 집판검 +4
            // 401~500 엑스칼리버 +5 / 501~600 유령검 +6 / 601~ 전설의 검 +7
            Console.Write("소지금을 입력하세요 : ");
            int money = int.Parse(Console.ReadLine());
            string weapon = default;
            int attakcBonus = default;
            if (0 <= money && money <= 100)
            {
                weapon = "무한의 대검";
                attakcBonus = 1;
            }
            else if (money <= 200)
            {
                weapon = "카타나";
                attakcBonus = 2;
            }
            else if (money <= 300)
            {
                weapon = "진은검";
                attakcBonus = 3;
            }
            else if (money <= 400)
            {
                weapon = "집판검";
                attakcBonus = 4;
            }
            else if (money <= 500)
            {
                weapon = "엑스칼리버";
                attakcBonus = 5;
            }
            else if (money <= 600)
            {
                weapon = "유령검";
                attakcBonus = 6;
            }
            else
            {
                weapon = "전설의 검";
                attakcBonus = 7;
            }
            Console.WriteLine($"{weapon} 획득");
            // 중간 과제 2
            // 캐릭터 이름 : 멋사검존 / 무기 / 공격력 : 100 + ?
            Console.WriteLine("\n캐릭터명 : 멋사검존");
            Console.WriteLine($"무기 : {weapon}");
            Console.WriteLine($"공격력 : 100 + {attakcBonus}");
        }
    }
}
