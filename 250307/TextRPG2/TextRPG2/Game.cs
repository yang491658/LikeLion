using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG2
{
    public class Game
    {
        Player player = null;
        Field field = null;

        // 생성자
        public Game() { }

        // 소멸자
        ~Game() { }

        public void Start()
        {
            while (player == null)
            {
                Console.Clear();
                Console.Write("직업을 선택해 주세요. (1. 전사  2. 마법사  3. 암살자) : ");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        player = new Player();
                        player.name = "전사";
                        player.health = 200;
                        player.damage = 10;
                        break;
                    case 2:
                        player = new Player();
                        player.name = "마버사";
                        player.health = 150;
                        player.damage = 15;
                        break;
                    case 3:
                        player = new Player();
                        player.name = "전사";
                        player.health = 120;
                        player.damage = 18;
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.");
                        Thread.Sleep(500);
                        break;
                }
            }
        }

        public void Progress()
        {
            while (true)
            {
                Console.Clear();

                player.Print();

                // 행동 선택
                Console.Write("\n1. 사냥터  2. 종료 : ");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        field = new Field(player);
                        field.MakeField();
                        break;
                    case 2:
                        Console.WriteLine("\n게임 종료.");
                        return;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.");
                        Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}
