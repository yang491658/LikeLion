using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study29
{
    // 메서드 오버라이딩(Overriding)
    // 부모 클래스의 메서드를 자식 클래스에서 재정의(overriding)하여 다른 동작을 수행
    class Animal
    {
        public string Name { get; set; }
        
        // 가상(virtual) 메서드 : 자식 클래스에서 재정의 가능
        public virtual void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog : Animal
    {
        // 부모 클래스의 메서드를 오버라이딩(재정의)
        public override void Speak()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다.");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Animal();
            myAnimal.Name = "일반 동물";
            myAnimal.Speak(); // 부모 클래스의 기본 메서드 실행

            //Dog myDog = new Dog();
            //myDog.Name = "바둑이";
            //myDog.Speak(); // 오버라이딩된 메서드 실행
        }
    }
}
