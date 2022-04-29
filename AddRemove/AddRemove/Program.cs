using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddRemove
{
    class Program
    {
        public class Node<T>
        {
            //конструктор
            public Node(T data)
            {
                Data = data;
            }

            public T Data { get; }
            //ссылка на следующий элемент
            public Node<T> Next { get; set; }

        }

        public class NodeList<T>: IEnumerable<T>
        {
            int count = 0;

            public Node<T> head { get; set; }

            public void Add(T data)
            {
                //Если список пустой 
                if (head == null)
                {
                    head = new Node<T>(data);
                    count++;
                    return;
                }

                else
                {
                    Node<T> current = head;

                    //Цикл перебора пока на достигнет конца
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    //Добавляем новый элемент в хвост
                    current.Next = new Node<T>(data);
                    count++;
                }
            }

            public void RemoveAt(int index)
            {
                if (index < 0 | index >= count)
                {
                    return;
                }

                Node<T> current = head;

                if (index == 0)
                {
                    head = current.Next;
                }

                //Цикл перебора пока на достигнет конца
                else
                {
                    for (int i = 0; i < index - 1; i++)
                        current = current.Next;

                    current.Next = current.Next.Next;
                }

            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
        }

        static void Main(string[] args)
        {

            NodeList<string> list = new NodeList<string>();
            NodeList<int> list2 = new NodeList<int>();

            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Add("f");

            list.RemoveAt(0);

            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            list2.RemoveAt(1);

            foreach (var item in list)
            {
                Console.WriteLine($"{item }");
            }

            Console.WriteLine();

            foreach (var item in list2)
            {
                Console.WriteLine($"{item }");
            }
            Console.ReadKey();
        }
    }
}
