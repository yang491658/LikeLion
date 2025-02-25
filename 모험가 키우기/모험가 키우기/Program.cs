﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 모험가_키우기
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int gold = 500,
                health = 100,
                power = 10,
                input;
            bool isAlive = true;

            Console.WriteLine(" ⚔️ 모험가 키우기 ⚔️ ");
            Thread.Sleep(1000);

            while (isAlive)
            {
                Console.Clear();
                Console.WriteLine($" 현재 상태 : 체력 {health} | 골드 {gold} | 공격력 {power}");
                Console.WriteLine("\n1. 탐험하기 🏕");
                Console.WriteLine("2. 장비뽑기 🎲 (1000골드)");
                Console.WriteLine("3. 휴식하기 💤 (체력 +20)");
                Console.WriteLine("4. 게임 종료");

                Console.Write("입력 : ");
                input = int.Parse(Console.ReadLine());

                if (input == 1) // 1. 탐험하기
                {
                    Console.Clear();
                    Console.WriteLine("탐험을 떠납니다.");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다..");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다...");
                    Thread.Sleep(500);
                    Console.WriteLine("탐험을 떠납니다....");

                    int eventChance = rand.Next(1, 101); // 1~100 랜덤 이벤트 발생

                    if (eventChance <= 30) // 30% 확률로 전투 발생
                    {
                        int damage = rand.Next(5, 21); // 5~20 데미지 (체력 감소)
                        Console.WriteLine($"⚔️ 몬스터를 만났습니다. (체력 -{damage})");
                        health -= damage;
                    }
                    else if (eventChance <= 70) // 40% 확률로 보상 (골드 증가)
                    {
                        int reward = rand.Next(100, 301); //100~300 골드
                        Console.WriteLine($"💰 보물을 발견했습니다. (골드 +{reward})");
                        gold += reward;
                    }
                    else // 30% 확률로 체력 회복 (체력 증가)
                    {
                        int heal = rand.Next(10, 31); //10~30 회복
                        Console.WriteLine($"🌿 신비한 약초를 발견했습니다. (체력 +{heal})");
                        health += heal;
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("\n💀 체력이 0이 되어 사망했습니다... 게임 오버!");
                        isAlive = false;
                    }
                    Thread.Sleep(1000);
                }
                else if (input == 2) // 2. 장비뽑기
                {
                    if (gold >= 1000)
                    {
                        gold -= 1000;
                        Console.Clear();
                        Console.WriteLine("🎲 장비를 뽑습니다... ");
                        Thread.Sleep(1000);

                        int rnd = rand.Next(1, 101); // 1~100 랜덤 이벤트 발생

                        if (rnd == 1) // 1퍼센트
                        {
                            Console.WriteLine("SSS급 전설의 검 (공격력 +50) 획득");
                            power += 50;
                        }
                        else if (rnd <= 10) // 9퍼센트
                        {
                            Console.WriteLine("SS급 희귀한 검 (공격력 +30) 획득");
                            power += 30;
                        }
                        else if (rnd <= 30) // 30퍼센트
                        {
                            Console.WriteLine("S급 강철 검 (공격력 +20) 획득");
                            power += 20;
                        }
                        else // 60퍼센트
                        {
                            Console.WriteLine("녹슨 칼 (공격력 +5) 획득");
                            power += 5;
                        }
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("골드가 부족합니다. (1000골드 필요)");
                        Thread.Sleep(1000);
                    }
                }
                else if (input == 3) // 3. 휴식하기
                {
                    Console.WriteLine("휴식을 취합니다... (체력 +20)");
                    health += 20;
                    Thread.Sleep(1000);
                }
                else if (input == 4) // 4. 게임 종료
                {
                    Console.WriteLine("게임을 종료합니다.");
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
