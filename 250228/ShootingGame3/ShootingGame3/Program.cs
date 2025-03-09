using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame3
{
    // 미사일 클래스
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFired { get; set; } = false;
    }

    // 플레이어 클래스
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch(); // C언어 함수 가져옴

        // 플레이어 변수
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Bullet> Bullets { get; } = new List<Bullet>();
        public int Score { get; private set; } = 100;
        public Item Item { get; } = new Item();
        public int ItemCount { get; private set; } = 0;

        // 생성자
        public Player()
        {
            // 플레이어 좌표 초기화
            X = 0;
            Y = 12;
            for (int i = 0; i < 20; i++) Bullets.Add(new Bullet());
        }

        public void GameMain()
        {
            KeyControl(); // 키를 입력하는 부분
            PlayerDraw(); // 플레이어 그리기
            UIscore(); // UI점수

            // 아이템 그리기
            if (Item.ItemLife)
            {
                Item.ItemMove();
                Item.ItemDraw();
                CrashItem();
            }
        }

        // 키 입력
        public void KeyControl()
        {
            int pressKey; // 정수형 변수 선언 -> 키 값 입력

            if (Console.KeyAvailable) // 키가 눌렸을때
            {
                pressKey = _getch(); // 아스키 값 : 입력한 키를 아스키 코드로 받음

                if (pressKey == 224 || pressKey == 0) // 방향키 또는 확장 키
                {
                    pressKey = _getch(); // 실제 키 값 읽기
                }

                switch (pressKey)
                {
                    case 72: Y = Math.Max(1, Y - 1); break;
                    case 75: X = Math.Max(0, X - 1); break;
                    case 77: X = Math.Min(75, X + 1); break;
                    case 80: Y = Math.Min(22, Y + 1); break;
                    case 32:
                        Bullets.Add(new Bullet { X = X + 5, Y = Y + 1, IsFired = true });
                        if (ItemCount >= 1) Bullets.Add(new Bullet { X = X + 5, Y = Y, IsFired = true });
                        if (ItemCount >= 2) Bullets.Add(new Bullet { X = X + 5, Y = Y + 2, IsFired = true });
                        break;
                }
            }
        }

        // 플레이어 그리기
        public void PlayerDraw()
        {
            // 문자열 배열로 플레이어 그리기
            string[] playerShape = new string[]
            {
                "->",
                ">>>",
                "->"
            };

            for (int i = 0; i < playerShape.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i - 1); // 콘솔 좌표 설정
                Console.WriteLine(playerShape[i]); // 문자열 배열 출력
            }
        }

        // 미사일 그리기
        public void BulletDraw()
        {
            // 미사일 형태
            string bulletSymbol = "->";

            foreach (var bullet in Bullets)
            {
                if (bullet.IsFired)
                {
                    Console.SetCursorPosition(bullet.X - 1, bullet.Y - 1);
                    Console.Write(bulletSymbol);
                    bullet.X++;
                    if (bullet.X > 78) bullet.IsFired = false;
                }
            }
        }

        // 충돌처리
        public void ClashEnemyAndBullet(Enemy enemy)
        {
            foreach (var bullet in Bullets)
            {
                if (bullet.IsFired
                    && bullet.Y - 1 == enemy.Y
                    && bullet.X >= (enemy.X - 1)
                    && bullet.X <= (enemy.X + 1))
                {
                    Item.ItemLife = true;
                    Item.X = enemy.X;
                    Item.Y = enemy.Y;

                    Random rand = new Random();
                    enemy.X = 75;
                    enemy.Y = rand.Next(2, 22);

                    bullet.IsFired = false;
                    Score += 100;
                }
            }
        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃ Score : " + Score + "  ┃");
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        // 아이템 충돌 시 미사일 수 증가
        public void CrashItem()
        {
            if (Y >= Item.Y - 1 && Y <= Item.Y + 1
                && X >= Item.X - 2 && X <= Item.X + 2)
            {
                Item.ItemLife = false;
                ItemCount = Math.Min(3, ItemCount + 1);
            }
        }
    }

    // 적 클래스
    public class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }

        // 적 좌표 초기화
        public Enemy()
        {
            X = 75;
            Y = 12;
        }

        public void EnemyDraw()
        {
            string enemyShape = "<-0->"; // 적을 문자열로 표현
            Console.SetCursorPosition(X, Y); // 좌표 설정
            Console.Write(enemyShape);
        }

        public void EnemyMove()
        {
            Random rand = new Random();

            X--; // 왼쪽으로 이동

            // 가장 왼쪽 도달 시, 새로운 적 생성
            if (X < 2)
            {
                X = 75;
                Y = rand.Next(2, 22);
            }
        }
    }

    // 아이템 클래스
    public class Item
    {
        public string ItemName;
        public string ItemShape;

        public int X { get; set; }
        public int Y { get; set; }
        public bool ItemLife { get; set; } = false;

        // 아이템 그리기
        public void ItemDraw()
        {
            Console.SetCursorPosition(X, Y);
            ItemShape = "Item★";
            Console.Write(ItemShape);
        }

        // 아이템 이동
        public void ItemMove()
        {
            X--;
            if (X <= 1 || Y <= 1) ItemLife = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Player player = new Player(); // 플레이어 생성
            Enemy enemy = new Enemy(); // 적 생성

            // 유니티처럼 속도를 프레임속도로
            int dwTime = Environment.TickCount; // 1ms

            // 무한 반복
            while (true)
            {
                // 0.05초 (50ms) 지연
                if (dwTime + 50 < Environment.TickCount)
                {
                    // 현재시간 세팅
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    // 게임 시작
                    player.GameMain();

                    // 미사일
                    player.BulletDraw();

                    // 적
                    enemy.EnemyMove(); // 이동
                    enemy.EnemyDraw(); // 그리기

                    // 충돌처리
                    player.ClashEnemyAndBullet(enemy);
                }
            }
        }
    }
}

