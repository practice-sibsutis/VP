using System.Collections;

namespace IteratorExample;

public class BinaryTree<TKey,  TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey : IComparable<TKey> 
    where TValue : IComparable<TValue>
{
    public void Add(TKey key, TValue value)
    {
        if (_root is not null)
        {
            TreeNode<TKey, TValue>? next = _root;
            TreeNode<TKey, TValue> tmp;

            do
            {
                tmp = next;
                if (tmp.Pair.Key.CompareTo(key) < 0)
                {
                    next = tmp.Right;
                }
                else
                {
                    next = tmp.Left;
                }
            } while (next is not null);

            if (tmp.Pair.Key.CompareTo(key) < 0)
            {
                tmp.Right = new TreeNode<TKey, TValue>(key, value);
            }
            else
            {
                tmp.Left = new TreeNode<TKey, TValue>(key, value);
            }
        }
        else
        {
            _root = new TreeNode<TKey, TValue>(key, value);
        }
    }
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return new BinaryTreeEnumerator<TKey, TValue>(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private TreeNode<TKey, TValue>? _root = null;
}