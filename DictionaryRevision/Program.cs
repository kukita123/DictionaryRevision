using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRevision
{
    class Person
    {
        public string name;
        public int age;
    }

    class Program
    {
        //ex1 - Find First Non-repeating Character In A String
        //"a green apple"
        //key value
        // a -> 2
        //' '-> 2
        // g -> 1
        // r -> 1
        // e -> 3
        // n -> 1
        // p -> 2
        // l -> 1

        static char FirstNonRepSymbol(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            input = input.ToLower();

            foreach (var ch in input.ToCharArray())
            {
                if (map.ContainsKey(ch))
                    map[ch]++;
                else
                    map.Add(ch, 1);                
            }

            //foreach (var item in map)
            //{
            //    Console.WriteLine(item);
            //}

            foreach (var item in map)
            {
                if (item.Value == 1)
                    return item.Key;                
            }

            return '\0';
        } 

        //first repeated character using Dictionary
        static char FirstRepSymbol(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            input = input.ToLower();

            foreach (var ch in input.ToCharArray())
            {
                if (map.ContainsKey(ch))
                    return ch;
                else
                    map.Add(ch, 1);
            }

            return '\0';
        } 
        
        //first repeated character using HashSet:
        static char FirstRepChar_Set(string input)
        {
            HashSet<char> set = new HashSet<char>();

            input = input.ToLower();

            foreach (var ch in input.ToCharArray())
            {
                if (set.Contains(ch))
                    return ch;

                set.Add(ch);
            }

            return '\0';
        }
        
        

        static int GetHash(string key)
        {
            int hash = 0;
            foreach (var ch in key.ToCharArray())
            {
                hash += (int)ch;
            }
            return hash;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FirstNonRepSymbol("A green apple"));

            Console.WriteLine(FirstRepSymbol("A green apple"));

            Console.WriteLine(FirstRepChar_Set("A green apple"));

            Console.WriteLine(GetHash("Mariana") % 8);
            Console.WriteLine(GetHash("Svetlio") % 8);
            Console.WriteLine(GetHash("Zdravka") % 8);

            Person man = new Person();
            man.name = "Svetlio";
            man.age = 33;

            Person woman = new Person();
            woman.name = "Mariana";
            woman.age = 52;


            Console.WriteLine(man.GetHashCode());
            Console.WriteLine(woman.GetHashCode());
            //остатък от делението на хеш-кода на ключа на броя елементи в масива - О(1)

            Console.ReadKey();
        }
    }
}/*



 */
