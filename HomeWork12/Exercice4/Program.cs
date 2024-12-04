using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice4
{
    class Stack<T>
    {
        class Node<T>
        {
            public T Value;
            public Node<T> Next;

            public Node(T value, Node<T> next = null)
            {
                Value = value;
                Next = next;
            }
        }

        Node<T> _head;
        UInt32 _size;

        public Stack() 
        {
            _head = null;
            _size = 0;
        }

        public UInt32 Size { get => _size; }
        public bool Empty { get => _head == null; }

        public T Get()
        {
            if (_head == null)
                throw new Exception();

            T value = _head.Value;
            _head = _head.Next;
            _size--;
            return value;
        }
        public void Put(T value)
        {
            Node<T> new_node = new Node<T>(value, _head);
            _head = new_node;
            _size++;
        }
        public T Value()
        {
            if (_head == null)
                throw new Exception();
            return _head.Value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<float> stack = new Stack<float>();

            stack.Put(2.5f);
            stack.Put(10.0f);

            while (!stack.Empty)
                Console.WriteLine(stack.Get());
            Console.ReadLine();
        }
    }
}
