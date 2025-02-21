using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion4
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 변수 선언 후 값 저장
            //string greeting; // 문자열 변수를 선언
            //greeting = "Hello, World!"; // 변수에 값을 저장
            //// 변수의 값을 사용
            //Console.WriteLine(greeting); // 출력: Hello, World!

            //// 변수 선언과 동시에 초기화하기
            //int score = 100; // 정수형 변수 선언과 동시에 100으로 초기화
            //double temperature = 36.5; // 실수형 변수 선언과 초기화
            //string city = "Seoul"; // 문자열 변수 선언과 초기화
            //Console.WriteLine(score); // 출력: 100
            //Console.WriteLine(temperature); // 출력: 36.5
            //Console.WriteLine(city); // 출력: Seoul

            //// 같은 데이터 타입의 변수를 쉼표로 구분해 한 번에 선언
            //int x = 10, y = 20, z = 30; // 정수형 변수 x, y, z를 선언하고 각각 초기화
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //Console.WriteLine(z);

            //// 상수 : 값을 변경할 수 없는 변수
            //const double Pi = 3.14159; // 상수 Pi 선언 및 초기화
            //const int MaxScore = 100; // 정수형 상수 선언
            //Console.WriteLine("Pi : " + Pi);
            //Console.WriteLine("Max Score : " + MaxScore);

            // 중간과제
            int att = 16755, maxHP = 78103, stat1 = 36, stat2 = 1017, stat3 = 41, stat4 = 611, stat5 = 22, stat6 = 30;
            Console.WriteLine("기본 특성");
            Console.WriteLine("공격력 : " + att);
            Console.WriteLine("최대 생명력 : " + maxHP);
            Console.WriteLine("전투 특성");
            Console.WriteLine("치명 : " + stat1);
            Console.WriteLine("특화 : " + stat2);
            Console.WriteLine("제압 : " + stat3);
            Console.WriteLine("신속 : " + stat4);
            Console.WriteLine("인내 : " + stat5);
            Console.WriteLine("숙련 : " + stat6);
        }
    }
}
