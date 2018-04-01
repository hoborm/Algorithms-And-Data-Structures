using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class HashTableNodePair<TKey, TValue>
    {
        public TKey Key
        {
            get; set;
        }

        public TValue Value
        {
            get; set;
        }

        public HashTableNodePair(TKey key, TValue value)
        {
            this.Value = value;
            this.Key = key;
        }
    }
}