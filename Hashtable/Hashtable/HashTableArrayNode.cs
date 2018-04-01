using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class HashTableArrayNode<TKey, TValue>
    {
        private LinkedList<HashTableNodePair<TKey, TValue>> list;

        public void Add(TKey key, TValue value)
        {
            if (list == null)
            {
                list = new LinkedList<HashTableNodePair<TKey, TValue>>();
            }
            else
            {
                foreach (HashTableNodePair<TKey, TValue> item in list)
                {
                    if (item.Key.Equals(key))
                    {
                        throw new ArgumentException("The collection already contains this key");
                    }
                }
            }
            list.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
        }

        public void Update(TKey key, TValue value)
        {
            bool updated = false;

            if (list != null)
            {
                foreach (HashTableNodePair<TKey, TValue> item in list)
                {
                    if (item.Key.Equals(key))
                    {
                        item.Value = value;
                        updated = true;
                        break;
                    }
                }
            }
            if (updated == false)
            {
                throw new ArgumentException("There's no matching key in the list");
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            bool found = false;
            value = default(TValue);
            if (list != null)
            {
                foreach (HashTableNodePair<TKey, TValue> item in list)
                {
                    if (item.Key.Equals(key))
                    {
                        found = true;
                        value = item.Value;
                    }
                }
            }

            return found;
        }

        public bool Remove(TKey key)
        {
            bool removed = false;

            if (list != null)
            {
                LinkedListNode<HashTableNodePair<TKey, TValue>> current = list.First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        list.Remove(current);
                        removed = true;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }

            return removed;
        }

        public void Clear()
        {
            if (list != null)
            {
                list.Clear();
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                if (list != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in list)
                    {
                        yield return node.Value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (list != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in list)
                    {
                        yield return node.Key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (list != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in list)
                    {
                        yield return node;
                    }
                }
            }
        }
    }
}