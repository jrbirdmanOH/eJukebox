using System;

namespace Data.Framework
{
    public abstract class Parameter
    {
        public abstract Type Type { get; }
    }

    public class Parameter<T> : Parameter
    {
        public T Value { get; private set; }

        public Parameter(T value)
        {
            Value = value;
        }

        public override Type Type
        {
            get { return typeof (T); }
        }
    }
}