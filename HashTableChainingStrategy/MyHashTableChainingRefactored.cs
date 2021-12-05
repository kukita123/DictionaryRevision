using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableChainingStrategy
{
    class MyHashTableChainingRefactored
    { 
        private class Entry
        {
            public int key { get; set; }
            public string value { get; set; }

            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }            
        }

        private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

        public void Put(int key, string value)
        {
            //here we need a hash function - we need a method int Hash(key) -> implementation is down
            int index = Hash(key);
            if (entries[index] == null)
            {
                entries[index] = new LinkedList<Entry>();
            }

            //var entry = new Entry(key, value);
            //entries[index].AddLast(entry);  
                                                //it works, if there is not an entry with this key
                                                //what if we have a duplicate key? - we will have two values with the same key
                                                //so we need to iterate the LinkedList entries[index] and update the value at the key
                                                //it's better to store the entire LinkedList entries[index] in a variable, let's call it bucket
            var bucket = entries[index];
            foreach (var item in bucket)
            {
                if (item.key == key)
                {
                    item.value = value;
                    return;
                }
            }
            var entry = new Entry(key, value);
            bucket.AddLast(entry);
        }

        public string Get(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];
            if (bucket != null)
            {
                foreach (var item in bucket)
                {
                    if (item.key == key)
                        return item.value;
                }
            }
            return null;
        }

        public void Remove(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];

            if (bucket == null)
                throw new Exception("Entry not found - wrong key");

            foreach (var item in bucket)
            {
                if(item.key == key)
                {
                    bucket.Remove(item);
                    return;
                }
            }
            throw new Exception("Entry not found - wrong key");
        }

        private int Hash(int key)
        {
            return key % entries.Length;
        }
    }
}
