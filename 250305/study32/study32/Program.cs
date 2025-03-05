using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study32
{
    // Base 클래스 : 부모 클래스 호출
    class Parent
    {
        public virtual void ShowMessage()
        {
            Console.WriteLine("부모 클래스의 메시지");
        }
    }

    class Child : Parent
    {
        public override void ShowMessage()
        {
            Console.WriteLine("자식 클래스의 메시지");
            base.ShowMessage(); // 부모 함수 실행
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            child.ShowMessage();
        }
    }
}
