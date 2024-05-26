

namespace MyCollection
{
    public class Point<TKey,TValue> where TKey: ICloneable
                                    where TValue : ICloneable
    {
        KeyValuePair<TKey, TValue> pair;

        public TKey Key
        {
            get => pair.Key;
        }

        public TValue Value
        {
            get => pair.Value;
        }

        public KeyValuePair<TKey,TValue> Pair
        {
            get => pair;
        }

        public Point(TKey key, TValue value)
        {
            pair = new KeyValuePair<TKey, TValue>(key, value);
        }

        public Point(KeyValuePair<TKey, TValue> pair)
        {
            this.pair=pair;
        }

        public override string ToString()
        {
            return $"Key: {Key}\nValue: {Value}";
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
