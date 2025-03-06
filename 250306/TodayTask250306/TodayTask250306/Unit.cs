using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250306
{
    interface Doing
    {
        void Damage();
        void Attack();
        void Guard();
        void Skill();
        void Shield();
        void Move();
    }

    abstract class Unit : Doing
    {
        public string Name;
        public int Health;
        public int Mana;
        public int Power;
        public int Ability;
        public int Armor;
        public int Resistance;
        public string Action = "준비";

        // 기본 생성자
        protected Unit() { }

        // 데미지
        public void Damage() { Console.WriteLine($"\n{Name}에게 데미지"); }

        // 공격
        public void Attack() { Console.WriteLine($"\n{Name}의 공격"); Action = "공격"; }

        // 가드
        public void Guard() { Console.WriteLine($"\n{Name}의 가드"); Action = "가드"; }

        // 스킬
        public void Skill() { Console.WriteLine($"\n{Name}의 스킬"); Action = "스킬"; }

        // 실드
        public void Shield() { Console.WriteLine($"\n{Name}의 실드"); Action = "실드"; }

        // 도망
        public void Move() { Console.WriteLine($"\n{Name}의 도망"); Action = "도망"; }

        public void Print()
        {
            Console.WriteLine($"직업명 : {Name}");
            Console.WriteLine($"체력   : {Health.ToString().PadLeft(3)} / 마나   : {Mana.ToString().PadLeft(3)}");
            Console.WriteLine($"공격력 : {Power.ToString().PadLeft(3)} / 주문력 : {Ability.ToString().PadLeft(3)}");
            Console.WriteLine($"방어력 : {Armor.ToString().PadLeft(3)} / 저항력 : {Resistance.ToString().PadLeft(3)}\n");
        }
    }
}
