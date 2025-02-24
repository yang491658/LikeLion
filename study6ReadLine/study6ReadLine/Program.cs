using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion6ReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 사용자 입력을 문자열로 받기
            //Console.Write("이르을 입력하세요 : ");
            //string userName = Console.ReadLine(); // 사용자로부터 입력받기
            //Console.WriteLine($"안녕하세요, {userName}님!"); // 입력값 출력

            //// 문자열을 정수로 변환
            //Console.Write("나이를 입력하세요 : ");
            //string input = Console.ReadLine(); // 사용자로부터 입력받기
            //int age = int.Parse(input); // 문자열을 정수로 변환
            //Console.WriteLine($"내년에는 {age + 1}살이 되겠군요!"); // 변환된 값 사용
            //Console.WriteLine("내년에는 " + (age + 1) + "살이 되겠군요!");
            //Console.WriteLine("내년에는 {0}살이 되겠군요!", age + 1);

            // 중간과제
            Console.WriteLine("아래의 값들을 입력하세요.");
            Console.Write("루인 스킬 피해 : ");
            float stat1 = float.Parse(Console.ReadLine());
            Console.Write("카드 게이지 획득량 : ");
            float stat2 = float.Parse(Console.ReadLine());
            Console.Write("각성기 피해 : ");
            float stat3 = float.Parse(Console.ReadLine());
            Console.Write("최대 마나 : ");
            int stat4 = int.Parse(Console.ReadLine());
            Console.Write("전투 중 마나 획복량 : ");
            int stat5 = int.Parse(Console.ReadLine());
            Console.Write("비전투 중 마나 획복량 : ");
            int stat6 = int.Parse(Console.ReadLine());
            Console.Write("이동 속도 : ");
            float stat7 = float.Parse(Console.ReadLine());
            Console.Write("탈 것 속도 : ");
            float stat8 = float.Parse(Console.ReadLine());
            Console.Write("운반 속도 : ");
            float stat9 = float.Parse(Console.ReadLine());
            Console.Write("스킬 재사용 대기시간 감소 : ");
            float stat10 = float.Parse(Console.ReadLine());
            Console.WriteLine("\n========================================");
            Console.WriteLine($"루인 스킬 피해               : {stat1:F1}%");
            Console.WriteLine($"카드 게이지 획득량           : {stat2:F1}%");
            Console.WriteLine($"각성기 피해                  : {stat3:F1}%");
            Console.WriteLine($"최대 마나                    : {stat4}");
            Console.WriteLine($"전투 중 마나 획복량          : {stat5}");
            Console.WriteLine($"비전투 중 마나 획복량        : {stat6}");
            Console.WriteLine($"이동 속도                    : {stat7:F1}%");
            Console.WriteLine($"탈 것 속도                   : {stat8:F1}%");
            Console.WriteLine($"운반 속도                    : {stat9:F1}%");
            Console.WriteLine($"스킬 재사용 대기시간 감소    : {stat10:F1}%");
            Console.WriteLine("========================================");
        }
    }
}
