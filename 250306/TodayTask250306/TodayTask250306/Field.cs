using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250306
{
    class Field
    {
        Player player = null;
        Monster monster = null;

        public void SetPlayer(Player player) { this.player = player; }


        public void Progress()
        {
            // 몬스터 랜덤 생성
            Random rand = new Random();
            int rnd = rand.Next(100);
            if (rnd < 50)
                Create("고블린 전사", 50, 10, 15, 5, 3, 1);
            else if (rnd < 50 + 45)
                Create("고블린 마법사", 80, 50, 5, 25, 1, 8);
            else
                Create("고블린 킹", 200, 100, 40, 15, 8, 5);

            int input = 0;

            while (true)
            {
                Console.Clear();

                monster.Print();
                player.Print();

                // 플레이어 전투
                Fight();
                if (player.Action == "도망" || monster.Action == "도망") break;
                if (player.Health <= 0 || monster.Health <= 0) break;
            }

        }

        public void Create(string name, int health, int mana, int power, int ability, int armor, int resistance)
        {
            monster = new Monster();

            monster.Name = name;
            monster.Health = health;
            monster.Mana = mana;
            monster.Power = power;
            monster.Ability = ability;
            monster.Armor = armor;
            monster.Resistance = resistance;
            monster.Action = "준비";
        }

        public void Fight()
        {
            Random rand = new Random();

            int input = 0;

            while (true)
            {
                Console.Clear();

                monster.Print();
                player.Print();

                Console.Write("1. 공격  2. 가드  3. 스킬  4. 실드  5. 도망 : ");

                // 플레이어의 행동
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        player.Attack();
                        break;
                    case 2:
                        player.Guard();
                        break;
                    case 3:
                        player.Skill();
                        break;
                    case 4:
                        player.Shield();
                        break;
                    case 5:
                        player.Move();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.");
                    Thread.Sleep(1000);
                        return;
                }

                // 몬스터 행동
                input = rand.Next(monster.Power + monster.Armor + monster.Ability + monster.Resistance + 1);
                if (input < monster.Power)
                    monster.Attack();
                else if (input < monster.Power + monster.Armor)
                    monster.Guard();
                else if (input < monster.Power + monster.Armor + monster.Ability)
                    monster.Skill();
                else if (input < monster.Power + monster.Armor + monster.Ability + monster.Resistance)
                    monster.Shield();
                else
                    monster.Move();

                // 결과
                FightDetail(player, monster);
                FightDetail(monster, player);

                if (player.Action == "도망" || monster.Action == "도망") break;
                if (player.Health <= 0)
                {
                    Console.WriteLine($"\n{player.Name} 사망");
                    Thread.Sleep(1000);
                    break;
                }
                else if (monster.Health <= 0)
                {
                    Console.WriteLine($"\n{monster.Name} 사망");
                    Thread.Sleep(1000);
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        public void FightDetail(Unit Me, Unit You)
        {
            if (Me.Action == "공격")
            {
                You.Damage();
                if (You.Action == "가드")
                    You.Health = Math.Max(You.Health - Math.Max((Me.Power - You.Armor), 1), 0);
                else
                    You.Health = Math.Max(You.Health - Math.Max(Me.Power, 1), 0);
            }
            else if (Me.Action == "스킬")
            {
                if (Me.Mana < 20)
                {
                    Console.WriteLine($"\n{Me.Mana}의 마나가 부족합니다.");
                    return;
                }
                Me.Mana -= 20;
                if (You.Action == "실드")
                {
                    if (You.Mana < 20)
                    {
                        Console.WriteLine($"\n{You.Mana}의 마나가 부족합니다.");
                        return;
                    }
                    You.Mana -= 20;
                    You.Health = Math.Max(You.Health - Math.Max((Me.Ability - You.Resistance), 1), 0);

                }
                else
                    You.Health = Math.Max(You.Health - Math.Max(Me.Ability, 1), 0);
            }
        }
    }
}
