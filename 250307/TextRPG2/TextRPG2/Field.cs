using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG2
{
    class Field
    {
        Player player = null;
        Monster monster = null;

        // 생성자
        public Field(Player PLAYER) { player = PLAYER; }

        // 소멸자
        ~Field() { }

        public void MakeField()
        {
            while (true)
            {
                Console.Clear();

                player.Print();
                // 난이도 선택
                if (monster == null)
                {
                    SelectMap(ref monster);
                }
                else
                {
                    monster.Print();
                    Fight(ref monster);
                    if (monster.health == 0)
                    {
                        Console.WriteLine($"\n{monster.name}가 사망하여 사냥을 종료합니다.");
                        Thread.Sleep(1000);
                        break;
                    }

                    if (player.health == 0)
                    {
                        Console.WriteLine($"\n{player.name}가 사망하여 사냥을 종료합니다.");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        public void SelectMap(ref Monster MONSTER)
        {
            Console.Write("\n1. 초보맵  2. 중급맵  3. 고급맵 : ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    MONSTER = new Monster();
                    MONSTER.name = "슬라임";
                    MONSTER.health = 30;
                    MONSTER.damage = 3;
                    break;
                case 2:
                    MONSTER = new Monster();
                    MONSTER.name = "고블린";
                    MONSTER.health = 60;
                    MONSTER.damage = 5;
                    break;
                case 3:
                    MONSTER = new Monster();
                    MONSTER.name = "오크";
                    MONSTER.health = 100;
                    MONSTER.damage = 12;
                    break;
                default:
                    Console.WriteLine("\n잘못된 입력입니다.");
                    Thread.Sleep(500);
                    break;
            }
        }

        public void Fight(ref Monster MONSTER)
        {
            Random rand = new Random();
            int playerDamage = player.damage * rand.Next(8, 16) / 10;
            int monsterDamage = MONSTER.damage * rand.Next(8, 16) / 10;
            Console.Write("\n1. 공격  2. 도망 : ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine($"\n{player.name}가 공격합니다. 데미지 : {playerDamage}");
                    MONSTER.health = Math.Max(MONSTER.health - playerDamage, 0);
                    Console.WriteLine($"\n{MONSTER.name}가 공격합니다. 데미지 : {monsterDamage}");
                    player.health = Math.Max(player.health - monsterDamage, 0);
                    break;
                case 2:
                    Console.WriteLine("\n전투에서 도망칩니다.");
                    monster.health = 0;
                    Console.WriteLine($"\n{MONSTER.name}가 등 뒤를 공격합니다. 데미지 : {monsterDamage / 2}");
                    player.health -= monsterDamage / 2;
                    break;
                default:
                    Console.WriteLine("\n잘못된 입력입니다.");
                    Thread.Sleep(500);
                    break;
            }
        }
    }
}
