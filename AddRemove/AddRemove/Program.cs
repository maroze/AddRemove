using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int value = rnd.Next(-1, 7);
            NodeList<string> list = new NodeList<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Add("f");
            list.RemoveAt(value);
            list.Output(x => Console.WriteLine(x));
            NodeList<int> list2 = new NodeList<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);
            list2.RemoveAt(value);
            list2.Output(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; }
        public Node<T> Next { get; set; }
    }
    public class NodeList<T>
    {
        public int count;
        public Node<T> head { get; set; }
        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(data);
            }
            count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 | index > count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node<T> current = this.head;
            object result = null;
            if (index == 0)
            {
                result = current.Data;
                this.head = current.Next;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;
                result = current.Next.Data;
                current.Next = current.Next.Next;
            }

        }
        public void Output(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }

        }
    }
}
