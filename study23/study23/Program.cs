using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study23
{
    class Program
    {
        static void Main(string[] args)
        {
            // 값 형식과 참조 형식
            // 값 형식은 스택에 저장되고, 참조 형식은 힙에 저장
            //int valueType = 10;
            //object referenceType = valueType;
            //valueType = 20;
            //Console.WriteLine($"Value Type : {valueType}");
            //Console.WriteLine($"Reference Type : {referenceType}");

            //// 박싱과 언박싱
            //// 박싱 : 값 형식을 참조 형식으로 변환
            //// 언박싱 : 다시 값 형식으로 변환
            //int value = 42;
            //object boxed = value; // 박싱
            //int unboxed = (int)boxed; // 언박싱
            //Console.WriteLine($"Boxed : {boxed} / Unboxed : {unboxed}");

            //// is 연산자 : 형식 비교
            //// 객체가 특정 형식인지 확인
            //object obj = "Hello";
            //Console.WriteLine(obj is string);
            //Console.WriteLine(obj is int);

            //// as 연산자 : 형식 변환
            //// 안전하게 형 변환을 수행
            //object obj = "Hello";
            //string str = obj as string;
            //Console.WriteLine(obj is string);
            //Console.WriteLine(str is string);

            //// object (class) vs var (struct)
            //var obj = 42;
            //if (obj is int number)
            //    Console.WriteLine($"Number : {number}");
            //else
            //    Console.WriteLine("Not a Number");

            //// 문자열 다루기
            //string greeting = "Hello";
            //string name = "Alice";
            //string message = greeting + ", " + name + "!";
            //Console.WriteLine(message);
            //Console.WriteLine($"Length of name : {name.Length}"); // 문자열 길이
            //Console.WriteLine($"To Upper : {name.ToUpper()}"); // 대문자 변환
            //Console.WriteLine($"Substring : {name.Substring(1)}"); // 부분 문자열

            //// string 다양한 메서드
            //string text = "C# is awesome!";
            //Console.WriteLine($"Cotains 'awesome' : {text.Contains("awesome")}"); // 문자열 내 단어 판별
            //Console.WriteLine($"Starts with 'C#' : {text.StartsWith("C#")}"); // 문자열 시작 단어 판별
            //Console.WriteLine($"Ends with '!': {text.EndsWith("!")}"); // 문자열 끝 단어 판별
            //Console.WriteLine($"Index of 'is' : {text.IndexOf("is")}"); // 문자열 내 단어 위치
            //Console.WriteLine($"Replace 'awesome' with 'great' : {text.Replace("awesome", "great")}"); // 문자열 내 단어 대체

            //// StringBuilder 클래스
            //StringBuilder sb = new StringBuilder("Hello");
            //sb.Append(", "); // 문자열 추가
            //sb.Append("World!");
            //Console.WriteLine(sb.ToString());

            //// String과 StringBuilder 성능차이 비교
            //// 반복적으로 문자열 수정 : StringBuilder가 효율적
            //int iterations = 10000;
            //Stopwatch sw = Stopwatch.StartNew();
            //string text = "";
            //for (int i = 0; i < iterations; i++) text += "a";
            //sw.Stop();
            //Console.WriteLine($"String : {sw.ElapsedMilliseconds}ms");
            //sw.Restart();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < iterations; i++) sb.Append("a");
            //sw.Stop();
            //Console.WriteLine($"StringBuilder : {sw.ElapsedMilliseconds}ms");

            //// 예외 처리하기 try catch
            //// 예외는 프로그램 실행 중 발생하는 오류
            //// 예외 처리를 하면 프로그램이 중단되지 않고 계속 실행
            //try
            //{
            //    int[] number = { 1, 2, 3 };
            //    Console.WriteLine(number[5]); // 오류 발생
            //}
            //catch (IndexOutOfRangeException ex)
            //{
            //    Console.WriteLine($"Error : {ex.Message}");
            //}

            //// 예외 발생 여부와 상관없이 항상 실행 finally
            //try
            //{
            //    int number = int.Parse("Not A Number");
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine($"Format Error : {ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("항상 실행됩니다.");
            //}

            //// Exception 클래스
            //// 모든 예외의 기본 클래스
            //try
            //{
            //    int number = int.Parse("abd");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"General Error : {ex.Message}");
            //}

            //// throw 구문으로 직접 예외 발생
            //try
            //{
            //    int age = -5;
            //    if (age < 0)
            //    {
            //        throw new ArgumentException("Age cannot be negative");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exception : {ex.Message}");
            //}

            // 
        }
    }
}
