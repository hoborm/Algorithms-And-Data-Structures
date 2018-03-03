using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Queue_Array
{
    internal class Queue<T> : IEnumerable<T>
    {
        private T[] array = new T[0];
        private int size = 0, head = 0, tail = 0;

        public void Enqueue(T item)
        {
            if (array.Length == size)
            {
                int newlength = (size == 0) ? 4 : size * 2;
                T[] newArray = new T[newlength];

                if (size > 0)
                {
                    int db = 0;
                    if (tail < head)
                    {
                        for (int i = head; i < array.Length; i++)
                        {
                            newArray[db] = array[i];
                            db++;
                        }
                        for (int i = 0; i < tail; i++)
                        {
                            newArray[db] = array[i];
                            db++;
                        }
                    }
                    else
                    {
                        for (int i = head; i < tail; i++)
                        {
                            newArray[db] = array[i];
                        }
                    }
                    head = 0;
                    tail = db - 1;
                }
                else
                {
                    head = 0;
                    tail = -1;
                }
                array = newArray;
            }
            if (array.Length - 1 == tail)
            {
                tail = 0;
            }
            else
            {
                tail++;
            }
            array[tail] = item;
            size++;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new System.InvalidOperationException("The queue is empty!");
            }
            T value = array[head];
            if (head == array.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }
            size--;
            return value;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new System.InvalidOperationException("The queue is empty!");
            }
            return array[head];
        }

        public int Count
        {
            get { return size; }
        }

        public void Clear()
        {
            size = 0;
            head = 0;
            tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (tail < head)
            {
                for (int i = head; i < array.Length; i++)
                {
                    yield return array[i];
                }
                for (int i = 0; i <= tail; i++)
                {
                    yield return array[i];
                }
            }
            else
            {
                for (int i = head; i <= tail; i++)
                {
                    yield return array[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}