using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue elements with different priorities and dequeue them.
    // Expected Result: Elements are dequeued in order of highest priority, and FIFO is respected for ties.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1); // Priority 1
        priorityQueue.Enqueue("Task2", 3); // Priority 3
        priorityQueue.Enqueue("Task3", 2); // Priority 2

        // Dequeue in order of priority
        Assert.AreEqual("Task2", priorityQueue.Dequeue()); // Priority 3
        Assert.AreEqual("Task3", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual("Task1", priorityQueue.Dequeue()); // Priority 1
    }

    [TestMethod]
    // Scenario: Enqueue elements with the same priority and dequeue them.
    // Expected Result: Elements with the same priority are dequeued in FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 2); // Priority 2
        priorityQueue.Enqueue("Task2", 2); // Priority 2
        priorityQueue.Enqueue("Task3", 2); // Priority 2

        // Dequeue should respect FIFO for same priority
        Assert.AreEqual("Task1", priorityQueue.Dequeue());
        Assert.AreEqual("Task2", priorityQueue.Dequeue());
        Assert.AreEqual("Task3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch
        {
            Assert.Fail("An unexpected exception type was thrown.");
        }
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue multiple elements to test overall functionality.
    // Expected Result: Elements are dequeued in the correct order based on priority.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 3);
        priorityQueue.Enqueue("Task3", 3);
        priorityQueue.Enqueue("Task4", 2);

        Assert.AreEqual("Task2", priorityQueue.Dequeue());
        Assert.AreEqual("Task3", priorityQueue.Dequeue());
        Assert.AreEqual("Task4", priorityQueue.Dequeue());
        Assert.AreEqual("Task1", priorityQueue.Dequeue());
    }
}
