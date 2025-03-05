﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study33
{
    class Player
    {
        protected string Name; // protected : 부모와 자식 상속 관계에서만 사용 가능

        public Player()
        {
            Name = "플레이어";
            Console.WriteLine("부모 생성자입니다.");
        }

        public void Show()
        {
            Console.WriteLine(Name);
        }
    }

    class Wizard : Player
    {
        public Wizard()
        {
            Name = "마법사";
            Console.WriteLine("자식 생성자입니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Player p = new Player();
            //p.Show();

            Wizard w = new Wizard();
            w.Show();
        }
    }
}
