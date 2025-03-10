using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TodayTask250228
{
// 게임 화면 클래스
public class Game
{
    // 전역 변수
    public static int width = 80; // 가로
    public static int height = 25; // 세로
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

    // 시작 화면 표사
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

    // 게임 화면 표시
    public static void Draw(Player player)
    {
        string text;

        // 구분선 표시
        Console.SetCursorPosition(0, Game.height);
        for (int i = 0; i < Game.width; i++) Console.Write("━");

        // 점수 표시
        text = $"[ 점수 : {Game.score}/{Game.maxScore} ]";
        Console.SetCursorPosition(Game.width - Encoding.Default.GetByteCount(text) - 1, Game.height);
        Console.Write(text);

        // 생명 표시
        Console.SetCursorPosition(1, Game.height);
        Console.Write("[ ");
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < player.currentLife; i++) Console.Write("♥ ");
        Console.ResetColor();
        for (int i = 0; i < player.maxLife - player.currentLife; i++) Console.Write("♡ ");
        Console.Write("]");

        // 탄창 표시
        text = $"[ 탄창 : {player.currentBullet}/{player.maxBullet} ]";
        Console.SetCursorPosition((Game.width - Encoding.Default.GetByteCount(text)) / 2, Game.height);
        Console.Write(text);

        // 장전 표시
        if (player.reloading)
        {
            int reloadCount = Environment.TickCount - player.reloadTime;
            int boxCount = (Encoding.Default.GetByteCount(text) - 4);
            int progress = (reloadCount * boxCount) / player.reloadDelay;
            Console.SetCursorPosition((Game.width - Encoding.Default.GetByteCount(text)) / 2, Game.height);
            text = $"[ {"■".PadRight(progress, '■').PadRight(boxCount, '□')} ]";
            Console.Write(text);
        }

        // 스탯 표시
        Console.SetCursorPosition(1, Game.height + 2);
        Console.Write($"폭탄 : {player.bombCount} / 데미지 : {player.bulletDamage} / 발사 속도 : {(double)player.shootDelay / 1000}초 / 장전 속도 : {(double)player.reloadDelay / 1000}초");
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

    // 플레이어 변수
    // 생명
    public int currentLife { get; set; } = 5;
    public int maxLife { get; set; } = 5;
    // 총알
    public List<Bullet> bulletList { get; set; } = new List<Bullet>();
    public int bulletDamage { get; set; } = 1;
    public int bulletCount { get; set; } = 1;
    // 탄창
    public int currentBullet { get; set; } = 5;
    public int maxBullet { get; set; } = 5;
    // 발사
    public int shootTime { get; set; } = Environment.TickCount;
    public int shootDelay { get; set; } = 1000;
    // 장전
    public bool reloading { get; set; } = false;
    public int reloadTime { get; set; }
    public int reloadDelay { get; set; } = 2000;
    // 폭탄
    public int bombCount { get; set; }
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
    }

    // 플레이어 표시
    public void Draw()
    {
        // 플레이어 형태
        string name = "착한놈";

        // 플레이어 출력
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(name);
        Console.ResetColor();
    }

    // 키 입력
    public void InputKey(Item item)
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
                case 72: y = Math.Max(y - 1, 0); break;    // 상
                case 75: x = Math.Max(x - 2, 0); break;    // 좌
                case 77: x = Math.Min(x + 2, maxX); break; // 우
                case 80: y = Math.Min(y + 1, maxY); break; // 하
                // 스페이스바 -> 총알 발사
                case 32:
                    // 총알 생성 : 지연 시간 초과 -> 재생성 가능
                    if (shootTime + shootDelay <= Environment.TickCount && currentBullet > 0 && !reloading)
                    {
                        shootTime = Environment.TickCount;
                        // 현재 탄창 감소
                        currentBullet--;
                        // 총알 생성
                        bulletList.Add(new Bullet { x = x + 2, y = y - 1, shoot = true, directionX = 0 });
                        // 총알 추가 생성
                        if (bulletCount >= 2 && x >= 1)
                            bulletList.Add(new Bullet { x = x - 1, y = y - 1, shoot = true, directionX = -1 });
                        if (bulletCount >= 3 && x <= Game.width - 6)
                            bulletList.Add(new Bullet { x = x + 5, y = y - 1, shoot = true, directionX = +1 });
                        if (bulletCount >= 4 && x >= 4)
                            bulletList.Add(new Bullet { x = x - 4, y = y - 1, shoot = true, directionX = -2 });
                        if (bulletCount >= 5 && x <= Game.width - 9)
                            bulletList.Add(new Bullet { x = x + 8, y = y - 1, shoot = true, directionX = +2 });
                    }
                    // 현재 탄창 수 = 0 -> 총알 장전
                    else if (currentBullet == 0 && !reloading)
                    {
                        reloading = true;
                        reloadTime = Environment.TickCount;
                    }
                    break;
                // R키 -> 총알 장전
                case 114:
                    if (currentBullet < maxBullet && !reloading)
                    {
                        reloading = true;
                        reloadTime = Environment.TickCount;
                    }
                    break;
                // Q키 -> 폭탄 사용
                case 113:
                    if (bombCount > 0)
                    {
                        // 폭탄 수 감소
                        bombCount--;
                        // 폭탄 생성
                        bulletList.Add(new Bullet { x = x + 2, y = y - 1, shoot = true, directionX = 0 });
                        bulletList.Add(new Bullet { x = x + 0, y = y - 0, shoot = true, directionX = 0 });
                        bulletList.Add(new Bullet { x = x + 0, y = y - 2, shoot = true, directionX = 0 });
                        bulletList.Add(new Bullet { x = x + 4, y = y - 0, shoot = true, directionX = 0 });
                        bulletList.Add(new Bullet { x = x + 4, y = y - 2, shoot = true, directionX = 0 });
                    }
                    break;
                // G키 -> 아이템 삭제
                case 103:
                    item.x = 0;
                    item.y = 0;
                    item.name = null;
                    item.exist = false;
                    break;
                // ESC키 -> 게임 종료
                case 27:
                    Environment.Exit(0);
                    return;
            }
        }
        // 총알 수 = 0 -> 자동 재장전
        else if (currentBullet == 0 && !reloading)
        {
            reloading = true;
            reloadTime = Environment.TickCount;
        }
    }

    // 총알 발사
    public void Shoot()
    {
        // 총알 형태
        string name = "  ";

        foreach (Bullet bullet in bulletList)
        {
            // 총알 표시
            if (bullet.shoot)
            {
                // 총알 출력
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(bullet.x, bullet.y);
                Console.WriteLine(name);
                Console.ResetColor();

                // 총알 위/좌/우로 이동 
                bullet.x += bullet.directionX;
                bullet.y--;
                // 총알 위치 = 가장 상단/좌측/우측 -> 제거
                if (bullet.x < 0
                    || bullet.x > Game.width - 2
                    || bullet.y < 0)
                    bullet.shoot = false;
            }
        }
    }

    // 총알 장전
    public void Reload()
    {
        if (reloading)
        {
            if (reloadTime + reloadDelay <= Environment.TickCount)
            {
                currentBullet = maxBullet;
                reloading = false;
            }
        }
    }

    // 적 처치
    public void Kill(List<Enemy> enemyList, Item item)
    {
        foreach (Bullet bullet in bulletList)
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

                    // 총알 제거
                    bullet.shoot = false;

                    // 적 체력 감소
                    enemy.health -= bulletDamage;

                    // 적 체력 0 이상 -> 유지
                    if (enemy.health > 0) continue;

                    // 적 체력 = 0 -> 적 제거 및 아이템 생성
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
                        item.x = enemy.x + 1;
                        item.y = enemy.y;
                        item.createtime = Environment.TickCount;
                        item.directionX = rand.Next(2) == 0;
                        item.directionY = true;
                    }

                    // 새로운 적 생성
                    enemy.Create();

                    Console.SetCursorPosition(bullet.x, bullet.y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("펑");
                    Console.ResetColor();

                    // 점수 및 킬 수 증가
                    Game.score += 100;
                    Game.killCount++;
                    // 최대 점수 저장
                    Game.maxScore = Math.Max(Game.score, Game.maxScore);
                    // 3킬 마다 -> 적 수 증가
                    if (Game.killCount % 3 == 0) enemyList.Add(new Enemy());
                    // 5킬 마다 -> 적 속도 증가 : 최대 1000
                    if (Game.killCount % 5 == 0) enemy.speed = Math.Min(enemy.speed * 2, 1000);
                }
            }
    }

    // 생명 감소
    public void Death(List<Enemy> enemyList)
    {
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            Enemy enemy = enemyList[i];

            // 적 위치 = 플레이어 좌표 -> 생명 감소
            if (enemy.y == y
                && enemy.x < x + 6
                && enemy.x + 6 > x)
            {
                // 생명 감소
                currentLife--;
                // 점수 감소
                Game.score -= 500;
                // 플레이어 생명 = 0 -> 게임 종료
                if (currentLife == 0) Environment.Exit(0);
                // 새로운 적 생성
                enemy.Create();
            }
        }
    }

    // 아이템 획득
    public void Get(Item item)
    {
        bool get = false;
        string getItem = default;

        // 아이템 위치 = 플레이어 좌표 -> 아이템 획득
        if (item.y == y
            && item.x <= x + 6
            && item.x + 4 >= x)
        {
            get = true;
            getItem = item.name;
            // 아이템 제거
            item.x = 0;
            item.y = 0;
            item.name = null;
            item.exist = false;
        }

        foreach (Bullet bullet in bulletList)
        {
            // 아이템 위치 = 총알 좌표 -> 아이템 획득
            if (bullet.shoot
                && item.x < bullet.x + 2
                && item.x + 4 > bullet.x
                && item.y <= bullet.y + 1
                && item.y >= bullet.y)
            {
                get = true;
                getItem = item.name;
                // 아이템 제거
                item.x = 0;
                item.y = 0;
                item.name = null;
                item.exist = false;
                // 총알 제거
                bullet.shoot = false;
            }
        }

        if (get)
            switch (getItem)
            {
                // 총알 스탯
                case "가속": // 발사 시간 50 감소 : 최소 10 / 장전 시간 10- 감소 : 최소 500
                    shootDelay = Math.Max(shootDelay - 50, 10);
                    reloadDelay = Math.Max(reloadDelay - 100, 500);
                    break;
                case "강화": // 현재 데미지 2배 증가 : 최대 5
                    bulletDamage = Math.Min(bulletDamage * 2, 5);
                    break;
                case "총알": // 현재 탄창 30% 증가
                    currentBullet = Math.Min(currentBullet + maxBullet / 3, maxBullet);
                    break;
                case "추가": // 총알 수 1 증가 : 최대 5
                    bulletCount = Math.Min(bulletCount + 1, 5);
                    break;
                case "탄창": // 최대 탄창 수 5 증가 : 최대 100
                    maxBullet = Math.Min(maxBullet + 5, 100);
                    currentBullet = maxBullet;
                    if (maxBullet < 100) reloadDelay = Math.Min(reloadDelay + 50, 2000);
                    break;
                case "폭탄": // 폭탄 수 1 증가 : 최대 5
                    bombCount = Math.Min(bombCount + 1, 5);
                    break;
                case "회복": // 현재 체력 1 증가
                    currentLife = Math.Min(currentLife + 1, maxLife);
                    break;
            }
    }
}

// 총알 클래스
public class Bullet
{
    // 총알 변수
    public bool shoot { get; set; }
    public int directionX { get; set; }
    // 총알 좌표
    public int x { get; set; }
    public int y { get; set; }
}

// 적 클래스
public class Enemy
{
    // 적 변수
    public string name { get; set; }
    public int health { get; set; }
    // 적 이동
    public int speed { get; set; } = 1;
    public int movetime { get; set; } = Environment.TickCount;
    public int createtime { get; set; } = Environment.TickCount;
    // 적 좌표
    public int x { get; set; }
    public int y { get; set; }

    // 적 초기화
    public Enemy()
    {
        // 적 형태
        name = "나쁜놈";
        // 적 생성
        Create();
    }

    // 적 그리기
    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        // 적 체력 표시
        switch (health)
        {
            case 1: Console.ForegroundColor = ConsoleColor.DarkGray; break;
            case 2: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
            case 3: Console.ForegroundColor = ConsoleColor.Magenta; break;
            case 4: Console.ForegroundColor = ConsoleColor.Red; break;
            case 5: Console.ForegroundColor = ConsoleColor.DarkRed; break;
        }
        Console.WriteLine(name);
        Console.ResetColor();
        Move();
    }

    // 적 생성
    public void Create()
    {
        Random rand = new Random();

        createtime = Environment.TickCount;
        x = rand.Next(0, Game.width - 5);
        y = 0;
        health = 5;
    }

    // 적 이동
    public void Move()
    {
        Random rand = new Random();

        // 적 이동 : 스피드에 따라
        if (movetime + 1000 / speed < Environment.TickCount)
        {
            movetime = Environment.TickCount;

            // 적 좌/우로 이동
            x += 2 * (rand.Next(3) - 1);
            if (x < 0) x = 0;
            else if (x > Game.width - 6) x = Game.width - 6;

            // 적 아래로 이동 -> 적 위치 = 가장 하단 -> 가장 상단
            if (++y > Game.height - 1) y = 0;
        }

        // 적 15초 경과 -> 패널티 부여 
        if (createtime + 15 * 1000 <= Environment.TickCount)
        {
            // 패널티 : 적 체력 상승
            if (health < 5)
            {
                createtime = Environment.TickCount;
                health++;
            }
            // 패널티 : 점수 하락 및 적 재생성 
            else
            {
                Game.score -= 100;
                Create();
            }
        }
    }
}

// 아이템 클래스
public class Item
{
    // 아이템 변수
    public string name { get; set; } = default;
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
    public void Draw(Player player)
    {
        Random rand = new Random();
        // 아이템 목록 
        List<string> itemList = new List<string> { "총알" };
        if (player.shootDelay > 10 && player.reloadDelay > 500)
            for (int i = 0; i < 5; i++) itemList.Add("가속");
        if (player.bulletDamage < 5)
            for (int i = 0; i < 3; i++) itemList.Add("강화");
        if (player.bulletCount < 5)
            for (int i = 0; i < 5; i++) itemList.Add("추가");
        if (player.maxBullet < 100)
            for (int i = 0; i < 10; i++) itemList.Add("탄창");
        if (player.bombCount < 5)
            for (int i = 0; i < 10; i++) itemList.Add("폭탄");
        if (player.currentLife < 5)
            for (int i = 0; i < 5; i++) itemList.Add("회복");

        // 아이템 랜덤 생성
        if (name == null) name = itemList[rand.Next(itemList.Count)];

        // 아이템 출력
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(name);
        Console.ResetColor();
        Move();
    }

    // 아이템 이동
    public void Move()
    {
        // 아이템 이동 : 0.3초 마다
        if (movetime + 300 < Environment.TickCount)
        {
            movetime = Environment.TickCount;

            //// 아이템 좌/우로 이동 : 아이템 위치 = 가장 좌측/우측 -> 방향 전환
            //if (directionX) x -= 4; else x += 4;
            //if (x < 0 || x + 4 > Game.width)
            //{
            //    x = x <= 0 ? 0 : Game.width - 4;
            //    directionX = !directionX;
            //}

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

        while (true)
        {
            // 프레임 지연
            if (time + 1000 / Game.frame < Environment.TickCount)
            {
                Console.Clear();

                // 현재 시간
                time = Environment.TickCount;

                // 게임 화면 표시
                Game.Draw(player);

                // 기본 표시
                player.Draw(); // 플레이어
                foreach (Enemy enemy in enemyList) enemy.Draw(); // 적
                if (item.exist) item.Draw(player);// 아이템

                // 플레이어
                player.InputKey(item); // 키 입력
                player.Shoot(); // 총알 발사
                player.Death(enemyList); // 적 피격
                player.Reload(); // 총알 장전

                player.Kill(enemyList, item); // 적 처치
                player.Get(item); // 아이템 획득
            }
        }
    }
}
}
