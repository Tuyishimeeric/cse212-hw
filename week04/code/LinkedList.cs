using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
      Node newNode = new (value);
      if(_tail is null)
      {
        _tail = newNode;
        _head = newNode;
      } 
      else
      {
       newNode.Prev = _tail;   // Set the previous node of the new node to the current tail
        _tail.Next = newNode;    // Set the current tail's next node to the new node
        _tail = newNode;  // TODO Problem 1
    }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
         if (_tail == null) return; // If the list is empty, do nothing.

    if (_head == _tail)
    {
        // The list has only one node.
        _head = null;
        _tail = null;
    }
    else
    {
        // There is more than one node.
        _tail = _tail.Prev; // Move the tail pointer to the second-to-last node.
        _tail.Next = null; // Disconnect the old last node (previous tail).
    }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
       // Search for the node to remove.
    Node? curr = _head;
    while (curr is not null)
    {
        if (curr.Data == value)
        {
            // If node is the head node
            if (curr == _head)
            {
                RemoveHead(); // Use RemoveHead method to handle removal
            }
            // If node is the tail node
            else if (curr == _tail)
            {
                RemoveTail(); // Use RemoveTail method to handle removal
            }
            else
            {
                // If node is in the middle of the list
                curr.Prev!.Next = curr.Next; // Bypass the current node in the prev node
                curr.Next!.Prev = curr.Prev; // Bypass the current node in the next node
            }
            return; // Exit after removing the first occurrence
        }

        curr = curr.Next; // Move to the next node
    } // TODO Problem 3
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
       Node? curr = _head;
    while (curr is not null)
    {
        if (curr.Data == oldValue)
        {
            curr.Data = newValue; // Replace the old value with the new value
        }

        curr = curr.Next; // Move to the next node
    } // TODO Problem 4
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse
    {
        get
        {
            if (_tail == null) yield break; // If the list is empty, return an empty sequence

            var curr = _tail; // Start from the tail of the list
            while (curr != null)
            {
                yield return curr.Data; // Yield the current node's data
                curr = curr.Prev; // Move to the previous node
            }
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}