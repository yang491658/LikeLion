using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion7
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 이진수를 정수로 변환
            //Console.Write("2진수를 입력하세요 : ");
            //string binaryInput = Console.ReadLine(); // 문자열 입력
            //int decimalValue = Convert.ToInt32(binaryInput, 2); // 2진수 -> 10진수 변환
            //// 정수를 이진수로 변환
            //string binaryOutput = Convert.ToString(decimalValue, 2); // 10진수 -> 2진수
            //Console.WriteLine($"입력한 2진수 : {binaryInput}");
            //Console.WriteLine($"10진수 변환 : {decimalValue}");
            //Console.WriteLine($"다시 2진수 변환 : {binaryOutput}");

            //// var를 사용하여 변수 선언
            //var name = "Alice"; // 문자열로 추론
            //var age = 25; // 정수로 추론
            //var isStudent = true; // 논리값으로 추론
            //Console.WriteLine($"이름 : {name}, 나이 : {age}, 학생 여부 : {isStudent}");

            //// default 키워드를 사용한 기본값 설정
            //int defaultInt = default; // 기본값 : 0
            //string defaultString = default; // 기본값 : null
            //bool defaultBool = default; // 기본값 : false
            //Console.WriteLine($"정수 기본값 : {defaultInt}");
            //Console.WriteLine($"문자열 기본값 : {defaultString}");
            //Console.WriteLine($"논리값 기본값 : {defaultBool}");

            //// 연산자
            //int a = 5, b = 3;
            //int result = 0;
            //// 산술 연산자 사용
            //result = a + b;
            //Console.WriteLine($"결과 : {result}");
            //result = a - b;
            //Console.WriteLine($"결과 : {result}");
            //result = a * b;
            //Console.WriteLine($"결과 : {result}");
            //result = a / b;
            //Console.WriteLine($"결과 : {result}");
            //result = a % b;
            //Console.WriteLine($"결과 : {result}");

            //// %의 활용 : 홀짝
            //int number = 7;
            //int result = 0;
            //result = number % 2; // 0 : 짝수, 1 : 홀수
            //Console.WriteLine("홀짝 판별 : " + result);

            //// 관계형 연산자 (판별)
            //bool isEqual = false; // 거짓 0
            //int a = 5, b = 2;
            //isEqual = a == b; // a와 b가 같은가
            //Console.WriteLine("같은가? " + isEqual);

            //// 단항 연산자
            //int number = 5;
            //Console.WriteLine(+number); // 양수 출력 : +5 ~ 더하기x
            //Console.WriteLine(-number); // 음수 출력 : -5 ~ 빼기x
            //bool flag = true;
            //Console.WriteLine(!flag); // 논리 부정 : False

            //// 비트 반전
            //int num = 10; // 이진수 0000 1010
            //int result = ~num; // 모든 비트 반전 : 1111 0101 = -11
            //Console.WriteLine("원래 값 : " + num);
            //Console.WriteLine("~연사자 적용 후 : " + result);

            //// 변환 연산자 (캐스팅)
            //double pi = 3.14;
            //int integerPi = (int)pi; // 실수형 -> 정수형 변환 ~ 소수점 버려짐
            //Console.WriteLine(integerPi);
            //// 예시
            //int iKor = 90, iEng = 75, iMath = 58;
            //int sum = 0;
            //float average = 0.0f;
            //sum = iKor + iEng + iMath;
            //average = (float)sum / 3;
            //Console.WriteLine("총점 : " + sum);
            //Console.WriteLine("평균 : " + average);

            //// 산술 연산자
            //int a = 10, b = 3;
            //Console.WriteLine(a + b); // 더하기 -> 결과 : 13
            //Console.WriteLine(a - b); // 빼기   -> 결과 : 7
            //Console.WriteLine(a * b); // 곱하기 -> 결과 : 30
            //Console.WriteLine(a / b); // 나누기 -> 결과 : 3 (정수형의 경우 몫만 출력)
            //Console.WriteLine(a % b); // 나머지 -> 결과 : 1

            //// 문자열 연결 연산자
            //string firstName = "Alice", lastName = "Smith";
            //Console.WriteLine(firstName + " " + lastName);

            //// 할당 연산자
            //int a = 10;
            //a += 5; // a = a + 5
            //Console.WriteLine(a); // 출력 : 10 + 5 = 15
            //a -= 5; // a = a - 5
            //Console.WriteLine(a); // 출력 : 15 - 5 = 10
            //a *= 5; // a = a * 5
            //Console.WriteLine(a); // 출력 : 10 * 5 = 50
            //a /= 5; // a = a / 5
            //Console.WriteLine(a); // 출력 : 50 / 5 = 10
            //a %= 5; // a = a % 5
            //Console.WriteLine(a); // 출력 : 10 % 5 = 0

            //// 중간 과제 1
            //Console.Write("국어 점수를 입력하세요 : ");
            //int kor = int.Parse(Console.ReadLine());
            //Console.Write("영어 점수를 입력하세요 : ");
            //int eng = int.Parse(Console.ReadLine());
            //Console.Write("수학 점수를 입력하세요 : ");
            //int math = int.Parse(Console.ReadLine());
            //int sum = kor + eng + math;
            //float average = (float)sum / 3;
            //Console.WriteLine($"\n총점 : {sum}, 평균 : {average:F2}");

            //Console.WriteLine();

            //// 중간 과제 2
            //Console.Write("정수를 입력하세요 : ");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine($"\n원래 값 : {number}, 비트 반전 : {~number}");

            // 증감 연산자
            int b = 3;
            ++b; // 전위 증가 ++b = b + 1
            Console.WriteLine(b); // 출력 : 4 + 1 = 5
            b++; // 후위 증가 b++ = b + 1
            Console.WriteLine(b); // 출력 : 4 + 1 = 5
            --b; // 전위 감소 --b = b - 1
            Console.WriteLine(b); // 출력 : 5 - 1 = 4
            b--; // 전위 감소 b-- = b - 1
            Console.WriteLine(b); // 출력 : 4 - 1 = 3
            // 전위와 후위의 차이
            b = 3;
            Console.WriteLine(++b); // 출력 4 ~ 전위 : 출력 전 연산(3+1)
            Console.WriteLine(b++); // 출력 4 ~ 후위 : 출력 후 연산(4+1)
        }
    }
}
