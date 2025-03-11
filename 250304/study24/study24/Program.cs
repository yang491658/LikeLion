using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study24
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 배열과 컬렉션
            //// 배열
            //int[] numbers = { 1, 2, 3, 4, 5 };
            //foreach (var num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            //// 컬렉션 : 배열과 비슷, 동적으로 크기가 변하는 가변 길이 컬렉션
            //List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            //names.Add("Dave");
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //// 컬렉션 기능
            //// 추가
            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //// 접근
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(list[0]);
            //Console.WriteLine(list[1]);
            //// 변경
            //list.Insert(1, 100);
            //list[2] = 200;
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(list.Count);
            //// 제거
            //list.Remove(3);
            //foreach (int i in list)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(list.Count);

            //// Stack : First In Last Out
            //Stack stack = new Stack();
            //// 추가
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //// 접근 및 제거 : 가장 마지막 입력 -> 가장 먼저 출력
            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Peek()); // 접근
            //    Console.WriteLine(stack.Pop()); // 제거
            //}

            //// Queue : First In First Out
            //Queue queue = new Queue();
            //// 추가
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //// 접근 및 제거 : 가장 먼저 입력 -> 가장 먼저 출력
            //while (queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Peek()); // 접근
            //    Console.WriteLine(queue.Dequeue()); // 제거
            //}

            ////// 예시 : 조작키 입력
            ////Queue queue = new Queue();
            ////queue.Enqueue("→");
            ////queue.Enqueue("↓");
            ////queue.Enqueue("↘");
            ////queue.Enqueue("→");
            ////queue.Enqueue("주먹");
            ////while (queue.Count > 0)
            ////    Console.WriteLine(queue.Dequeue());
            ////Console.WriteLine(queue.Count);

            //// ArrayList
            //ArrayList arrayList = new ArrayList();
            //// 추가
            //arrayList.Add(1); // 정수
            //arrayList.Add("Hello"); // 문자열
            //arrayList.Add(3.14); // 실수
            //// 접근
            //Console.WriteLine("ArrayList 요소 : ");
            //foreach (var item in arrayList)
            //    Console.WriteLine(item);
            //// 제거
            //arrayList.Remove(1);
            //Console.WriteLine("\nArrayList 요소 제거 후 : ");
            //foreach (var item in arrayList)
            //    Console.WriteLine(item);

            //// Hashtable
            //// 키-값 쌍을 저장하는 클래스
            //// 키를 이용해 값을 빠르게 검색
            //Hashtable hashtable = new Hashtable();
            //// 추가 : 키-값 쌍
            //hashtable["Alice"] = 25;
            //hashtable["Bob"] = 30;
            //hashtable["포션"] = 20;
            //Console.WriteLine("Hashtable 요소 :");
            //foreach (DictionaryEntry entry in hashtable)
            //    Console.WriteLine($"Key : {entry.Key} , Value : {entry.Value}");
            //// 접근 : 특정 키 값
            //Console.WriteLine($"\nAlice의 나이 : {hashtable["Alice"]}\n");
            //// 제거
            //hashtable.Remove("Bob");
            //Console.WriteLine("Hashtable 요소 :");
            //foreach (DictionaryEntry entry in hashtable)
            //{
            //    Console.WriteLine($"Key : {entry.Key}, Value : {entry.Value}");
            //}
        }
    }
}
