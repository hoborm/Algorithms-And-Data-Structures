using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Stack
{
    internal class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public void Push(T item)
        {
            list.AddFirst(item);
        }

        public T Pop()
        {
            if (list.Count != 0)
            {
                T value;
                value = list.First.Value;
                list.RemoveFirst();
                return value;
            }
            else
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }

        public T Peek()
        {
            if (list.Count != 0)
            {
                return list.First();
            }
            else
            {
                throw new InvalidOperationException("The list is empty!");
            }
        }

        public int Count()
        {
            return list.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}