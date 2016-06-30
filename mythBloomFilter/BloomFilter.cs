using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mythBloomFilter
{
    public class BloomFilter
    {
        private byte[] _bytes;
        public BloomFilter(int maxnum)
        {
            _bytes = new byte[maxnum];
        }
        public void Add(string url)
        {

        }
        int RSHash(string str)
        {
            int b = 378551;
            int a = 63689;
            int hash = 0;
            int i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash = hash * a + str[i];
                a = a * b;
            }

            return hash % _bytes.Length;
        }
        int JSHash(string str)
        {
            int hash = 1315423911;
            int i = 0;

            for (i = 0; i < str.Length; i++)
            {
                hash ^= ((hash << 5) + str[i] + (hash >> 2));
            }

            return hash % _bytes.Length;
        }
    }
}
