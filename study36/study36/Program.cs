using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study36
{
    class Person
    {
        //// 필드 : 클래스의 데이터를 저장(초기화)하는 멤버
        //public string name = "홍길동";
        //// 필드를 선언하면서 초기화 가능
        //public string name = "홍길동";

        // public : 외부 사용 가능
        // private : 외부 사용 불가 -> Getter, Setter 사용
        private string name;

        // Setter
        public void SetName(string n)
        {
            name = n;
        }

        // Getter
        public string GetName()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(); // 객체(인스터스)로 만들기
            p.name = "Alice"; // 필드에 데이터 저장(초기화)
            Console.WriteLine(p.name);

            // public : 외부에서 사용 가능
            // private : 외부에서 사용 불가
            //Console.WriteLine(p.name2);
            p.SetName("Bob");
            Console.WriteLine(p.GetName());
        }
    }
}
