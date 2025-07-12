using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities, dequeue returns the highest priority first
    // Expected Result: Items with higher priority are dequeued first
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue()); // highest priority 3
        Assert.AreEqual("C", priorityQueue.Dequeue()); // next highest 2
        Assert.AreEqual("A", priorityQueue.Dequeue()); // last with priority 1
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority dequeue in FIFO order
    // Expected Result: Among items with same priority, dequeue returns the earliest enqueued first
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue()); // A and B have same priority, A enqueued first
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue throws exception
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found:
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyDequeue_Throws()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue(); // Should throw
    }
}
