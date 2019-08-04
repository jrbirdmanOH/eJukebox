using System;

namespace Domain
{
    public abstract class DomainObject : PersistentObject
    {
        public const int DefaultId = -1;

        protected DomainObject()
        {
            //Becuase some tables have a row with Id 0, we need to use -1 as the new object value
            Id = DefaultId;
        }
        public virtual int Id { get; private set; }

        // TODO (Review) This method seems akward, consider removing
        public virtual Type GetTypeUnproxied()
        {
            var type = GetType();
            if (type.Namespace == "Castle.Proxies")
                type = type.BaseType;
            return type;
        }

        public virtual T Unproxy<T>()
        {
            return (T)(object)this;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainObject;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null || !GetType().Equals(compareTo.GetTypeUnproxied()))
                return false;

            return HasSameNonDefaultIdAs(compareTo);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Returns true if self and the provided entity have the same Id values
        /// and the Ids are not of the default Id value
        /// </summary>
        private bool HasSameNonDefaultIdAs(DomainObject compareTo)
        {
            return Id != -1 && Id == compareTo.Id;
        }

        public virtual bool IsNew { get { return Id == DefaultId; } }

        protected virtual T Clone<T>() where T : DomainObject
        {
            var clone = (T)MemberwiseClone();
            clone.Id = DefaultId;
            return clone;
        }
    }
}