using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study38
{
    //class MyResource
    //{
    //    //소멸자
    //    ~MyResource()
    //    {
    //        Console.WriteLine("삭제될 때, 호출");
    //    }
    //}

    class Program
    {
        // ref 메서드 : 포인터 개념의 참조
        static void Increase(ref int x)
        {
            x++;
        }

        // out 메서드 : 반환이 여러개일때 유용 (return의 경우 1개만 반환 가능)
        static void OutFun(int a, int b, out int x, out int y)
        {
            x = a;
            y = b;
        }

        static void Main(string[] args)
        {
            //MyResource r = new MyResource();
            //// GC(가비지 컬렉션)에 의해 나중에 소멸자 호출
            //// GC은 더 이상 참조 되지않는 객체를 정리

            //// ref 메서드
            //int a = 10;
            //Increase(ref a);
            //Console.WriteLine("A의 값 : " + a); // 출력 : 11 ~ ref가 없으면 함수 내 변수만 변화 -> 10이 출력 

            // out 메서드 
            int a = 10, b = 20, x, y;
            OutFun(a, b, out x, out y);
            Console.WriteLine($"X : {x} , Y : {y}");
        }
    }
}
