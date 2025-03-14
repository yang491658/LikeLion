using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study37
{
    class Person
    {
        public string Name;
        public int Age;

        // 기본 생성자 : 매개변수 없음
        public Person()
        {
            Name = "Unknown";
            Age = 0;
        }

        // 생성자는 여러개 가능 (매개변수는 달라야 함)
        public Person(string name)
        {
            Name = name;
            Age = 0;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 생성자 호출
            Person p = new Person(); // 기본 생성자
            Person p2 = new Person("Alice"); // 매개변수 1개인 생성자
            Person p3 = new Person("Bob", 20); // 매개변수 2개인 생성자

            Console.WriteLine(p.Name + ", " + p.Age);
            Console.WriteLine(p2.Name + ", " + p2.Age);
            Console.WriteLine(p3.Name + ", " + p3.Age);
        }
    }
}
