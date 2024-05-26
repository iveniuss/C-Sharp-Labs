

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace MyCollection
{
    public class MyCollection<TKey, TValue> : IDictionary<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>> where TKey : ICloneable
                                                                                                                 where TValue : ICloneable
    {
        Point<TKey, TValue>?[] table;
        int count = 0;
        double fillRatio;
        bool isReadOnly = false;

        public int Capacity => table.Length;
        public int Count => count;

        public double FillRatio { get => fillRatio; }

        public ICollection<TKey> Keys
        {
            get => GetKeys();
        }

        public ICollection<TValue> Values
        {
            get => GetValues();
        }

        public bool IsReadOnly
        {
            get => isReadOnly;
            set => isReadOnly = value;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                bool isFound = TryGetValue(key, out value);
                if (!isFound)
                    throw new KeyNotFoundException();
                return value;
            }
            set
            {
                if (IsReadOnly)
                    throw new ArgumentException("Collection is read only");
                int index = FindItem(key);
                if (index == -1)
                    throw new KeyNotFoundException();
                Point<TKey, TValue> newPoint = new Point<TKey, TValue>(table[index].Key, value);
                table[index] = newPoint;
            }
        }

        public MyCollection(int size, double fillRatio = 0.72)
        {
            if (size <1)
                throw new ArgumentOutOfRangeException("size");
            table = new Point<TKey, TValue>[size];
            this.fillRatio = fillRatio;
        }

        public MyCollection()
        {
            table = new Point<TKey, TValue>[1];
            this.fillRatio = 0.72;
        }

        public MyCollection(MyCollection<TKey, TValue> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            table = new Point<TKey, TValue>[collection.Capacity];
            fillRatio = collection.fillRatio;
            foreach (KeyValuePair<TKey, TValue> pair in collection)
                Add((TKey)pair.Key.Clone(), (TValue)pair.Value.Clone());

        }

        List<TKey> GetKeys()
        {
            List<TKey> list = new List<TKey>();
            foreach (KeyValuePair<TKey, TValue> pair in this)
                list.Add(pair.Key);
            return list;
        }

        List<TValue> GetValues()
        {
            List<TValue> list = new List<TValue>();
            foreach (KeyValuePair<TKey, TValue> pair in this)
                list.Add(pair.Value);
            return list;
        }

        int GetIndex(Point<TKey, TValue> point)
        {
            return Math.Abs(point.GetHashCode()) % Capacity;
        }

        int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Capacity;
        }

        void AddData(Point<TKey, TValue> point)
        {

            int index = GetIndex(point);
            int current = index;
            while (current < table.Length)
            {
                if (table[current] == null)
                {
                    table[current] = point;
                    ++count;
                    return;
                }
                current++;
            }
            current = 0;
            while (current < index)
            {
                if (table[current] == null)
                {
                    table[current] = point;
                    ++count;
                    return;
                }
                current++;
            }
        }

        int FindItem(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            int index = GetIndex(key);
            if (table[index] == null)
                return -1;
            if (table[index].Key.Equals(key))
                return index;
            else
            {
                int current = index;
                while (current < table.Length)
                {
                    if (table[current] != null && table[current].Key.Equals(key))
                        return current;
                    current++;
                }
                current = 0;
                while (current < index)
                {
                    while (current < table.Length)
                    {
                        if (table[current] != null && table[current].Key.Equals(key))
                            return current;
                        current++;
                    }
                }
            }
            return -1;
        }

        int FindIndex(int index)
        {
            for (int current = 0; current < table.Length; current++)
            {
                if (table[current]!= null &&
                    GetIndex(table[current].Key) == index)
                    return current;
            }
            return -1;
        }

        public bool ContainsKey(TKey key)
        {
            return FindItem(key)>=0;
        }

        public bool Remove(TKey key)
        {
            if (isReadOnly)
                throw new ArgumentException("Collection is read only");
            int index = FindItem(key);
            if (index < 0)
                return false;
            count--;
            table[index] = null;
            int sameItem = FindIndex(index);
            if (sameItem == -1)
                return true;
            table[index] = table[sameItem];
            table[sameItem] = null;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (isReadOnly)
                throw new ArgumentException("Collection is read only");
            return Remove(item.Key);
        }

        public void Print()
        {
            foreach (KeyValuePair<TKey, TValue> pair in this)
                Console.WriteLine($"Key: {pair.Key}\n" +
                                  $"Value: {pair.Value}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Кол-во: {Count}");
            Console.WriteLine($"Емкость: {Capacity}");
            Console.ResetColor();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (isReadOnly)
                throw new ArgumentException("Collection is read only");
            if (Contains(item))
                throw new ArgumentException("item already exists");
            Point<TKey, TValue> point = new Point<TKey, TValue>(item);
            if ((double)(Count+1)/Capacity > fillRatio || Count==Capacity)
            {
                Point<TKey, TValue>[] temp = (Point<TKey, TValue>[])table.Clone();
                table = new Point<TKey, TValue>[temp.Length*2];
                count = 0;
                for (int i = 0; i < temp.Length; i++)
                    if (temp[i] != null)
                        AddData(temp[i]);
            }
            AddData(point);
        }

        public void Add(TKey key, TValue value)
        {
            if (isReadOnly)
                throw new ArgumentException("Collection is read only");
            KeyValuePair<TKey, TValue> item = new KeyValuePair<TKey, TValue>(key, value);
            Add(item);
        }

        public bool TryAdd(TKey key, TValue value)
        {
            try
            {
                Add(key, value);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int index = FindItem(key);
            if (index < 0)
            {
                value = default;
                return false;
            }
            value = table[index].Value;
            return true;
        }

        public void Clear()
        {
            if (isReadOnly)
                throw new ArgumentException("Collection is read only");
            for (int i = 0; i < table.Length; i++)
                table[i] = null;
            count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return FindItem(item.Key) >= 0;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("index");
            if (count > array.Length - arrayIndex)
                throw new ArgumentException("Not enough place in array");
            int index = arrayIndex;
            for (int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    TKey key = (TKey)table[i].Key.Clone();
                    TValue value = (TValue)table[i].Value.Clone();
                    array[index++] = new KeyValuePair<TKey, TValue>(key, value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int index = 0;
            while (index < Capacity)
            {
                if (table[index] != null)
                    yield return table[index].Pair;
                index++;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
