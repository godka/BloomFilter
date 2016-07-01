using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mythBloomFilter
{
    public class CountBloomFilter
    {
        private int[] _bytes;
        private int _k;
        public CountBloomFilter(int m, int k)
        {
            _bytes = new int[m];
            _k = k;
        }
        int RSHash(String str)
        {
            int b = 378551;
            int a = 63689;
            int hash = 0;

            for (int i = 0; i < str.Length; i++)
            {
                hash = hash * a + str[i];
                a = a * b;
            }
            return (hash & 0x7FFFFFFF);
        }
        public void Add(string url)
        {
            var hash = RSHash(url);
            Random rand = new Random(hash);
            for (int i = 0; i < _k; i++)
            {
                _bytes[rand.Next() % _bytes.Length]++;
            }
        }
        public void Del(string url)
        {
            if (Contains(url))
            {
                var hash = RSHash(url);
                Random rand = new Random(hash);
                for (int i = 0; i < _k; i++)
                {
                    var tmp = _bytes[rand.Next() % _bytes.Length] - 1;
                    if (tmp < 0)
                        tmp = 0;
                    _bytes[rand.Next() % _bytes.Length] = tmp;
                }

            }
        }
        public bool Contains(string url)
        {
            var hash = RSHash(url);
            Random rand = new Random(hash);
            for (int i = 0; i < _k; i++)
            {
                if (_bytes[rand.Next() % _bytes.Length] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
