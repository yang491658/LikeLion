using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int loading = 300;
            const int delay = 1000;

            Console.WriteLine("엔터를 입력하면 시작합니다.");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("□ □ □ □ □ □");
            Console.WriteLine("");
            Console.WriteLine("로 딩 중 입 니 다");
            Console.WriteLine("□ □ □ □ □ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ □ □ □ □ □");
            Console.WriteLine("로");
            Console.WriteLine("   딩 중 입 니 다");
            Console.WriteLine("■ □ □ □ □ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ ■ □ □ □ □");
            Console.WriteLine("   딩");
            Console.WriteLine("로    중 입 니 다");
            Console.WriteLine("■ ■ □ □ □ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ ■ ■ □ □ □");
            Console.WriteLine("      중");
            Console.WriteLine("로 딩    입 니 다");
            Console.WriteLine("■ ■ ■ □ □ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ ■ ■ ■ □ □");
            Console.WriteLine("         입");
            Console.WriteLine("로 딩 중    니 다");
            Console.WriteLine("■ ■ ■ ■ □ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ ■ ■ ■ ■ □");
            Console.WriteLine("            니");
            Console.WriteLine("로 딩 중 입    다");
            Console.WriteLine("■ ■ ■ ■ ■ □");
            Thread.Sleep(loading);
            Console.Clear();

            Console.WriteLine("■ ■ ■ ■ ■ ■");
            Console.WriteLine("               다");
            Console.WriteLine("로 딩 중 입 니   ");
            Console.WriteLine("■ ■ ■ ■ ■ ■");
            Thread.Sleep(loading);
            Console.Clear();

            Console.Write("??? : 당신의 이름은 무엇인가요? ");
            string name = Console.ReadLine();

            Console.Write($"??? : {name}님 반갑습니다. 당신의 나이는 어떻게 되나요? ");
            int age = int.Parse(Console.ReadLine());

            Console.Write($"??? : 그러면 당신의 직업은 무엇인가요? ");
            string job = Console.ReadLine();

            Console.WriteLine($"??? : {age}살의 {job}인 {name}님은 지금부터 눈을 감았다 뜨면 이름 모를 이야기의 어딘가로 이동할 것입니다.");
            Thread.Sleep(delay);
            Console.WriteLine("??? : 당신의 [능력]에 따라서 이야기가 진행될 것이고,");
            Thread.Sleep(delay);
            Console.WriteLine("??? : 당신의 [선택]에 따라서 이야기의 결말이 바뀔 것입니다.");
            Thread.Sleep(delay);
            Console.WriteLine("??? : 그럼 건투를 빕니다.");
            Thread.Sleep(delay);
            Console.Clear();

            Console.WriteLine("당신은 눈을 감았다 뜨니 방금 전까지 대화 주고받던 목소리는 어디에도 없고,");
            Thread.Sleep(delay);
            Console.WriteLine("어쩌다가 이곳에 왔는지 모르겠지만 깊은 숲속으로 이동해 있었다.");
            Thread.Sleep(delay);
            Console.WriteLine("이곳에 온 이유도 가야 할 목적지도 모르지만 당신은 걷기 시작했다.");
            Thread.Sleep(delay);
            Console.WriteLine("발걸음 뗀 지 몇 분 채 지나지 않았지만, 숲은 금세 짙은 안개로 둘러싸였다.");
            Thread.Sleep(delay);
            Console.WriteLine("그리고 지금 당신 앞에 보이는 건 그저 양쪽의 갈림길뿐, 당신은 어디로 갈 것인가? (오른쪽 or 왼쪽)");
            Console.ReadLine();

            Console.WriteLine("COMING SOON...");
        }
    }
}
