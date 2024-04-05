# Example 11.2: Queue (Program02.cs)

Implement the following types of queues. Write functions Create, Enqueue, Dequeue, Front, IsEmpty, and Print. The global constant 'max' indicates the maximum length of the queue, set to 100.

* Circular Queue (CFronta) - After the end of the queue reaches the length of the used array, it allows the end of the queue to continue at the free beginning of the array. It is necessary to keep track of the number of elements in the queue because it cannot be deduced from the start and end of the queue.

* Shift Queue (SFronta) - After the end of the queue reaches the length of the used array, it moves all elements to the beginning of the array while preserving their relative order.

* Priority Queue (PFronta) with parameter 'd' prioritizes numbers with a larger remainder when divided by 'd'. For example, for d = 2, it prioritizes odd numbers over even ones. When printing the priority queue, print each sub-queue on a separate line with its priority marked.
