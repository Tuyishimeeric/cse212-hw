/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue. Thus,
/// each person stays in the queue and is given turns. When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given. If the turns is 0 or
/// less than they will stay in the queue forever. If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();  // Use Queue for proper rotation

    public int Length => _people.Count;  // Property to get the current length of the queue

    // Add a person to the queue
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);  // Add the person to the back of the queue
    }

    // Get the next person in the queue
    public Person GetNextPerson()
    {
        if (_people.Count == 0)  // If the queue is empty, throw an exception
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person
        Person person = _people.Dequeue();

        // If the person has finite turns, decrement their turns
        if (person.Turns > 0)
        {
            person.Turns -= 1;  // Decrease their turns by 1

            // Re-enqueue the person only if they still have turns left
            if (person.Turns > 0)
            {
                _people.Enqueue(person);  // Put them back in the queue
            }
        }
        else
        {
            // If the person has infinite turns (turns <= 0), just re-enqueue them
            _people.Enqueue(person);  // Keep them in the queue indefinitely
        }

        return person;  // Return the person who was dequeued
    }

    // Optional: Override ToString to help with debugging
    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => p.Name));
    }
}
