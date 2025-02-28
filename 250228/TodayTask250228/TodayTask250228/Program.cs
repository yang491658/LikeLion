using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask250228
{
    // 게임 화면 클래스
    public class Game
    {
        // 전역 변수
        public static int w = 100; // 가로
        public static int h = 20; // 세로
        public static int marginH = 5; // 하단 여백
        public static int frame = 20; // 프레임
        public Player player = new Player();
        public Item item = new Item();

        // 제목 변수
        private static string title1 = "SHOOTING  ";
        private static string title2 = " OF LEGEND";
        private static string[] logo =
        {
            " _____",
            "||   ||",
            "||   ||",
            "|│___||",
            "|/___\\|",
        };

        // 시작 화면
        public static void Start()
        {
            // 상하 여백
            int marginY = h / 10;

            PrintSide();
            PrintTile(title1, marginY);
            PrintTile(title2, h - marginY - logo.Length);

            while (!Console.KeyAvailable)
            {
                Console.SetCursorPosition((w - 37) / 2, h / 2);
                string text = "아무 키나 누르시면 게임이 시작됩니다.";
                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Thread.Sleep(200 / frame);
                }
            }
        }

        // 진행 화면
        public static void View(Player player, Item item)
        {
            PrintSide();
            player.Draw();
            player.ItemList();
            player.InputKey();
            if (item.isMade)
            {
                item.Create();
                item.Move();
            }
            player.Get(item);
        }

        // 제목 출력
        private static void PrintTile(string title, int initY)
        {
            // 변수
            int box = 9; // 박스 크기
            int marginX = 5; // 좌우 여백
            int count = title.Length; // 제목 글자 수
            int invX = (w - 2 - 2 * marginX - count * box) / (count - 1); // 제목 간격

            // 각 제목 글자 출력
            for (int i = 0; i < title.Length; i++)
            {
                // 빈칸은 패스
                if (title[i] == ' ') continue;

                for (int j = 0; j < logo.Length; j++)
                // 제목 박스
                {

                    Console.SetCursorPosition(1 + marginX + i * (invX + box), initY + j);
                    Console.WriteLine(logo[j]);
                    Thread.Sleep(200 / frame);
                }

                // 제목 글자
                Console.SetCursorPosition(box / 2 + marginX + i * (invX + box), initY + 2);
                Console.WriteLine(title[i]);
            }
        }

        // 테두리 출력
        public static void PrintSide()
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 && y == 0) Console.Write("┏");
                    else if (x == w - 1 && y == 0) Console.Write("┓");
                    else if (x == 0 && y == h - 1) Console.Write("┗");
                    else if (x == w - 1 && y == h - 1) Console.Write("┛");
                    else if (x == 0 || x == w - 1) Console.Write("┃");
                    else if (y == 0 || y == h - 1) Console.Write("━");
                    //else Console.Write("@");
                }
                Console.WriteLine();
            }
        }
    }

    // 플레이어 클래스
    public class Player
    {
        // 플레이어 변수
        public int x { get; private set; }
        public int y { get; private set; }
        public int maxX { get; private set; }
        public int maxY { get; private set; }
        public int score { get; private set; } = 100;

        public List<Bullet> bullets { get; } = new List<Bullet>();
        public int shootTime = Environment.TickCount;
        public int shootDelay = 1000;

        public List<Item> itemList { get; set; } = new List<Item>();

        // 플레이어 생성자
        public Player()
        {
            // 플레이어 좌표
            x = 1;
            y = Game.h / 2;
            maxX = Game.w - 7;
            maxY = Game.h - 2;

            // 총알
            for (int i = 0; i < 20; i++) bullets.Add(new Bullet());
        }

        // 키 입력
        public void InputKey()
        {
            // 키가 눌렸을 때
            if (Console.KeyAvailable)
            {
                // 입력된 키 정보 가져오기
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    // 방향키 -> 플레이어 이동
                    case ConsoleKey.LeftArrow: x = Math.Max(1, x - 2); break;
                    case ConsoleKey.RightArrow: x = Math.Min(maxX, x + 2); break;
                    case ConsoleKey.UpArrow: y = Math.Max(1, y - 1); break;
                    case ConsoleKey.DownArrow: y = Math.Min(maxY, y + 1); break;
                    // 스페이스바 -> 총알 발사 (0.5초 당 1번)
                    case ConsoleKey.Spacebar:
                        if (shootTime + shootDelay <= Environment.TickCount)
                        {
                            bullets.Add(new Bullet { x = x + 5, y = y, shoot = true });
                            shootTime = Environment.TickCount;
                        }
                        break;
                    // ESC키 -> 종료
                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0, Game.h);
                        Environment.Exit(0);
                        return;

                }
            }
        }

        // 플레이어 그리기
        public void Draw()
        {
            // 플레이어 형태
            string shape = "착한놈";

            // 플레이어 출력
            Console.SetCursorPosition(x, y);
            Console.WriteLine(shape);
        }

        // 총알 발사
        public void Shoot()
        {
            // 총알 형태
            string shape = "슛";

            // 총알 그리기
            foreach (var bullet in bullets)
            {
                // 총알 발사 중
                if (bullet.shoot)
                {
                    // 총알 출력
                    Console.SetCursorPosition(bullet.x, bullet.y);
                    Console.Write(shape);

                    // 총알 이동
                    bullet.x++;
                    // 총알 우측 이동 -> 가장 우측 도달 시, 삭제
                    if (bullet.x > Game.w - 3) bullet.shoot = false;
                }
            }
        }

        // 아이템 목록
        public void ItemList()
        {
            int i = 0;
            foreach (var item in itemList)
            {
                // 아이템 목록 출력
                Console.SetCursorPosition(i, Game.h);
                Console.Write($"┏━━━━━┓");
                Console.SetCursorPosition(i, Game.h + 1);
                Console.Write($"┃{item.name}{item.count}┃");
                Console.SetCursorPosition(i, Game.h + 2);
                Console.Write($"┗━ {item.key} ━┛");
                i += 8;
            }
        }

        // 적 처치
        public void Kill(Enemy enemy, Item item)
        {
            foreach (var bullet in bullets)
            {
                // 총알 발사 및 충돌
                if (bullet.shoot
                    && bullet.y == enemy.y
                    && bullet.x >= enemy.x - 1
                    && bullet.x <= enemy.x + 7)
                {
                    Random rand = new Random();

                    // 아이템 랜덤 생성
                    if (!item.isMade)
                    {
                        item.isMade = true;

                        // 가장 상단 -> 아래로 이동
                        if (enemy.y == 1)
                            item.dY = false;
                        // 가장 하단 -> 위로 이동
                        else if (enemy.y == maxY)
                            item.dY = true;
                        else
                            item.dY = rand.Next(2) == 0;

                        // 아이템 좌표 = 죽은 적 좌표
                        item.x = enemy.x;
                        item.y = enemy.y;
                        item.madeTime = Environment.TickCount;
                    }

                    // 새로운 적 좌표
                    enemy.x = Game.w - 7;
                    enemy.y = rand.Next(1, Game.h - 1);

                    // 충돌된 총알 제거
                    bullet.shoot = false;

                    // 점수 상승
                    score += 100;
                }
            }
        }

        // 아이템 획득
        public void Get(Item item)
        {
            // 아이템 좌표 = 플레이어 좌표 -> 아이템 획득
            if (item.y == y
                && item.x >= x - 2
                && item.x <= x + 5)
            {
                item.x = 0;
                item.y = 0;
                item.isMade = false;
                itemList.Add(item);
            }
        }
    }

    // 총알 클래스
    public class Bullet
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool shoot { get; set; } = false;
    }

    // 적 클래스
    public class Enemy
    {
        // 적 변수
        public string shape { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        // 적 초기화
        public Enemy()
        {
            // 적 형태
            shape = "나쁜놈";
            // 적 좌표
            x = Game.w - 7;
            y = Game.h / 2;
        }

        // 적 그리기
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(shape);
        }

        // 적 이동
        public void Move()
        {
            Random rand = new Random();

            // 적 왼쪽 이동 -> 가장 좌측 도달 시, 새로운 적 생성
            if (--x < 2)
            {
                x = Game.w - 7;
                y = rand.Next(1, Game.h - 1);
            }
        }
    }

    // 아이템 클래스
    public class Item
    {
        // 아이템 변수
        public string name;
        public int count;
        public char key;
        public int x { get; set; }
        public int y { get; set; }

        public bool isMade { get; set; } = false;
        public int madeTime = Environment.TickCount;

        public bool dX { get; set; } = true;
        public bool dY { get; set; } = true;
        public int dChange { get; set; }

        // 아이템 그리기
        public void Create()
        {
            Console.SetCursorPosition(x, y);
            name = "폭탄";
            key = 'Q';
            Console.Write(name);
        }

        // 아이템 이동
        public void Move()
        {
            if (madeTime + 300 < Environment.TickCount)
            {
                madeTime = Environment.TickCount;

                // 아이템 좌우 이동 -> 가장 좌측/우측 도달 시, 방향 전환
                if (dX) x -= 3; else x += 3;
                if (x <= 2 || x >= Game.w - 5)
                {
                    dX = !dX;
                    dChange++;
                }

                // 아이템 상하 이동 -> 가장 상단/하단 도달 시, 방향 전환
                if (dY) y--; else y++;
                if (y <= 1 || y >= Game.h - 2)
                {
                    dY = !dY;
                    dChange++;
                }

                if (madeTime + 5 * 1000 <= Environment.TickCount || dChange > 5)
                {
                    dX = true;
                    dChange = 0;
                    isMade = false;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 콘솔 설정
            Console.CursorVisible = false;
            Console.SetWindowSize(Game.w, Game.h + Game.marginH);
            Console.SetBufferSize(Game.w, Game.h + Game.marginH);
            int dwTime = Environment.TickCount; // 1ms

            Game.Start();

            Player player = new Player(); // 플레이어 생성
            Enemy enemy = new Enemy(); // 적 생성
            Item item = new Item(); // 아이템 생성

            while (true)
            {
                // 지연
                if (dwTime + 1000 / Game.frame < Environment.TickCount)
                {
                    // 현재시간 세팅
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    // 게임 화면
                    Game.View(player, item);

                    // 총알 발사
                    player.Shoot();

                    // 적
                    enemy.Move(); // 이동
                    enemy.Draw(); // 그리기

                    // 처치
                    player.Kill(enemy, item);
                }
            }
        }
    }
}
