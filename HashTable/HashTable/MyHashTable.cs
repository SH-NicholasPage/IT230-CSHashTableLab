/*
 * Name: [YOUR NAME HERE]
 * South Hills Username: [YOUR SOUTH HILLS USERNAME HERE]
 */
// Remember to put your name and SH username above

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable;

public class MyHashTable<TKey, TValue>
    : IEnumerable<DictionaryEntry>
{
    // Using an unsigned integer here to mimic std::size_t
    private const uint DEFAULT_CAPACITY = 16;
    private List<KeyValuePair<TKey, TValue>>[] buckets;

    public int Count { get; private set; } = 0; // <- Should increase when adding a new key-value pair
    public int Buckets => buckets.Length; // <- Should return the number of buckets
    
    public IEnumerable<TKey> Keys
    {
        get
        {
            // TODO: Implement this method
            return [];
        }
    }
    
    public IEnumerable<TValue> Values
    {
        get
        {
            // TODO: Implement this method
            return [];
        }
    }

    public TValue this[TKey key]
    {
        get
        {
            // TODO: Implement this method
            return default;
        }
    }

    // TODO: Implement a default constructor

    // TODO: Implement a constructor that takes a capacity

    /// <summary>
    /// Computes the bucket index for the specified key.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type of the key used in the hash table.
    /// </typeparam>
    /// <param name="key">
    /// The key to compute a hash index for.
    /// </param>
    /// <returns>
    /// A non-negative index within the range of the buckets array.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="key"/> is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method obtains the hash code of the provided key and then ensures it maps
    /// to a valid bucket index. The cast to <see cref="uint"/> guarantees that even
    /// if the hash code is negative (including <see cref="int.MinValue"/>), the
    /// resulting value will be non-negative before taking the modulo. This avoids
    /// issues with <see cref="Math.Abs(int)"/> where <see cref="int.MinValue"/> cannot
    /// be represented as a positive <see cref="int"/>.
    /// </remarks>
    private int GetHashIndex(TKey key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));

        int hashCode = key.GetHashCode();
        return (int)((uint)hashCode % (uint)buckets.Length);
    }

    public void Add(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }
    
    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();
       
        // TODO: Implement this method
        // This method should use StringBuilder rather than string concatenation
        //  to avoid creating unnecessary garbage in the heap.
        
        return sb.ToString();
    }

    public void Clear()
    {
        buckets = new List<KeyValuePair<TKey, TValue>>[buckets.Length];
        // GC will collect the old buckets
        Count = 0;
    }
    
    #region IEnumerable implementation
    public IEnumerator<DictionaryEntry> GetEnumerator()
    {
        foreach (List<KeyValuePair<TKey, TValue>> bucket in buckets)
        {
            foreach (KeyValuePair<TKey, TValue> kvp in bucket)
            {
                yield return new DictionaryEntry(kvp.Key!, kvp.Value!);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion
}

