using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    public class TreeNode<TKey, TValue>(TKey key, TValue value) where TKey : IComparable<TKey>
    {
        public TreeNode<TKey, TValue>? Left { get; set; } = null;
        public TreeNode<TKey, TValue>? Right { get; set; } = null;
        public KeyValuePair<TKey, TValue> Pair => _pair;

        private KeyValuePair<TKey, TValue> _pair = new KeyValuePair<TKey, TValue>(key, value);
    }
}
