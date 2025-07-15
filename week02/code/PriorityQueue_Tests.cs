using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue and Dequeue a single item.
    // Expected Result: The single item should be returned.
    // Defect(s) Found: PASS – Works as expected for one item.
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Item with highest priority should be dequeued first.
    // Defect(s) Found: PASS – Highest priority respected.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);
        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority.
    // Expected Result: Items should be dequeued in FIFO order.
    // Defect(s) Found: PASS – FIFO works correctly on priority ties.
    public void TestPriorityQueue_SamePriority_FIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 3);
        pq.Enqueue("Second", 3);
        pq.Enqueue("Third", 3);
        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found: PASS – Exception correctly thrown.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue_Throws()
    {
        var pq = new PriorityQueue();
        pq.Dequeue();
    }
}
