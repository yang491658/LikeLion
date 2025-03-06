using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayTask250306
{
    class Player : Unit
    {
        // 기본 생성자
        public Player() { }

        // 선택
        public void Select()
        {
            Console.Write("직업을 선택하세요. (1. 전사  2. 마법사  3. 암살자) : ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Name = "전사";
                    Health = 200;
                    Mana = 100;
                    Power = 20;
                    Ability = 15;
                    Armor = 10;
                    Resistance = 5;
                    break;
                case 2:
                    Name = "마법사";
                    Health = 150;
                    Mana = 200;
                    Power = 15;
                    Ability = 40;
                    Armor = 3;
                    Resistance = 8;
                    break;
                case 3:
                    Name = "암살자";
                    Health = 120;
                    Mana = 100;
                    Power = 35;
                    Ability = 20;
                    Armor = 5;
                    Resistance = 5;
                    break;
            }
        }
    }
}
