using System.Collections;

namespace IteratorExample;

public class BinaryTreeEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>
    where TKey : IComparable<TKey>
    where TValue : IComparable<TValue>
{

    public BinaryTreeEnumerator(TreeNode<TKey, TValue>? root)
    {
        _queue = new Queue<TreeNode<TKey, TValue>>();
        _root = root;
    }
    public bool MoveNext()
    {
        if (_queue.Count > 0)
        {
            TreeNode<TKey, TValue> tmp = _queue.Dequeue();

            if (tmp.Left is not null)
            {
                _queue.Enqueue(tmp.Left);
            }

            if (tmp.Right is not null)
            {
                _queue.Enqueue(tmp.Right);
            }
        }
        else
        {
            if (_root is not null)
            {
                _queue.Enqueue(_root);
            }
        }

        return _queue.Count > 0;
    }

    public void Reset()
    {
        _queue.Clear();
    }

    public KeyValuePair<TKey, TValue> Current => _queue.Peek().Pair;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        _queue.Clear();
    }

    private Queue<TreeNode<TKey, TValue>> _queue;
    private TreeNode<TKey, TValue>? _root;
}