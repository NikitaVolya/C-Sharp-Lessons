using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5
{
    class Queue<T>
    {
        class Node<T>
        {
            public T Value;
            public Node<T> Last;
            public Node<T> Next;

            public Node(T value, Node<T> last = null, Node<T> next = null)
            {
                Value = value;
                Last = last;
                Next = next;
            }
        }

        Node<T> _head;
        Node<T> _tail;
        UInt32 _size;

        public Queue()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public void Put(T value)
        {
            Node<T> new_node = new Node<T>(value, null, _head);
            if (_head == null)
                _tail = new_node;
            else 
                _head.Last = new_node;
            _head = new_node;
            _size++;
        }
        public T Get()
        {
            if (_tail == null)
                throw new Exception();
            T value = _tail.Value;
            _tail = _tail.Last;
            if (_tail != null)
                _tail.Next = null;
            else 
                _head = null;
            return value;
        }

        public T Value()
        {
            if (_tail == null)
                throw new Exception();
            return _tail.Value;
        }

        public UInt32 Size { get => _size; }
        public bool Empty {  get => _head == null; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<float> stack = new Queue<float>();

            stack.Put(2.5f);
            stack.Put(10.0f);

            while (!stack.Empty)
                Console.WriteLine(stack.Get());
            Console.ReadLine();
        }
    }
}
