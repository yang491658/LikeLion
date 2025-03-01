using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TodayTask250228
{
    // 게임 화면 클래스
    public class Game
    {
        // 전역 변수
        public static int width = 60; // 가로
        public static int height = 20; // 세로
        public static int bottom = 5; // 하단 여백
        public static int frame = 20; // 프레임
        public static int score = 0; // 점수
        public static int maxScore = 0; // 점수
        public static int killCount = 0; // 킬 수

        // 제목 변수
        private static string title1 = "SHOOTING";
        private static string title2 = "    GAME";
        private static string[] box =
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
            int marginX = width / 10; ;
            int marginY = height / 10;

            PrintSide();
            PrintTile(title1, marginX, marginY);
            PrintTile(title2, marginX, height - marginY - box.Length);

            while (!Console.KeyAvailable)
            {
                string text = "아무 키나 누르시면 게임이 시작됩니다.";
                Console.SetCursorPosition((width - Encoding.Default.GetByteCount(text)) / 2, height / 2);

                for (int i = 0; i < text.Length; i++)
                {
                    Console.Write(text[i]);
                    Thread.Sleep(200 / frame);
                }
            }
        }

        // 제목 출력
        private static void PrintTile(string title, int marginX, int marginY)
        {
            // 변수
            int boxWidth = Encoding.Default.GetByteCount(box[0]); // 박스 크기
            int titleCount = title.Length; // 제목 글자 수
            int intervalX = (width - 2 - 2 * marginX - titleCount * boxWidth) / (titleCount - 1); // 제목 간격

            // 각 제목 글자 출력
            for (int i = 0; i < titleCount; i++)
            {
                // 빈칸은 패스
                if (title[i] == ' ') continue;

                // 제목 박스
                for (int j = 0; j < box.Length; j++)
                {
                    Console.SetCursorPosition(1 + marginX + i * (intervalX + boxWidth), marginY + j);
                    Console.WriteLine(box[j]);
                    Thread.Sleep(200 / frame);
                }

                // 제목 글자
                Console.SetCursorPosition(1 + boxWidth / 2 + marginX + i * (intervalX + boxWidth), marginY + 2);
                Console.WriteLine(title[i]);
            }
        }

        // 테두리 출력
        public static void PrintSide()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (x == 0 && y == 0) Console.Write("┏");
                    else if (x == width - 1 && y == 0) Console.Write("┓");
                    else if (x == 0 && y == height - 1) Console.Write("┗");
                    else if (x == width - 1 && y == height - 1) Console.Write("┛");
                    else if (x == 0 || x == width - 1) Console.Write("┃");
                    else if (y == 0 || y == height - 1) Console.Write("━");
                }
                Console.WriteLine();
            }
        }
    }

    // 플레이어 클래스
    public class Player
    {
        // C언어 함수
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        // 플레이어 변수 : 총알
        public List<Bullet> bulletList { get; set; } = new List<Bullet>();
        public int shootTime { get; set; } = Environment.TickCount;
        public int shootDelay { get; set; } = 1000;
        // 플레이어 변수 : 인벤토리

        // 플레이어 좌표
        public int x { get; set; }
        public int y { get; set; }
        // 플레이어 최대 좌표
        public int maxX { get; set; }
        public int maxY { get; set; }

        // 플레이어 생성자
        public Player()
        {
            // 플레이어 좌표
            x = (Game.width - 6) / 2;
            y = Game.height - 1;
            maxX = Game.width - 6;
            maxY = Game.height - 1;

            // 총알 생성
            for (int i = 0; i < 20; i++) bulletList.Add(new Bullet());
        }

        // 키 입력
        public void InputKey()
        {
            // 정수형 변수 선언 : 키 값 입력
            int key;

            // 키가 눌렸을 때
            if (Console.KeyAvailable)
            {
                // 아스키 값 : 입력한 키를 아스키 코드로 받음
                key = _getch();

                // 실제 키 값 읽기 -> 중복 입력 방지
                if (key == 224 || key == 0) key = _getch();

                switch (key)
                {
                    // 방향키 -> 플레이어 이동
                    case 72: y = Math.Max(4 * maxY / 5, y - 1); break;    // 상
                    case 75: x = Math.Max(0, x - 2); break;    // 좌
                    case 77: x = Math.Min(maxX, x + 2); break; // 우
                    case 80: y = Math.Min(maxY, y + 1); break; // 하

                    // 스페이스바 -> 총알 생성
                    case 32:
                        // 총알 생성 : 지연 시간 초과 -> 재생성 가능
                        if (shootTime + shootDelay <= Environment.TickCount)
                        {
                            bulletList.Add(new Bullet { x = x + 2, y = y - 1, shoot = true });
                            shootTime = Environment.TickCount;
                        }
                        break;

                    // ESC -> 게임 종료
                    case 27:
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
            foreach (var bullet in bulletList)
            {
                // 총알 발사
                if (bullet.shoot)
                {
                    // 총알 출력
                    Console.SetCursorPosition(bullet.x, bullet.y);
                    Console.Write(shape);

                    // 총알 위로 이동 : 가장 상단에 도달 -> 제거
                    if (--bullet.y < 0) bullet.shoot = false;
                }
            }
        }

        // 적 처치
        public void Kill(List<Enemy> enemyList, Item item)
        {
            foreach (var bullet in bulletList)
            {
                for (int i = enemyList.Count - 1; i >= 0; i--)
                {
                    Enemy enemy = enemyList[i];

                    // 총알 위치 = 적 좌표 -> 적 처치
                    if (bullet.shoot
                    && bullet.x < enemy.x + 6
                    && bullet.x + 2 > enemy.x
                    && bullet.y <= enemy.y + 1
                    && bullet.y >= enemy.y)
                    {
                        Random rand = new Random();

                        // 아이템 생성
                        if (!item.exist)
                        {
                            item.exist = true;

                            // 적 위치 = 가장 좌측 -> 아이템 우로 이동
                            if (enemy.x <= 0) item.directionX = false;
                            // 적 위치 = 가장 우측 -> 아이템 좌로 이동
                            else if (enemy.x + 6 >= Game.width) item.directionX = true;
                            // 적 위치 = 그 외 -> 아이템 좌/우로 랜덤 이동
                            else item.directionX = rand.Next(2) == 0;

                            // 아이템 생성 : 아이템 위치 = 죽은 적 좌표
                            item.x = enemy.x;
                            item.y = enemy.y;
                            item.createtime = Environment.TickCount;
                        }

                        // 총알 제거
                        bullet.shoot = false;

                        // 새로운 적 생성
                        enemy.Create();

                        // 점수 및 킬 수 상승
                        Game.score += 100;
                        Game.killCount++;
                        // 최대 점수 저장
                        Game.maxScore = Math.Max(Game.maxScore, Game.score);
                        // 3킬 마다 -> 적 추가
                        if (Game.killCount % 3 == 0) enemyList.Add(new Enemy());
                        // 5킬 마다 -> 적 속도 상승
                        if (Game.killCount % 5 == 0) enemy.speed++;
                    }
                }
            }
        }

        // 아이템 획득
        public void Get(Item item)
        {
            // 아이템 위치 = 플레이어 좌표 -> 아이템 획득
            if (item.y == y
                && item.x <= x + 6
                && item.x + 4 >= x)
            {
                item.x = 0;
                item.y = 0;
                item.exist = false;
            }

            foreach (var bullet in bulletList)
            {
                // 아이템 위치 = 총알 좌표 -> 아이템 획득
                if (bullet.shoot
                    && item.x < bullet.x + 2
                    && item.x + 4 > bullet.x
                    && item.y <= bullet.y + 1
                    && item.y >= bullet.y)
                {
                    item.x = 0;
                    item.y = 0;
                    item.exist = false;
                    bullet.shoot = false;
                }
            }
        }
    }

    // 인벤토리 클래스 
    public class Inventory
    {
        // 인벤토리 그리기
        public void Draw()
        {
            //int i = 0;
            //foreach (var item in itemList)
            //{
            //    // 아이템 목록 출력
            //    Console.SetCursorPosition(i, Game.height);
            //    Console.Write($"┏━━━━━┓");
            //    Console.SetCursorPosition(i, Game.height + 1);
            //    Console.Write($"┃{item.name}{item.count}┃");
            //    Console.SetCursorPosition(i, Game.height + 2);
            //    Console.Write($"┗━ {item.key} ━┛");
            //    i += 8;
            //}
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
        public string name { get; set; }
        public int speed { get; set; } = 1;
        public int movetime { get; set; } = Environment.TickCount;
        public int createtime { get; set; } = Environment.TickCount;
        // 적 좌표
        public int x { get; set; }
        public int y { get; set; }
        // 적 방향
        public int direction { get; set; } = 1;

        // 적 초기화
        public Enemy()
        {
            // 적 형태
            name = "나쁜놈";
            // 적 좌표
            x = (Game.width - 6) / 2;
            y = 0;
        }

        // 적 그리기
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(name);
            Move();
        }

        // 적 생성
        public void Create()
        {
            Random rand = new Random();
            createtime = Environment.TickCount;
            direction = rand.Next(1, 9);
            switch (rand.Next(3))
            {
                case 0:
                    x = rand.Next(1, Game.width - 6);
                    y = 0;
                    break;
                case 1:
                    x = 0;
                    y = rand.Next(0, Game.height / 5);
                    break;
                case 2:
                    x = Game.width - 6;
                    y = rand.Next(0, Game.height / 5);
                    break;
            }
        }

        // 적 이동
        public void Move()
        {
            Random rand = new Random();

            // 적 이동 : 스피드에 따라
            if (movetime + 1000 / speed < Environment.TickCount)
            {
                movetime = Environment.TickCount;

                // 적 이동 : 8방향 중 랜덤
                // 적 위치 가장 상단/하단/좌측/우측 -> 방향 전환
                switch (direction)
                {
                    case 1:
                        y++;
                        if (y >= Game.height - 1) { y = Game.height - 1; direction = 5; }
                        break;
                    case 2:
                        x -= 6; y++;
                        if (x <= 0) { x = 0; direction = 8; }
                        if (y >= Game.height - 1) { y = Game.height - 1; direction = 4; }
                        break;
                    case 3:
                        x -= 4;
                        if (x <= 0) { x = 0; direction = 7; }
                        break;
                    case 4:
                        x -= 6; y--;
                        if (x <= 0) { x = 0; direction = 6; }
                        if (y <= 0) { y = 0; direction = 2; }
                        break;
                    case 5:
                        y--;
                        if (y <= 0) { y = 0; direction = 1; }
                        break;
                    case 6:
                        x += 6; y--;
                        if (x + 6 >= Game.width) { x = Game.width - 6; direction = 4; }
                        if (y <= 0) { y = 0; direction = 8; }
                        break;
                    case 7:
                        x += 4;
                        if (x + 6 >= Game.width) { x = Game.width - 6; direction = 3; }
                        break;
                    case 8:
                        x += 6; y++;
                        if (x + 6 >= Game.width) { x = Game.width - 6; direction = 2; }
                        if (y >= Game.height - 1) { y = Game.height - 1; direction = 6; }
                        break;
                }
            }

            // 적 15초 경과 -> 점수 하락 및 적 재생성 
            if (createtime + 15 * 1000 <= Environment.TickCount) { Game.score -= 100; Create(); }
        }
    }

    // 아이템 클래스
    public class Item
    {
        // 아이템 변수
        public string name { get; set; }
        public bool exist { get; set; } = false;
        public int movetime { get; set; } = Environment.TickCount;
        public int createtime { get; set; } = Environment.TickCount;
        // 아이템 좌표
        public int x { get; set; }
        public int y { get; set; }
        // 아이템 방향
        public bool directionX { get; set; } = true;
        public bool directionY { get; set; } = true;

        // 아이템 그리기
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            name = "폭탄";
            Console.Write(name);
            Move();
        }

        // 아이템 이동
        public void Move()
        {
            // 아이템 이동 : 0.3초 마다
            if (movetime + 300 < Environment.TickCount)
            {
                movetime = Environment.TickCount;

                // 아이템 좌/우로 이동 : 아이템 위치 = 가장 좌측/우측 -> 방향 전환
                if (directionX) x -= 4; else x += 4;
                if (x < 0 || x + 4 > Game.width)
                {
                    x = x <= 0 ? 0 : Game.width - 4;
                    directionX = !directionX;
                }

                // 아이템 위/아래로 이동 : 아이템 위치 = 가장 상단/하단 -> 방향 전환
                if (directionY) y++; else y--;
                if (y < 0 || y > Game.height - 1)
                {
                    y = y <= 0 ? 0 : Game.height - 1;
                    directionY = !directionY;
                }

                // 아이템 10초 경과 -> 아이템 제거
                if (createtime + 10000 <= Environment.TickCount) exist = false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 콘솔 설정
            Console.CursorVisible = false;
            Console.SetWindowSize(Game.width, Game.height + Game.bottom);
            Console.SetBufferSize(Game.width, Game.height + Game.bottom);
            // 인게임 시간
            int time = Environment.TickCount; // 1ms

            Game.Start();

            // 객체 생성
            Player player = new Player(); // 플레이어 생성
            List<Enemy> enemyList = new List<Enemy>(); // 적 목록 생성
            enemyList.Add(new Enemy()); // 적 추가
            Item item = new Item(); // 아이템 생성
            string scoreText;

            while (Game.score >= 0)
            {
                // 지연
                if (time + 1000 / Game.frame < Environment.TickCount)
                {
                    Console.Clear();

                    // 현재 시간
                    time = Environment.TickCount;

                    // 구분선 그리기
                    Console.SetCursorPosition(0, Game.height);
                    for (int i = 0; i < Game.width; i++) Console.Write("━");

                    // 점수 출력
                    scoreText = "[점수 : " + Game.score + "]";
                    Console.SetCursorPosition((Game.width - Encoding.Default.GetByteCount(scoreText)) / 2, Game.height);
                    Console.Write(scoreText);

                    // 기본 그리기
                    player.Draw(); // 플레이어
                    foreach (var enemy in enemyList) enemy.Draw(); // 적
                    if (item.exist) item.Draw();// 아이템

                    // 플레이어
                    player.InputKey(); // 키 입력
                    player.Shoot(); // 총알 발사
                    player.Kill(enemyList, item); // 적 처치
                    player.Get(item); // 아이템 획득
                }
            }
        }
    }
}
