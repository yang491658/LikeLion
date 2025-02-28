using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study20
{
    // 클래스 생성
    class Person
    {
        public string Name;
        public int Age;
        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {Name}, 나이 : {Age}");
        }

        // 기본 생성자
        // 클래스가 객체로 생성될 때, 자동으로 실행되는 특별한 메서드
        // 클래스와 같은 이름을 가지며, 반환형이 없다 (void도 사용 X)
        // 객체를 만들 때 필요한 초기값을 설정할 때 많이 사용한다.
        //public Person()
        //{
        //    Name = "이름 없음";
        //    Age = 0;
        //    Console.WriteLine("기본 생성자가 실행됨");
        //}

        // 매개 변수가 있는 생성자 ~ 오버로딩 가능
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("매개변수가 있는 생성자가 실행됨");
        }
    }

    class Marin
    {
        public string Name;
        public int Mineral;
        public Marin()
        {
            Name = "마린";
            Mineral = 50;
        }
        public Marin(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {Name} , 미네랄 : {Mineral}");
        }
    }

    class SCV
    {
        public string Name;
        public int Mineral;
        public SCV()
        {
            Name = "SCV";
            Mineral = 50;
        }
        public SCV(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {Name} , 미네랄 : {Mineral}");
        }
    }

    class Barrack
    {
        public string Name;
        public int Mineral;
        public Barrack()
        {
            Name = "배럭";
            Mineral = 150;
        }
        public Barrack(string Name, int Mineral)
        {
            // this 키워드 : 자기 자신을 가르킴
            this.Name = Name;
            this.Mineral = Mineral;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {Name} , 미네랄 : {Mineral}");
        }
    }

    class Mineral
    {
        public int MineralCount;
        public Mineral()
        {
            MineralCount = 1500;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"현재 미네랄 수 : {MineralCount}");
        }
    }

    class Game
    {
        // static 키워드
        public static int mineral;
        public static int gas;
        public static int charCount;

        public static void ShowInfo()
        {
            Console.WriteLine($"미네랄 {mineral} 가스 {gas} 인구수 {charCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// 클래스 사용
            //Person p1 = new Person(); // 객체 생성 instance ~ 기본 생성자
            //p1.ShowInfo();

            //// 매개변수가 있는 생성자
            //// 기본 생성자가 없으면 반드시 매개변수 필요
            //Person p2 = new Person("철수", 25);
            //p2.ShowInfo();
            //Person p3 = new Person("영희", 30);
            //p3.ShowInfo();

            // 기본 생성자
            Marin marin = new Marin();
            marin.ShowInfo();

            // 매개변수가 있는 생성자
            SCV scv = new SCV("SCV2", 70); // 매개변수
            scv.ShowInfo();

            // this 키워드
            Barrack barrack = new Barrack();
            barrack.ShowInfo();

            // 클래스의 배열
            Mineral[] mineral = new Mineral[7]; // 7개 생성
            for (int i = 0; i < mineral.Length; i++) // 각 배열에 객체 생성
            {
                mineral[i] = new Mineral();
                mineral[i].ShowInfo();
            }

            // static 키워드 : 모든 클래스에서 사용하는 데이터와 메서드
            Game.mineral = 50;
            Game.gas = 0;
            Game.charCount = 4;
            Game.ShowInfo();
        }
    }
}
