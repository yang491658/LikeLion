using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace study22
{
    // 클래스 시그니처 기본 구성
    // 클래스 시그니처는 클래스의 선언부를 의미 : 이름, 접근 제한자, 상속 여부
    // [접근 지정자] [수정자] class 클래스명 : 부모클래스 , 인터페이스
    // public        abstract                : BaseClass  , IComparable
    // private       sealed
    // protected     static
    //               partial

    // 기본 클래스
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    // 상속 클래스
    public class Warrior : Player
    {
        public int Strength { get; set; }
    }

    //// 인터페이스
    //public class Enemy : IAttackable, IMoveable
    //{
    //    public void Attack() { }
    //    public void Move() { }
    //}

    // 추상 클래스 abstract
    public abstract class Animal
    {
        public abstract void MakeSound();
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// 내장 클래스 Environment
            //string path = Environment.GetEnvironmentVariable("PATH");
            //Console.WriteLine($"PATH : {path}");

            //Console.WriteLine("프로그램 종료");
            //Environment.Exit(0);

            //// 내장 클래스 Random
            //Random random = new Random();
            //int randomNumber = random.Next(1, 101);
            //Console.WriteLine("랜덤 숫자 : " + randomNumber);

            //// 내장 클래스 Stopwatch
            //// 프로그램 실행 시간 구하기
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //// 실행 코드
            //for (int i = 0; i < 100; i++) { Thread.Sleep(1); }
            //stopwatch.Stop();
            //Console.WriteLine($"for 시간 : {stopwatch.ElapsedMilliseconds}ms");

            // 정규식 Regex
            string input = "Hello, my phone number is 010-1234-5678.";
            string pattern = @"\d{3}-\d{4}-\d{4}";
            bool isMatch = Regex.IsMatch(input, pattern);
            Console.WriteLine($"전화번호가 존재하는가 ? : {isMatch}");
        }
    }
}
