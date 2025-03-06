using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Field
    {
        Player m_pPlayer = null; // 플레이어
        Monster m_pMonster = null; // 몬스터

        // MainGame에서 생성한 플레이어 가지고 감
        public void SetPlayer(Player pPlayer) { m_pPlayer = pPlayer; }

        public void Progress()

        {
            //사냥터로 들어왔다.
            int iInput = 0;

            while (true)
            {
                Console.Clear();

                m_pPlayer.Render();
                DrawMap();

                iInput = int.Parse(Console.ReadLine());

                if (iInput == 4) break;

                // 몬스터 생성 (번호에 따라)
                if (iInput <= 3)
                {
                    // 몬스터 생성
                    CreateMonster(iInput);
                    // 전투
                    Fight();
                }
            }
        }

        public void DrawMap()
        {
            Console.WriteLine("1. 초보 맵");
            Console.WriteLine("2. 중수 맵");
            Console.WriteLine("3. 고수 맵");
            Console.WriteLine("4. 이전 단계");
            Console.WriteLine("=============");
            Console.WriteLine("맵을 선택하세요 : ");
        }


        public void CreateMonster(int input)
        {
            switch (input)
            {
                // 디자인 패턴, 팩토리, 메서드 패턴
                case 1:
                    Create("초급 몬스터", 30, 3, out m_pMonster);
                    break;
                case 2:
                    Create("중급 몬스터", 60, 6, out m_pMonster);
                    break;
                case 3:
                    Create("고급 몬스터", 90, 9, out m_pMonster);
                    break;
            }
        }

        public void Create(string _strName, int _iHp, int _iAttack, out Monster pMonster)
        {
            pMonster = new Monster(); // 몬스터 생성
            INFO tMonster = new INFO(); // 몬스터 데이터 메모리 주기 객체 생성

            tMonster.strName = _strName;
            tMonster.iHp = _iHp;
            tMonster.iAttack = _iAttack;

            pMonster.SetMonster(tMonster); // 생성된 데이터를 INFO 클래스 타입의 인자로 데이터 세팅
        }

        public void Fight()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear();
                m_pPlayer.Render(); // 플레이어 정보 출력
                m_pMonster.Render(); // 몬스터 정보 출력

                Console.WriteLine("1. 공격   2. 도망 : ");
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 1)
                {
                    // 플레이어에게 몬스터 공격력만큼 데미지 주기
                    m_pPlayer.SetDamage(m_pMonster.GetMonster().iAttack);
                    // 몬스터에게 플레이어 공격력만큼 데미지 주기
                    m_pMonster.SetDamage(m_pPlayer.GetInfo().iAttack);

                    // 플레이어 체력이 0 이하
                    if (m_pPlayer.GetInfo().iHp <= 0)
                    {
                        m_pPlayer.SetHp(100);
                        break;
                    }

                    if (iInput == 2 || m_pMonster.GetMonster().iHp <= 0)
                    {
                        m_pMonster = null;
                        break;
                    }
                }
            }
        }

        // 기본 생성자
        public Field() { }
        // 소멸자
        ~Field() { }
    }
}
