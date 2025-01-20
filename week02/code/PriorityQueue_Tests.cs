using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
[TestMethod]
public void TestPriorityQueue_1()
{
    // Arrange
    var queue = new PriorityQueue();  // Non-generic class

    // Enqueue some items with priorities
    queue.Enqueue(10, 1);  // Low priority
    queue.Enqueue(20, 10); // High priority

    // Act
    var first = queue.Dequeue();  // This should return 20
    var second = queue.Dequeue(); // This should return 10

    // Assert
    Assert.AreEqual(20, first);
    Assert.AreEqual(10, second);
}

[TestMethod]
public void TestPriorityQueue_2()
{
    // Arrange
    var queue = new PriorityQueue();  // Non-generic class

    // Enqueue items with different priorities
    queue.Enqueue("Low", 1);
    queue.Enqueue("High", 10);
    queue.Enqueue("Medium", 5);

    // Act
    var highestPriority = queue.Dequeue();  // "High"
    var mediumPriority = queue.Dequeue();   // "Medium"
    var lowestPriority = queue.Dequeue();   // "Low"

    // Assert
    Assert.AreEqual("High", highestPriority);
    Assert.AreEqual("Medium", mediumPriority);
    Assert.AreEqual("Low", lowestPriority);
}
}