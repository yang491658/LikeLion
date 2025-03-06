using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player
    {
        public INFO m_tInfo;

        // 데미지를 입는 함수
        public void SetDamage(int iAttack) { m_tInfo.iHp -= iAttack; }

        // 플레이어 정보를 외부에서 볼 수 있는 함수
        public INFO GetInfo() { return m_tInfo; }

        // HP를 다시 설정해주는 함수
        public void SetHp(int iHp) { m_tInfo.iHp = iHp; }

        // 직업 선택
        public void SelectJob()
        {
            m_tInfo = new INFO();
            int iInput = 0;

            Console.WriteLine("직업을 선택하세요 (1. 기사   2. 마법사   3. 도둑) : ");
            iInput = int.Parse(Console.ReadLine());
            switch (iInput)
            {
                case 1:
                    m_tInfo.strName = "기사";
                    m_tInfo.iHp = 100;
                    m_tInfo.iAttack = 10;
                    break;
                case 2:
                    m_tInfo.strName = "마법사";
                    m_tInfo.iHp = 90;
                    m_tInfo.iAttack = 15;
                    break;
                case 3:
                    m_tInfo.strName = "도둑";
                    m_tInfo.iHp = 85;
                    m_tInfo.iAttack = 13;
                    break;
            }
        }

        // 출력
        public void Render()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("직업 이름 : " + m_tInfo.strName);
            Console.WriteLine("체력 : " + m_tInfo.iHp + " / 공격력 : " + m_tInfo.iAttack);
        }

        // 기본 생성자
        public Player() { }

        // 소멸자
        ~Player() { }
    }
}
