using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class HashTable<TKey, TValue>
    {
        private const double fillFactor = 0.75;
        private int maxItemsAtCurrentSize;
        private int count;
        private HashTableArray<TKey, TValue> array;

        public HashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("Give a valid capacity!");
            }
            else
            {
                array = new HashTableArray<TKey, TValue>(initialCapacity);
            }
        }

        public HashTable()
        : this(1000)
        { }

        public void Add(TKey key, TValue value)
        {
            if (maxItemsAtCurrentSize == count)
            {
                HashTableArray<TKey, TValue> newArray = new HashTableArray<TKey, TValue>(maxItemsAtCurrentSize * 2);
                foreach (HashTableNodePair<TKey, TValue> item in array)
                {
                }
            }
            else
            {
            }
        }
    }
}