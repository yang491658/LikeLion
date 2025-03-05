using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 일일 과제 250305 : 리그오브레전드 구현하기
namespace TodayTask250305
{
    class Unit
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public int AD { get; set; }
        public int AP { get; set; }
        public Skill Q { get; set; }
        public Skill W { get; set; }
        public Skill E { get; set; }
        public Skill R { get; set; }

        public void View()
        {
            Console.WriteLine($"{Name.PadRight(6)}\tHP : {CurrentHealth}/{MaxHealth}\tMP : {CurrentMana}/{MaxMana}");
        }

        public void Attack(Unit target)
        {
            Console.WriteLine($"\n{Name}의 기본 공격\n{target.Name}의 체력 -{AD}");
            target.CurrentHealth = Math.Max(target.CurrentHealth - AD, 0);
        }

        public virtual bool UseSkill(Skill skill, Unit target)
        {
            int currentTime = Environment.TickCount;

            if (currentTime - skill.UsedTime < skill.Cooldown)
            {
                double remainTime = (double)(skill.Cooldown - (currentTime - skill.UsedTime)) / 1000;
                Console.WriteLine($"\n재사용 대기시간입니다. (남은 시간 : {remainTime}초)");
                return false;
            }
            else if (CurrentMana < skill.ManaCost)
            {
                Console.WriteLine($"\n마나 부족 (마나 {skill.ManaCost - CurrentMana} 필요)\n");
                return false;
            }
            else
            {
                skill.UsedTime = Environment.TickCount;
                Console.WriteLine($"\n{Name}의 {skill.Name} 사용");
                return true;
            }
        }
    }

    class Skill
    {
        public string Name; // 스킬 이름
        public int Level; // 스킬 레벨
        public int Damage; // 스킬 데미지
        public int ManaCost; // 마나 소모량
        public int Cooldown; // 재사용 대기시간 (ms)
        public int UsedTime; // 마지막 사용시간 (TickCount)

        public Skill(string name, double damage, int manaCost, double cooldown)
        {
            Name = name;
            Damage = (int)damage;
            ManaCost = manaCost;
            Cooldown = (int)cooldown * 1000;
            UsedTime = 0;
        }
    }

    class Ezreal : Unit
    {
        public Ezreal()
        {
            Name = "이즈리얼";
            MaxHealth = 600;
            CurrentHealth = MaxHealth;
            MaxMana = 375;
            CurrentMana = MaxMana;
            AD = 60;
            Q = new Skill("신비한 화살", 20 + 1.3 * AD + 0.15 * AP, 28, 5.5);
            W = new Skill("정수의 흐름", 80 + 1.0 * AD + 0.7 * AP, 50, 8);
            E = new Skill("비전 이동", 80 + 0.5 * AD + 0.75 * AP, 70, 26);
            R = new Skill("정조준 일격", 350 + 1.0 * AD + 0.9 * AP, 100, 120);
        }

        public override bool UseSkill(Skill skill, Unit target)
        {
            if (base.UseSkill(skill, target))
            {
                Console.WriteLine($"{Name}의 마나 -{skill.ManaCost}");
                CurrentMana -= skill.ManaCost;
                double damage = 20 + 1.3 * AD + 0.15 * AP;
                Console.WriteLine($"{target.Name}의 체력 -{damage}");
                target.CurrentHealth = Math.Max(target.CurrentHealth - (int)damage, 0);
            }
            return true;
        }
    }

    class Ahri : Unit
    {
        public Ahri()
        {
            Name = "아리";
            MaxHealth = 590;
            CurrentHealth = MaxHealth;
            MaxMana = 418;
            CurrentMana = MaxMana;
            AD = 53;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Ezreal ezreal = new Ezreal();
            Ahri ahri = new Ahri();

            while (true)
            {

                Console.Write($"\n{ezreal.Name}의 행동을 입력 : ");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        ezreal.Attack(ahri);
                        break;
                    case "q":
                        ezreal.UseSkill(ezreal.Q, ahri);
                        break;
                    case "w":
                        ezreal.UseSkill(ezreal.W, ahri);
                        break;
                    case "e":
                        ezreal.UseSkill(ezreal.E, ahri);
                        break;
                    case "r":
                        ezreal.UseSkill(ezreal.R, ahri);
                        break;
                }

                Console.WriteLine();
                ezreal.View();
                ahri.View();
            }
        }
    }
}
