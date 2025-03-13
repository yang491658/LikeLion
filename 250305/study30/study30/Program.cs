using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study30
{
    // 업스캐팅(Upcasting)
    // 자식 클래스 -> 부모 클래스로 변환하는 것
    // 암시적 변환이 가능 (컴파일러가 자동 변환)
    // 안전 : 데이터 손실 없이 변환 가능

    // 다운캐스팅(Downcasting)
    // 불완전함 -> 실행 중 InvalidCastException 발생 가능
    // 키워드(as, is)로 안전하게 변환 가능

    class Animal // 부모 클래스
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog : Animal// 자식 클래스
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Dog myDog = new Dog(); // 자식 클래스 객체 생성
            //Animal myAnimal = myDog; // 업스캐팅 (암시적 변환) : 자식 -> 부모
            //myAnimal.Speak(); // 사용 가능
            ////myAnimal.Bark(); // 사용 불가능 : 업캐스팅 후 자식 클래스의 메서드는 접근 불가

            Animal myAnimal = new Dog(); // 업캐스팅
            Dog myDog = (Dog)myAnimal; // 다운캐스팅 (명시적 변환)
            myDog.Bark(); // 메서드 실행

            //// 안 되는 예
            //Animal myAnimal2 = new Animal();
            //Dog myDog2 = (Dog)myAnimal2;

            // is 키워드 사용
            if (myAnimal is Dog myDog3)
            {
                myDog3.Bark();
            }
            else
            {
                Console.WriteLine("변환 실패");
            }

            // as 키워드 사용
            Dog myDog4 = myAnimal as Dog;
            if (myDog4 != null)
            {
                myDog4.Bark();
            }
            else
            {
                Console.WriteLine("변환 실패");
            }
        }
    }
}
