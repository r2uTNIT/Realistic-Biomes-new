using System;

namespace RimworldPlusPlus{
    interface IOption<T>{
        T Get();

        bool IsDefined();
    }
    class Some<T> : IOption<T>{
        public readonly T value;

        public Some(T value){
            this.value = value;
        }
        public T Get(){
            return value;
        }
        public bool IsDefined(){
            return true;
        }
    }
    class None<T> : IOption<T>{
        public T Get(){
            throw new Exception("Attempted to get an undefined value");
        }
        public bool IsDefined(){
            return false;
        }
    }
}