﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame2
{
    // 미사일 클래스
    public class Bullet
    {
        public int x;
        public int y;
        public bool fire;
    }

    // 플레이어 클래스
public class Player
{
    [DllImport("msvcrt.dll")]
    static extern int _getch(); // C언어 함수 가져옴

    // 플레이어 변수
    public int playerX;
    public int playerY;
    public Bullet[] playerBullet = new Bullet[20];
    public Bullet[] playerBullet2 = new Bullet[20];
    public Bullet[] playerBullet3 = new Bullet[20];
    public int Score = 100;
    public Item item = new Item();
    public int itemCount = 0;

    // 생성자
    public Player()
    {
        // 플레이어 좌표 초기화
        playerX = 0;
        playerY = 12;

        // 미사일 초기화
        for (int i = 0; i < 20; i++)
        {
            playerBullet[i] = new Bullet();
            playerBullet[i].x = 0;
            playerBullet[i].y = 0;
            playerBullet[i].fire = false;

            playerBullet2[i] = new Bullet();
            playerBullet2[i].x = 0;
            playerBullet2[i].y = 0;
            playerBullet2[i].fire = false;

            playerBullet3[i] = new Bullet();
            playerBullet3[i].x = 0;
            playerBullet3[i].y = 0;
            playerBullet3[i].fire = false;
        }
    }

    public void GameMain()
    {
        KeyControl(); // 키를 입력하는 부분
        PlayerDraw(); // 플레이어 그리기
        UIscore(); // UI점수

        // 아이템 그리기
        if (item.ItemLife)
        {
            item.ItemMove();
            item.ItemDraw();
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
                case 72: // 위쪽 방향키 아스키 코드
                    playerY--;
                    if (playerY < 1) playerY = 1;
                    break;
                case 75: // 왼쪽 방향키
                    playerX--;
                    if (playerX < 0) playerX = 0;
                    break;
                case 77: // 오른쪽 방향키
                    playerX++;
                    if (playerX > 75) playerX = 75;
                    break;
                case 80: // 아래쪽 방향키
                    playerY++;
                    if (playerY > 22) playerY = 22;
                    break;
                case 32: // 스페이스바
                            // 미사일 발사
                    for (int i = 0; i < 20; i++)
                    {
                        // 미사일 false = 발사 가능
                        if (playerBullet[i].fire == false)
                        {
                            // 미사일 true = 발사 중
                            playerBullet[i].fire = true;

                            // 플레이어 앞에서 미사일 쏘기
                            playerBullet[i].x = playerX + 5;
                            playerBullet[i].y = playerY;

                            break; // 1발씩 발사
                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        // 미사일 false = 발사 가능
                        if (playerBullet2[i].fire == false)
                        {
                            // 미사일 true = 발사 중
                            playerBullet2[i].fire = true;

                            // 플레이어 앞에서 미사일 쏘기
                            playerBullet2[i].x = playerX + 5;
                            playerBullet2[i].y = playerY + 1;

                            break; // 1발씩 발사
                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        // 미사일 false = 발사 가능
                        if (playerBullet3[i].fire == false)
                        {
                            // 미사일 true = 발사 중
                            playerBullet3[i].fire = true;

                            // 플레이어 앞에서 미사일 쏘기
                            playerBullet3[i].x = playerX + 5;
                            playerBullet3[i].y = playerY - 1;

                            break; // 1발씩 발사
                        }
                    }
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
            Console.SetCursorPosition(playerX, playerY + i - 1); // 콘솔 좌표 설정
            Console.WriteLine(playerShape[i]); // 문자열 배열 출력
        }
    }

    // 미사일 그리기
    public void BulletDraw()
    {
        // 미사일 형태
        string bulletSymbol = "->";

        for (int i = 0; i < 20; i++)
        {
            // 미사일 true = 미사일이 살아있는 상태
            if (playerBullet[i].fire == true)
            {
                // 좌표설정 -> 중간 위치를 위한 보정을 위해 x-1
                Console.SetCursorPosition(playerBullet[i].x, playerBullet[i].y);

                Console.Write(bulletSymbol); // 미사일 출력

                playerBullet[i].x++; // 미사일 발사 : 오른쪽으로 이동

                // 가장 오른쪽에 도달 시 -> 미사일 false = 다시 준비 상태
                if (playerBullet[i].x > 78)
                {
                    playerBullet[i].fire = false;
                }
            }
        }
    }

    // 미사일 그리기 2
    public void BulletDraw2()
    {
        // 미사일 형태
        string bulletSymbol = "->";

        for (int i = 0; i < 20; i++)
        {
            // 미사일 true = 미사일이 살아있는 상태
            if (playerBullet2[i].fire == true)
            {
                // 좌표설정 -> 중간 위치를 위한 보정을 위해 x-1
                Console.SetCursorPosition(playerBullet2[i].x, playerBullet2[i].y);

                Console.Write(bulletSymbol); // 미사일 출력

                playerBullet2[i].x++; // 미사일 발사 : 오른쪽으로 이동

                // 가장 오른쪽에 도달 시 -> 미사일 false = 다시 준비 상태
                if (playerBullet2[i].x > 78)
                {
                    playerBullet2[i].fire = false;
                }
            }
        }
    }

    // 미사일 그리기 3
    public void BulletDraw3()
    {
        // 미사일 형태
        string bulletSymbol = "->";

        for (int i = 0; i < 20; i++)
        {
            // 미사일 true = 미사일이 살아있는 상태
            if (playerBullet3[i].fire == true)
            {
                // 좌표설정 -> 중간 위치를 위한 보정을 위해 x-1
                Console.SetCursorPosition(playerBullet3[i].x, playerBullet3[i].y);

                Console.Write(bulletSymbol); // 미사일 출력

                playerBullet3[i].x++; // 미사일 발사 : 오른쪽으로 이동

                // 가장 오른쪽에 도달 시 -> 미사일 false = 다시 준비 상태
                if (playerBullet3[i].x > 78)
                {
                    playerBullet3[i].fire = false;
                }
            }
        }
    }

    // 충돌처리
    public void ClashEnemyAndBullet(Enemy enemy)
    {
        for (int i = 0; i < 20; i++)
        {
            // 발사중인 미사일
            if (playerBullet[i].fire == true)
            {
                // 미사일과 적의 y값이 같을 떄
                if (playerBullet[i].y == enemy.enemyY)
                {
                    // 충돌
                    if (playerBullet[i].x >= enemy.enemyX - 1
                        && playerBullet[i].x <= enemy.enemyX + 1)
                    {
                        // 아이템 생성
                        item.ItemLife = true;
                        item.itemX = enemy.enemyX;
                        item.itemY = enemy.enemyY;

                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet[i].fire = false; // 미사일도 준비 상태

                        Score += 100; // 스코어 상승
                    }
                }
            }
        }

        for (int i = 0; i < 20; i++)
        {
            // 발사중인 미사일
            if (playerBullet2[i].fire == true)
            {
                // 미사일과 적의 y값이 같을 떄
                if (playerBullet2[i].y == enemy.enemyY)
                {
                    // 충돌
                    if (playerBullet2[i].x >= enemy.enemyX - 1
                        && playerBullet2[i].x <= enemy.enemyX + 1)
                    {
                        // 아이템 생성
                        item.ItemLife = true;
                        item.itemX = enemy.enemyX;
                        item.itemY = enemy.enemyY;

                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet2[i].fire = false; // 미사일도 준비 상태

                        Score += 100; // 스코어 상승
                    }
                }
            }
        }

        for (int i = 0; i < 20; i++)
        {
            // 발사중인 미사일
            if (playerBullet3[i].fire == true)
            {
                // 미사일과 적의 y값이 같을 떄
                if (playerBullet3[i].y == enemy.enemyY)
                {
                    // 충돌
                    if (playerBullet3[i].x >= enemy.enemyX - 1
                        && playerBullet3[i].x <= enemy.enemyX + 1)
                    {
                        // 아이템 생성
                        item.ItemLife = true;
                        item.itemX = enemy.enemyX;
                        item.itemY = enemy.enemyY;

                        Random rand = new Random();
                        enemy.enemyX = 75;
                        enemy.enemyY = rand.Next(2, 22);

                        playerBullet3[i].fire = false; // 미사일도 준비 상태

                        Score += 100; // 스코어 상승
                    }
                }
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
        if (playerY >= item.itemY - 1 && playerY <= item.itemY + 1)
        {
            if (playerX >= item.itemX - 2 && playerX <= item.itemX + 2)
            {
                item.ItemLife = false;

                if (itemCount < 3) itemCount++;

                //총알 초기화
                for (int i = 0; i < 20; i++)
                {
                    playerBullet[i] = new Bullet();
                    playerBullet[i].x = 0;
                    playerBullet[i].y = 0;
                    playerBullet[i].fire = false;

                    playerBullet2[i] = new Bullet();
                    playerBullet2[i].x = 0;
                    playerBullet2[i].y = 0;
                    playerBullet2[i].fire = false;

                    playerBullet3[i] = new Bullet();
                    playerBullet3[i].x = 0;
                    playerBullet3[i].y = 0;
                    playerBullet3[i].fire = false;
                }
            }
        }
    }
}

    // 적 클래스
    public class Enemy
    {
        public int enemyX;
        public int enemyY;

        // 적 좌표 초기화
        public Enemy()
        {
            enemyX = 75;
            enemyY = 12;
        }

        public void EnemyDraw()
        {
            string enemyShape = "<-0->"; // 적을 문자열로 표현
            Console.SetCursorPosition(enemyX, enemyY); // 좌표 설정
            Console.Write(enemyShape);
        }

        public void EnemyMove()
        {
            Random rand = new Random();

            enemyX--; // 왼쪽으로 이동

            // 가장 왼쪽 도달 시, 새로운 적 생성
            if (enemyX < 2)
            {
                enemyX = 75;
                enemyY = rand.Next(2, 22);
            }
        }
    }

    // 아이템 클래스
    public class Item
    {
        public string ItemName;
        public string ItemShape;
        public int itemX = 0;
        public int itemY = 0;
        public bool ItemLife = false;

        // 아이템 그리기
        public void ItemDraw()
        {
            Console.SetCursorPosition(itemX, itemY);
            ItemShape = "Item★";
            Console.Write(ItemShape);
        }

        // 아이템 이동
        public void ItemMove()
        {
            itemX--;
            if (itemX <= 1 || itemY <= 1) ItemLife = false;
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
                    if (player.itemCount == 0)
                    {
                        player.BulletDraw();
                    }
                    else if (player.itemCount == 1)
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                    }
                    else
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                        player.BulletDraw3();
                    }

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

