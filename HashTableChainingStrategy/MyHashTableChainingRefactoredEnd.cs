using System;
using System.Collections.Generic;

namespace HashTableChainingStrategy
{
    class MyHashTableChainingRefactoredEnd
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
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }        

        public string Get(int key)
        {
            var entry = GetEntry(key);

            return (entry == null) ? null : entry.value;
        }
      
        public void Remove(int key)
        {
            var entry = GetEntry(key);

            if (entry == null)
                throw new Exception("Entry not found - wrong key");
            
            GetBucket(key).Remove(entry);
        }

        private Entry GetEntry(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];

            if (bucket != null)
            {
                foreach (var item in bucket)                
                    if (item.key == key)                    
                        return item;    
            }

            return null;
        }

        private LinkedList<Entry>GetBucket(int key)
        {
            return entries[Hash(key)];
        }

        private LinkedList<Entry>GetOrCreateBucket(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];

            if (bucket == null)
                entries[index] = new LinkedList<Entry>();

            return bucket;
        }

        private int Hash(int key)
        {
            return key % entries.Length;
        }
    }
}
