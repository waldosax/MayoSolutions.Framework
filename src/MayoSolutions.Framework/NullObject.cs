using System.ComponentModel;

namespace MayoSolutions.Framework
{
    // https://stackoverflow.com/questions/4632945/dictionary-with-null-key
    public struct NullObject<T>
    {
        [DefaultValue(true)]
        private readonly bool _isNull; // Default property initializers are not supported for structs

        private NullObject(T item, bool isNull) : this()
        {
            this._isNull = isNull;
            this.Item = item;
        }

        public NullObject(T item) : this(item, item == null)
        {
        }

        public static NullObject<T> Null()
        {
            return new NullObject<T>();
        }

        public T Item { get; private set; }

        public bool IsNull()
        {
            return this._isNull;
        }

        public static implicit operator T(NullObject<T> nullObject)
        {
            return nullObject.Item;
        }

        public static implicit operator NullObject<T>(T item)
        {
            return new NullObject<T>(item);
        }

        public override string ToString()
        {
            return (Item != null) ? Item.ToString() : "NULL";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return this.IsNull();

            if (!(obj is NullObject<T>))
                return false;

            var no = (NullObject<T>)obj;

            if (this.IsNull())
                return no.IsNull();

            if (no.IsNull())
                return false;

            return this.Item.Equals(no.Item);
        }

        public override int GetHashCode()
        {
            if (this._isNull)
                return 0;

            // ReSharper disable once NonReadonlyMemberInGetHashCode
            var result = Item.GetHashCode();

            if (result >= 0)
                result++;

            return result;
        }
    }
}
