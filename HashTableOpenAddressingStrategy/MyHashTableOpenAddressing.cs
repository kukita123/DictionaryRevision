using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableOpenAddressingStrategy
{
    class MyHashTableOpenAddressing
    {
        class Entry
        {
            public int key { set; get; }
            public string value { set; get; }
            public Entry(int key, string data)
            {
                this.key = key;
                this.value = data;
            }
        }

        Entry[] table = new Entry[5];

        public MyHashTableOpenAddressing()
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = null;
            }
        }

        private bool CheckOpenSpace()//checks for open spaces in the table for insertion
        {
            bool isOpen = false;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null)
                {
                    isOpen = true;
                }
            }

            return isOpen;
        }

        public void Insert(int key, string data)
        {
            if (!CheckOpenSpace())//if no open spaces available
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }

            int hash = key % table.Length;
            //Linear probbing:
            while (table[hash] != null && table[hash].key != key)
            {
                hash = (hash + 1) % table.Length;
            }
            table[hash] = new Entry(key, data);
        }

        public string Retrieve(int key)
        {
            int hash = key % table.Length;

            while (table[hash] != null && table[hash].key != key)
            {
                hash = (hash + 1) % table.Length;
            }

            if (table[hash] == null)
            {
                return "nothing found!";
            }  
            
            return table[hash].value;            
        }

        public bool Remove(int key)
        {
            int hash = key % table.Length;

            while (table[hash] != null && table[hash].key != key)
            {
                hash = (hash + 1) % table.Length;
            }

            if (table[hash] == null)
            {
                return false;
            }
            else
            {
                table[hash] = null;
                return true;
            }
        }

        public void Print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null && i <= table.Length)//if we have null entries
                {
                    continue;//dont print them, continue looping
                }
                else
                {
                    Console.WriteLine("{0}", table[i].value);
                }
            }
        }

        public void QuadraticHashInsert(int key, string data)
        {
            //quadratic probing method
            if (!CheckOpenSpace())//if no open spaces available
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }

            int i = 0;
            int hash = key % table.Length;
            //quadratic probing:
            while (table[hash] != null && table[hash].key != key)
            {
                i++;
                hash = (hash + i * i) % table.Length;
            }

            if (table[hash] == null)
            {
                table[hash] = new Entry(key, data);
                return;
            }
        }

        public void DoubleHashInsert(int key, string data)
        {
            if (!CheckOpenSpace())//if no open spaces available
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }

            //double probing method
            int hashVal = Hash1(key);
            int stepSize = Hash2(key);

            while (table[hashVal] != null && table[hashVal].key != key)
            {
                hashVal = (hashVal + stepSize * Hash2(key)) % table.Length;
            }
            table[hashVal] = new Entry(key, data);
            return;
        }

        private int Hash1(int key)
        {
            return key % table.Length;
        }

        private int Hash2(int key)
        {
            //must be non-zero, less than array size, ideally odd prime
            return 3 - key % 3;
        }
    }
}
