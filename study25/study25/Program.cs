using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study25
{
    class Program
    {
        //// 제네릭 클래스 <T> : 특정 타입에 종속되지 않는 범용 클래스
        //class Cup<T>
        //{
        //    public T Content { get; set; }
        //}

        //// 커스텀 컬렉션
        //class SimpleCollection : IEnumerable<int>
        //{
        //    private int[] data = { 1, 2, 3, 4, 5 };

        //    public IEnumerator<int> GetEnumerator()
        //    {
        //        foreach (var item in data)
        //        {
        //            yield return item;
        //        }
        //    }

        //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //}

        static void Main(string[] args)
        {
            //// 커스텀 컬렉션
            //var collection = new SimpleCollection();
            //foreach (var i in collection)
            //    Console.WriteLine(i);

            //// 제네릭 클래스 <T> : 특정 타입에 종속되지 않는 범용 클래스
            //Cup<string> cupOfString = new Cup<string> { Content = "Coffee" };
            //Cup<int> cupOfInt = new Cup<int> { Content = 42 };
            //Console.WriteLine($"cupOfString: {cupOfString.Content}");
            //Console.WriteLine($"cupOfInt: {cupOfInt.Content}");

            //// Stack 제네릭 클래스
            //Stack<int> stack = new Stack<int>();
            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);
            //while (stack.Count > 0)
            //    Console.WriteLine(stack.Pop());

            //// List <T> 제네릭 클래스
            //// 리스트
            //List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            //names.Add("Dave");
            //foreach (var name in names)
            //    Console.WriteLine(name);

            //// IEnumerable 클래스 : 순회, 반복할수 있는 인터페이스
            //// 컬렉션을 직접 제어하며 순회
            //// foreach 없이 컬렉션 순회
            //// LINQ나 커스텀 컬렉션을 만들때 유요
            //ArrayList list = new ArrayList { "Apple", "Banana", "Cherry" };
            //IEnumerator enumerator = list.GetEnumerator(); // 열거자 가져오기
            //while (enumerator.MoveNext())
            //    Console.WriteLine(enumerator.Current); // 현재 요소 출력

            //// Dictionary<T, T> 제네릭 클래스
            //Dictionary<string, int> ages = new Dictionary<string, int>();
            //ages["금도끼"] = 10;
            //ages["은도끼"] = 5;
            //ages["돌도끼"] = 1;
            //foreach (var pair in ages)
            //    Console.WriteLine($"{pair.Key} : {pair.Value}");

            //// null : 참조 형식은 null을 가질 수 있으며, 값 형식은 기본적으로 null 불가능
            //// 참조 형식 null
            //string str = null;
            //if (str == null)
            //    Console.WriteLine("str is null");

            //// null 가능 형식: Nullable〈T〉 형식
            //// 값 형식 null
            //int? nullableInt = null;
            //Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No Value");
            //nullableInt = 10;
            //Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No Value");

            //// 관련 연산자 
            //// ?? : null인 경우 대체값 제공
            //string str = null;
            //Console.WriteLine(str ?? "DefaultValue"); // null -> 출력 :DefaultValue
            //// 위와 동일한 로직
            //if (str != null) Console.WriteLine(str); else Console.WriteLine("DefaultValue");
            //// ?. : null 안전 접근
            ////str = "Hello";
            //Console.WriteLine(str?.Length); // null -> 출력 : (공백)
            //// 위와 동일한 로직
            //if (str != null) Console.WriteLine(str.Length);

            // Linq (Language Integrated Query)
            // Linq를사용해 컬렉션을 쿼리할 수 있음 , 확장메서드 형태로 제공
            int[] numbers = { 1, 2, 3, 4, 5 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            foreach (var num in evenNumbers)
                Console.WriteLine(num);
        }
    }
}
