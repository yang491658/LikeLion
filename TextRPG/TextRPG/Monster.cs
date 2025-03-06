using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Monster
    {
        public INFO m_tMonster;  // 몬스터 데이터

        // 들어오는 인자값으로 hp 감소
        public void SetDamage(int iAttack) { m_tMonster.iHp -= iAttack; }

        // Info 클래스 타입 인자로 몬스터 데이터를 넣어줌
        public void SetMonster(INFO tMonster) { m_tMonster = tMonster; }

        public INFO GetMonster() { return m_tMonster; }

        // 출력
        public void Render()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("몬스터 이름 : " + m_tMonster.strName);
            Console.WriteLine("체력 : " + m_tMonster.iHp + " / 공격력 : " + m_tMonster.iAttack);
        }

        // 기본 생성자
        public Monster() { }

        // 소멸자
        ~Monster() { }
    }
}
