using System;

namespace Models{
    public abstract class DBObject<T>{

        public T GetValue(string name){
            return (T)GetType().GetProperty(name).GetValue(this);
        }

        public void SetValue(string name, T value){
            GetType().GetProperty(name).SetValue(this, value);
        }
    }
}