using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 액션
{
    class Program
    {
        // 액션 : 델리게이트와 이벤트를 더 쉽게 만든 것
        static void SayHello()
        {
            Console.WriteLine("안녕하세요");
        }

        static void ShowNotification()
        {
            Console.WriteLine("중요한 알림이 있습니다.");
        }

        static void HelloWorld(string message)
        {
            Console.WriteLine("안녕하세요 " + message);
        }

        static void Main(string[] args)
        {
            // 액션은 매개변수가 없구 반환값이 없는 메서드를 참조
            // 메서드 이름을 변수에 저장한다고 생각
            Action sayHello = SayHello;
            sayHello();

            sayHello += ShowNotification;
            sayHello?.Invoke();

            // 액션의 다양한 활용
            Action<string> h = null;
            h += HelloWorld;
            h?.Invoke("액션");

            // 람다식 사용 가능
            Action noti = null;
            noti += () => Console.WriteLine("인자 없는 액션");
            noti?.Invoke();

            Action<int> Square = number => Console.WriteLine(number * number);
            Square(5);
        }
    }
}
