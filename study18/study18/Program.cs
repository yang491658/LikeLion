using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace study18
{
    struct Rectangle
    {
        public int Width;
        public int Height;
        public int GetArea() => Width * Height;
    }

    struct Point
    {
        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// 구조체
            ////var rect = new Rectangle { Width = 5, Height = 4 };
            //Rectangle rect;
            //rect.Width = 10;
            //rect.Height = 20;
            //Console.WriteLine($"Area : {rect.GetArea()}");

            //// 구조체 배열
            //Point[] points = new Point[2];
            //points[0].x = 10;
            //points[0].y = 10;
            //points[1].x = 20;
            //points[1].y = 20;
            //foreach (var point in points)
            //{
            //    Console.WriteLine($"Point : {point.x} , {point.y}");
            //}

            // 중간 과제 : 학생 3명의 성적(국영수) 입력 및 출력 
            //  이름    국어  영어  수학
            // 홍길동   100   80    70
            // 홍길란   90    10    20
            // 홍길순   20    55    70
            Student[] students = new Student[3];

            // 배열 요소 초기화
            for (int i = 0; i < students.Length; i++)
            {
                Console.Write("학생의 이름을 입력하세요: ");
                students[i].Name = Console.ReadLine();
                Console.Write("국어 : ");
                students[i].iKor = int.Parse(Console.ReadLine());
                Console.Write("영어 : ");
                students[i].iEng = int.Parse(Console.ReadLine());
                Console.Write("수학 : ");
                students[i].iMath = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            // 결과 출력
            Console.WriteLine($"{"이름",-5}{"국어",4}{"영어",4}{"수학",4}");
            // {"이름",-5} = "이름  " : 좌측 정렬, 최소 5글자
            // {"국어", 4} = "  국어" : 우측 정렬, 최소 4글자
            foreach (Student student in students)
            {
                student.Print();
            }
        }

        struct Student
        {
            public string Name; // 학생 이름
            public int iKor;    // 국어
            public int iEng;    // 영어
            public int iMath;   // 수학

            // 학생 정보를 출력하는 함수
            public void Print()
            {
                Console.WriteLine($"{Name,-4}{iKor,6}{iEng,6}{iMath,6}");
            }
        }
    }
}
