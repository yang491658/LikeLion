using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion5
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 숫자 데이터 형식 : 정수와 실수를 다룰 때 사용하는 다양한 타입
            //int integerNum = 10; // 정수 데이터
            //float floatNum = 3.14f; // 단정밀도 실수
            //double doubleNum = 3.14159; // 배정밀도 실수
            //Console.WriteLine(integerNum); Console.WriteLine(floatNum); Console.WriteLine(doubleNum);

            //// 정수 데이터 형식 : 소수점이 없는 숫자를 표현
            //int intValue = -100; // 4바이트 크기의 정수
            //long longValue = 1234567890L; // 8바이트 크기의 정수
            //Console.WriteLine(intValue); // 출력 : -100
            //Console.WriteLine(longValue); // 출력 : 1234567890

            // 1비트 : 0 , 1
            // 1byte = 8비트 : 00000000

            //// 부호 있는 정수 : 음수와 양수를 모두 표현 가능
            //sbyte signedByte = -50; // 1바이트 크기
            //short signedShort = -32000; // 2바이트 크기
            //int signedInt = -2000000000; // 4바이트 크기
            //Console.WriteLine(signedByte); // 출력 : -50
            //Console.WriteLine(signedShort); // 출력 : -32000
            //Console.WriteLine(signedInt); // 출력 : -2000000000

            //// 부호 없는 정수 : 0 이상의 정수만 표현 가능
            //byte unsignedByte = 255; // 1바이트 크기
            //ushort unsignedShort = 65000; // 2바이트 크기
            //uint unsignedInt = 4000000000; // 4바이트 크기
            //Console.WriteLine(unsignedByte); // 출력 : 255
            //Console.WriteLine(unsignedShort); // 출력 : 65000
            //Console.WriteLine(unsignedInt); // 출력 : 4000000000

            //// 실수 데이터 형식 : 소수점을 포함한 숫자를 표현
            //float singlePrecision = 3.14f; // 단정밀도 실수 (4바이트)
            //double doublePrecision = 3.1415926535; // 배정밀도 실수 (8바이트)
            //decimal highPrecision = 3.1415926535897932384626433833m; // 고정밀도 실수 (16바이트)
            //Console.WriteLine(singlePrecision);
            //Console.WriteLine(doublePrecision);
            //Console.WriteLine(highPrecision);

            //// 접미사 사용 : 숫자의 데이터 형식을 명시
            //int integerValue = 100; // 기본 정수형 (int)
            //long longValue = 100L; // 정수형 (long)
            //float floatValue = 3.14f; // 실수형 (float)
            //double doubleValue = 3.14; // 기본 실수형 (double)
            //decimal decimalValue = 3.14m; // 고정밀도 실수형 (decimal)
            //Console.WriteLine(integerValue);
            //Console.WriteLine(longValue);
            //Console.WriteLine(floatValue);
            //Console.WriteLine(doubleValue);
            //Console.WriteLine(decimalValue);

            //// char 형식 : 단일 문자를 표현
            //char letter = 'A'; // 문자 'A' 저장
            //char symbol = '#'; // 특수 기호 저장
            //char number = '9'; // 숫자 형태의 문자 저장 (문자 '9', 숫자 9 아님)
            //Console.WriteLine(letter); 
            //Console.WriteLine(symbol);
            //Console.WriteLine(number);

            //// string 형식 : 여러 문자를 저장
            //string greeting = "Hello World"; // 문자열 저장
            //string name = "Alice"; // 이름 저장
            //Console.WriteLine(greeting);
            //Console.WriteLine(name);
            //// 출력 : Hello World Alice
            //Console.WriteLine(greeting + " " + name);

            //// bool 형식 : 참(True = 1) 또는 거짓(False = 0)
            //bool isRunning = true; // 프로그램 실행 상태
            //bool isFinished = false; // 프로그램 종료 상태
            //Console.WriteLine(isRunning);
            //Console.WriteLine(isFinished);

            //// const : 변하지 않는 값을 정의 = 상수
            //const double Pi = 3.14159; // 원주율
            //const int MaxScore = 100; // 최대 점수
            //Console.WriteLine(Pi);
            //Console.WriteLine(MaxScore);
            ////Pi = 3.14; // 오류! 상수 값은 변경할 수 없습니다

            //// 닷넷 형식 : 기본 형식의 닷넷 표현, 기본 데이터 형식에 대한 시스템 형식
            //System.Int32 number = 123; // int의 닷넷 형식
            //// 최상단의 using System;가 없으면 System.0 으로 사용
            //// using 사용 : System. 생략 가능
            //String text = "Hello"; // string의 닷넷 형식
            //System.Boolean flag = true; // bool의 닷넷 형식
            //Console.WriteLine(number);
            //Console.WriteLine(text);
            //Console.WriteLine(flag);

            // 래퍼 형식 : 기본 데이터 형식을 클래스 형태로 감싸서 객체로 취급
            // int 래퍼 형식의 메서드 활용
            int number = 123;
            string numberAsString = number.ToString(); // 정수를 문자열로 변환
            // bool 래퍼 형식의 메서드 활용
            bool flag = true;
            string flagAsString = flag.ToString(); // 논리값을 문자열로 변환
            Console.WriteLine(numberAsString);
            Console.WriteLine(flagAsString);
        }
    }
}
