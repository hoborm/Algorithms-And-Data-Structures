using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Priority_Queue
{
    internal class Priority_Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (items.Count == 0)
            {
                items.AddLast(item);
            }
            else
            {
                var current = items.First;
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    items.AddLast(item);
                }
                else
                {
                    items.AddBefore(current, item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }
    }
}