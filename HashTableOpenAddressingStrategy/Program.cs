using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableOpenAddressingStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTableOpenAddressing hashTable1 = new MyHashTableOpenAddressing();
            hashTable1.Insert(6, "A");
            hashTable1.Insert(8, "B");
            hashTable1.Insert(11, "C");

            hashTable1.Print();

            MyHashTableOpenAddressing hashTable2 = new MyHashTableOpenAddressing();
            hashTable2.QuadraticHashInsert(6, "A");
            hashTable2.QuadraticHashInsert(8, "B");
            hashTable2.QuadraticHashInsert(11, "C");

            hashTable2.Print();

            MyHashTableOpenAddressing hashTable3 = new MyHashTableOpenAddressing();
            hashTable3.DoubleHashInsert(6, "A");
            hashTable3.DoubleHashInsert(8, "B");
            hashTable3.DoubleHashInsert(11, "C");

            hashTable3.Print();

            Console.ReadKey();
        }
    }
}
