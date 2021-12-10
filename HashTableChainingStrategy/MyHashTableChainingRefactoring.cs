using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//refactorring -> starts at line 80
namespace HashTableChainingStrategy
{
    class MyHashTableChainingRefactoring
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
        
        //refactor 5:
        //we need another method to find and if it doesn't exists to CREATE (initialize) the bucket -> the GetOrCreateBucket(int key)
        // GoTo Line -> 158
        public void Put(int key, string value)
        {
            //int index = Hash(key);
            //if (entries[index] == null)
            //{
            //    entries[index] = new LinkedList<Entry>();
            //}

            //var bucket = entries[index];
            //foreach (var item in bucket)
            //{
            //    if (item.key == key)
            //    {
            //        item.value = value;
            //        return;
            //    }
            //}
            //var entry = new Entry(key, value);
            //bucket.AddLast(entry);

            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        //refactor 4:
        public string Get(int key)
        {
            //int index = Hash(key);
            //var bucket = entries[index];
            //if (bucket != null)
            //{
            //    foreach (var item in bucket)
            //    {
            //        if (item.key == key)
            //            return item.value;
            //    }
            //}
            //return null;
            var entry = GetEntry(key);
            if (entry == null)
                return null;
            return entry.value;

            //or simply: return (entry == null) ? null : entry.value;
        }
        // 1) Get and Remove - similar -> in both of them we are searching for an entry -> ...if (item.key == key) ...
        // so we create a method GetEntry() and reuse it in Get ang Remove -> GoTo Line 109
        public void Remove(int key)
        {
            //int index = Hash(key);
            //var bucket = entries[index];

            //if (bucket == null)
            //    throw new Exception("Entry not found - wrong key");

            //foreach (var item in bucket)
            //{
            //    if(item.key == key)
            //    {
            //        bucket.Remove(item);
            //        return;
            //    }
            //}
            //throw new Exception("Entry not found - wrong key");

            //refactor3:
            var entry = GetEntry(key);
            if (entry == null)
                throw new Exception("Entry not found - wrong key");
            // otherwise here we need to calculate the bucket, so we goes to another similar lines
            // and we need to create GetBucket method -> GoTo Line 145
            GetBucket(key).Remove(entry);
        }

        //refactor 1:
        private Entry GetEntry(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];

            /*
            if (bucket == null)
                return null;

            foreach (var item in bucket)
            {
                if (item.key == key)
                {
                    return item;
                }
            }

            return null;
            */

            //refactor 2:
            //we nave two return null; it's looks bad -> so we reverce the condition:
            //instead if(bucket == null) we use if(bucket!=null):

            if (bucket != null)
            {
                foreach (var item in bucket)                
                    if (item.key == key)                    
                        return item;    
            }

            return null;
        }
        // -> GoTo Line 101

        private LinkedList<Entry>GetBucket(int key)
        {
            int index = Hash(key);
            var bucket = entries[index];

            return bucket;

            //or better simply:
            //return entries[Hash(key)];
        }

        //Then this method - GetBucket could be reused in GetEntry -> GoTo Line 112 !!! ToDo... !!!!
        
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
