namespace RimworldPlusPlus{
    struct Mut<T>{
        T variable;

        public T Variable{
            get{
                return variable;
            }
            set{
                variable = value;
            }
        }
        public Mut(T variable){
            this.variable = variable;
        }
    }
}