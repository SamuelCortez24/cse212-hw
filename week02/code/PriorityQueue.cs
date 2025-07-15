using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class PriorityItem
    {
        public string Value { get; }
        public int Priority { get; }
        public int InsertionIndex { get; }

        public PriorityItem(string value, int priority, int index)
        {
            Value = value;
            Priority = priority;
            InsertionIndex = index;
        }

        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }

    private List<PriorityItem> _queue = new();
    private int _insertionCounter = 0;

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless of priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority, _insertionCounter++);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var highest = _queue[0];
        int indexToRemove = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            var current = _queue[i];
            if (current.Priority > highest.Priority ||
                (current.Priority == highest.Priority && current.InsertionIndex < highest.InsertionIndex))
            {
                highest = current;
                indexToRemove = i;
            }
        }

        _queue.RemoveAt(indexToRemove);
        return highest.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
