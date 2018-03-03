using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head
        {
            get; private set;
        }

        public LinkedListNode<T> Tail
        {
            get; private set;
        }

        #region Add

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            if (Count == 0)
            {
                Tail = node;
            }
            else
            {
                temp.Previous = Head;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Tail;
            Tail = node;

            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                temp.Next = Tail;
                Tail.Previous = temp;
            }
            Count++;
        }

        #endregion Add

        #region Remove

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;

                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
                Count--;
            }
        }

        #endregion Remove

        #region ICollection

        public int Count
        {
            get;
            private set;
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
                // arrayIndex++;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        // NOTE: ezt sztem meg lehetne valtoztatni :///
        public bool Remove(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            //Tail = current.Previous;
                            RemoveLast();
                        }
                        else
                        {
                            current.Next.Previous = current.Previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        #endregion ICollection
    }
}