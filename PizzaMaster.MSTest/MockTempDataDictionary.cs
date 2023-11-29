using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest
{
    public class MockTempDataDictionary : ITempDataDictionary
    {
        public object this[string key]
        {
            get => null;
            set { }
        }

        public ICollection<string> Keys => new List<string>();

        public ICollection<object> Values => new List<object>();

        public int Count => 0;

        public bool IsReadOnly => false;

        public void Add(string key, object value) { }

        public void Clear() { }

        public bool ContainsKey(string key) => false;

        public void Load() { }

        public void Keep() { }

        public void Keep(string key) { }

        public void Peek() { }

        public bool Remove(string key) => false;

        public void Save() { }

        public bool TryGetValue(string key, out object value)
        {
            value = null;
            return false;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => new List<KeyValuePair<string, object>>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public object? Peek(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object?> item)
        {
            throw new NotImplementedException();
        }
    }
}
