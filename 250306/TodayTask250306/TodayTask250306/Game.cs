using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250306
{
    class Game
    {
        // 플레이어
        public Player player = null;
        // 필드
        public Field field = null;

        // 생성자
        public Game() { }

        // 시작
        public void Start()
        {
            // 플레이어 생성 및 직업 선택
            player = new Player();
            player.Select();
        }

        // 게임 진행
        public void Progress()
        {
            int input = 0;

            while (true)
            {
                Console.Clear();
                player.Print();

                Console.Write("1. 사냥터  2. 종료 : ");
                input = int.Parse(Console.ReadLine());

                // 사냥터
                if (input == 1)
                {
                    if (field == null)
                    {
                        field = new Field();
                        field.SetPlayer(player);
                    }
                    field.Progress();
                }
                // 종료
                else if (input == 2 || player.Health <= 0)
                    break;
            }
        }
    }
}
