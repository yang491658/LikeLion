using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class BallData
    {
        public int ready;   // 공이 움직일 준비 상태
        public int direct;  // 공이 움직이는 방향 변수
        public int x, y;    // 공의 좌표
    }
}
