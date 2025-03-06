using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study43
{
    // 인터페이스(Interface)
    // 클래스나 구조체에서 구현해야하는 메서드, 속성 등을 정의하는 추상적인 개념
    // 즉, 어떤 기능을 반드시 포함하도록 강제하는 역할

    // 인터페이스 특징
    // interface 키워드 사용
    // 추상 메서드만 포함 (구현x) -> 인터페이스를 구현하는 클래스에서 반드시 구현
    // 다중 상속 가능 (클래스는 다중 상속 불가능, 인터페이스는 가능)
    // 객체 생성 불가능 (추상 클래스와 유사)

    // 인터페이스 정의
    interface Animal
    {
        void MakeSound();
    }

    // 인터페이스 구현 (클래스에 반드시 구현)
    class Dog : Animal
    {
        public void MakeSound()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Cat : Animal
    {
        public void MakeSound()
        {
            Console.WriteLine("야옹!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog();
            dog.MakeSound();

            Animal cat = new Cat();
            cat.MakeSound();
        }
    }
}
