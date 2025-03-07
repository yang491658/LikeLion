using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 델리게이트_이벤트
{
    class Program
    {
        // 델리게이트(대리자) 정의 : 메시지 출력을 위한 메서드 참조
        // string 매개변수를 받고 반환값이 없는 void 메서드를 참조할 수 있는 타입

        // 델리게이트 선언
        delegate void MessageHandler(string message);

        // 델리게이트에 연결할 메서드
        // 메서드형과 타입이 일치해야 받아줌
        static void DisplayMessage(string message)
        {
            Console.WriteLine($"메시지 : {message}");
        }

        static void DisplayUpperMessage(string message)
        {
            Console.WriteLine($"대문자 메시지 : {message.ToUpper()}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== 간단한 델리게이트와 이벤트 예제 ===");

            // 1. 델리게이트 사용
            Console.WriteLine("델리게이트 1");

            // 델리게이트 변수 선언 및 메서드 연결
            // DisplayMessage 메서드를 MessageHandler 변수에 할당
            MessageHandler messageHandler = DisplayMessage;

            // 델리게이트 호출 - 연결된 메서드가 실행됨
            messageHandler("안녕하세요");

            // 델리게이트에 다른 메서드 추가 (멀티캐스트 델리게이트)
            // += 연산자로 메서드 추가
            messageHandler += DisplayUpperMessage;

            // 여러 메서드가 연결된 델리게이트 호출
            // 등록된 모든 메서드가 순서대로 호출됨
            Console.WriteLine("여러 메서드 호출");
            messageHandler("Hello");

            // 챗지피티
            // 델리게이트(Delegate)
            // 델리게이트는 메서드를 참조하는 형식(타입)입니다.
            // 쉽게 말해 함수를 가리키는 포인터라고 볼 수 있습니다.

            // 이벤트(Event)
            // 이벤트는 델리게이트의 특수한 형태로, 객체 간의 통신을 위해 사용됩니다.
            // 보통 클래스 내부에서 특정 조건이 발생할 때 외부에서 처리할 수 있도록 하는 기능입니다.
        }
    }
}
