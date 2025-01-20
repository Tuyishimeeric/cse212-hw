public class PriorityQueue
{
    private List<(object item, int priority)> _queue = new List<(object, int)>();

    // Enqueue method that accepts items with priority
    public void Enqueue(object item, int priority)
    {
        _queue.Add((item, priority));
        _queue = _queue.OrderByDescending(i => i.priority).ToList();  // Sorting by priority
    }

    // Dequeue method that returns the item with the highest priority
    public object Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        var item = _queue[0].item;
        _queue.RemoveAt(0);
        return item;
    }

    // Check if the queue is empty
    public bool IsEmpty() => _queue.Count == 0;
}
