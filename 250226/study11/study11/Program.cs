using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study11
{
    class Program
    {
        // 메모리 영역
        // 스택(stack)
        // 힙(heap)
        // 정적 메모리(static memory)

        //static int count = 0; // 정적 메모리에 저장됨
        //// 프로그램 종료 전까지 유지됨
        //int instan = 200;

        //// 1단계 기본형
        //static void Loading()
        //{
        //    Console.WriteLine("로딩 화면");

        //    Console.WriteLine("로딩중.");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("로딩중..");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("로딩중...");
        //    Thread.Sleep(1000);
        //}

        //// 2단계 입력
        //static void AttackFuntion(int _Attack)
        //{
        //    Console.WriteLine("공격력 : " + _Attack);
        //}

        //// 3단계 출력
        //static int BaseAttack()
        //{
        //    int attack = 10;
        //    return attack;
        //}

        //// 예시
        //static int Add(int num1, int num2)
        //{
        //    return num1 + num2;
        //}

        static void Main(string[] args)
        {
            //// 사용가능
            //count++;
            //Console.WriteLine(count);
            //// 사용 불가능 (에러)
            //Console.WriteLine(instan);

            //// 1단계 기본형
            //Loading(); // 함수 호출, 반복해서 여러번 사용 가능
            //Console.WriteLine("게임이 시작됩니다.");
            //Console.ReadLine();

            //// 2단계 입력
            //int Attack = 0;
            //Console.Write("캐릭터의 공격력을 입력 :");
            //Attack = int.Parse(Console.ReadLine());
            //AttackFuntion(Attack);

            //// 3단계 출력
            //int bAttack = 0;
            //bAttack = BaseAttack();
            //AttackFuntion(bAttack + Attack);

            //// 예시 : 두 수의 합을 구하는 함수
            //int result = Add(10, 20);
            //Console.WriteLine($"10 + 20 = {result}");

            // 배열의 반복문 : foreach
            string[] fruits = { "사과", "바나나", "체리" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}
