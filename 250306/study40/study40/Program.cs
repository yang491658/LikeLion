using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study40
{
    class Parent
    {
        public Parent(string message)
        {
            Console.WriteLine("부모 생성자 호출 : " + message); // 실행 2
        }

    }

    class Child : Parent
    {
        public Child() : base("성공") // 실행 1. 부모 생성자 호출
        {
            Console.WriteLine("자식 생성자 호출"); // 실행 3
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child(); // 실행 0. 객체 생성 시작
        }
    }
}
