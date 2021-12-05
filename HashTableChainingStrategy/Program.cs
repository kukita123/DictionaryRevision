using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableChainingStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTableChaining hashTable = new MyHashTableChaining();

            //put method
            hashTable.Put(6, "A"); //1
            hashTable.Put(8, "B"); //3
            hashTable.Put(11, "C"); //1 
            //duplicate key:
            hashTable.Put(6, "A++");

            //get method
            Console.WriteLine(hashTable.Get(6));
            Console.WriteLine(hashTable.Get(10));

            //remove method:
            hashTable.Remove(6);
            hashTable.Remove(10);

            Console.ReadKey();

        }
    }
}
