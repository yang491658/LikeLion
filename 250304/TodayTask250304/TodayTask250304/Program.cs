using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250304
{
    class Warrior
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Strength { get; set; }

        public void Print()
        {
            Console.WriteLine($"이름 : {Name} / 점수 : {Score} / 근력 : {Strength}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 일일 과제 250304-1 : 클래스와 상속
            Warrior warrior = new Warrior() { Name = "홍길동", Score = 100, Strength = 50 };
            warrior.Print();

            // 일일 과제 250304-2 : 예외 처리
            int input;
            while (true)
            {
                try
                {
                    Console.Write("점수를 입력하세요 : ");
                    input = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n입력 값 : " + input);
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\n올바른 숫자를 입력하세요!\n");
                }
            }

            // 일일 과제 250304-3 : 컬렉션 활용
            Console.WriteLine("List 활용");
            List<string> list = new List<string> { "사과", "바나나" };
            list.Add("포도");
            foreach (string value in list) Console.WriteLine(value + " ");

            Console.WriteLine("\nQueue 활용");
            Queue queue = new Queue();
            queue.Enqueue("첫 번째 작업");
            queue.Enqueue("두 번째 작업");
            queue.Enqueue("세 번째 작업");
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());

            Console.WriteLine("\nStack 활용");
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            // 일일 과제 250304-4 : 문자열 처리
            Console.Write("문자열을 입력하세요 : ");
            string str = Console.ReadLine();
            Console.WriteLine("\nHello 시작 :" + str.StartsWith("Hello"));
            Console.WriteLine("C# 포함 :" + str.Contains("C#"));
            Console.WriteLine("World! 끝 :" + str.EndsWith("World!"));
            Console.WriteLine("\n입력 : " + str);
            str = str.ToUpper();
            Console.WriteLine("\n대문자 : " + str);
            str = str.Replace("C#", "CSharp");
            Console.WriteLine("\n변환 : " + str);
            Console.WriteLine("\n길이 : " + str.Length);

            // 일일 과제 250304-5 : LINQ 활용
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var even = numbers.Where(n => n % 2 == 0);
            Console.Write("1~10 중 짝수 : ");
            foreach (var num in even)
                Console.Write(num + " ");
            var sum = numbers.Sum();
            Console.Write("\n1~10 총합 : " + sum);
        }
    }
}
