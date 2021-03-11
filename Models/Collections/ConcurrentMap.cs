using System;
using System.Collections.Concurrent;

namespace Models.Collections
{
    public class ConcurrentMap<T1, T2>
    {
        private ConcurrentDictionary<T1, T2> dict1;
        private ConcurrentDictionary<T2, T1> dict2;

        public ConcurrentMap()
        {
            dict1 = new ConcurrentDictionary<T1, T2>();
            dict2 = new ConcurrentDictionary<T2, T1>();
        }

        public T2 this[T1 val]
        {
            get => dict1[val];
            set => AddOrUpdate(val, value);
        }

        public T1 this[T2 val]
        {
            get => dict2[val];
            set => AddOrUpdate(val, value);
        }
        public void AddOrUpdate(T1 val1, T2 val2)
        {
            dict1[val1] = val2;
            dict2[val2] = val1;
        }

        public void AddOrUpdate(T2 val2, T1 val1)
        {
            dict1[val1] = val2;
            dict2[val2] = val1;
        }

        public bool Contains(T1 value){
            return dict1.ContainsKey(value);
        }

        public bool Contains(T2 value){
            return dict2.ContainsKey(value);
        }
    }
}