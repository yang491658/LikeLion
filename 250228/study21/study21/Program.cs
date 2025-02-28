using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study21
{
    //// Setter와 Getter 함수 사용
    //class Person
    //{
    //    private string name; // 내부 변수

    //    // Setter : 값 설정 하기
    //    public void SetName(string newName)
    //    {
    //        name = newName;
    //    }

    //    // Getter : 값 가져오기
    //    public string GetName()
    //    {
    //        return name;
    //    }
    //}

    //// 프로퍼티 Propertoy
    //class Person
    //{
    //    private string name; // 내부 변수

    //    public string Name // 프로퍼티
    //    {
    //        get { return name; } // Getter
    //        set { name = value; } // Setter
    //    }
    //}

    //// 프로퍼티 자동 구현
    //class Person
    //{
    //    // 자동 구현 프로퍼티
    //    public string Name { get; set; }

    //    // 읽기만 가능
    //    private int count = 100;
    //    public int Count
    //    {
    //        get { return count; }
    //    }

    //    // 외부 변경 불가
    //    public float Balance { get; private set; } = 50;
    //    // 내부에서 변경
    //    public void AddBal()
    //    {
    //        Balance += 100;
    //    }
    //}

    class Marin
    {
        public string Name { get; private set; } = "마린";
        public int Mineral { get; set; } = 100;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // get/set 방식의 함수와 프로퍼티 비교
            // 객체의 값을 읽고(get), 설정(set)하는 방식으로 함수(get/set메서드) 또는
            // **프로퍼티(Property)**를 사용할 수 있습니다.

            //// Setter와 Getter 함수
            //Person p = new Person();
            //p.SetName("홍길동");
            //Console.WriteLine("이름 : " + p.GetName());

            //// 프로퍼티 Propertoy
            //Person p = new Person();
            //p.Name = "홍길동";
            //Console.WriteLine("이름 : " + p.Name);
            //Console.WriteLine("Count : " + p.Count);
            //p.AddBal();
            //Console.WriteLine("Balance : " + p.Balance);

            Marin m = new Marin();
            Console.WriteLine($"이름 : {m.Name} / 미네랄 : {m.Mineral}");
        }
    }
}
