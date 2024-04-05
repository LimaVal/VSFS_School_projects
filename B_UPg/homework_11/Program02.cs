namespace priklad02;
class Program
{
    const int MAXL = 100;

    public enum QTypes
    {
        Circular,
        Shifted,
        Priority
    } 

    struct Queue
    {
        public int [] arr;
        public int front;
        public int back;
        public int count;
        public QTypes type;
    }

    struct QueueP
    {
        public Queue[] arr;
        public QTypes type;
        public int priority;
    }

    // Cycle Queue
    static Queue CreateCQ()
    {
        Queue q;
        q.arr = new int[MAXL];
        q.front = 0;
        q.back = 0;
        q.count = 0;
        q.type = QTypes.Circular;
        return q;
    }

    // Shifted Queue
    static Queue CreateSQ()
    {
        Queue q;
        q.arr = new int[MAXL];
        q.front = 0;
        q.back = 0;
        q.count = 0;
        q.type = QTypes.Shifted;
        return q;
    }

    // Priority Queue
    static QueueP CreatePQ(int priority)
    {
        QueueP q;

        q.arr = new Queue[priority];
        for (int i = 0; i < priority; i++)
            // CreateSQ() for Shifted or CreateCQ() for Circular
            q.arr[i] = CreateCQ();

        q.priority = priority;
        q.type = QTypes.Priority;
        return q;
    }

    // Enqueue for priority queue
    static void Enqueue(ref QueueP qp, int item)
    {
        Enqueue(ref qp.arr[item % qp.priority], item);
    }

    // Enqueue for Circular or Shifted queue
    static void Enqueue(ref Queue q, int item)
    {
        if(q.back == MAXL)
            if(q.type == QTypes.Circular) q.back = 0;
            else if(q.type == QTypes.Shifted) ShiftQueue(ref q);
        if(q.count == MAXL)
        {
            Console.WriteLine("Queue is full. Use Dequeue first or change queue size");
            return;
        }
        q.arr[q.back++] = item;
        q.count++;
    }

    // Dequeue for priority queue
    static int Dequeue(ref QueueP qp)
    {
        for (int i = qp.priority - 1; i > -1; i--)
            if(IsEmpty(qp.arr[i])) continue;
            else return Dequeue(ref qp.arr[i]);
        // osetreni
        Console.WriteLine("Queue is empty");
        return 0;
    }

    // Dequeue for Circular or Shifted queue
    static int Dequeue(ref Queue q)
    {
        if(q.front == MAXL) q.front = 0;
        if(IsEmpty(q))
        {
            Console.WriteLine("Queue is empty");
            return 0;
        }
        else
        {
            q.count--;
            return q.arr[q.front++];
        }
    }

    static int Front(QueueP qp)
    {
        for (int i = qp.priority - 1; i > -1; i--)
            if(IsEmpty(qp.arr[i])) continue;
            else return Front(qp.arr[i]);
        // osetreni
        Console.WriteLine("Queue is empty");
        return 0;
    }

    static int Front(Queue q)
    {
        if(IsEmpty(q))
        {
            Console.WriteLine("Queue is empty");
            return 0;
        }
        else return q.arr[q.front];
    }

    static bool IsEmpty(Queue q)
    {
        return q.front == q.back;
    }

    static void ConsoleWriteQueue(QueueP qp)
    {
        for (int i = qp.priority - 1; i > -1; i--)
        {
            Console.Write($"{i}: ");
            ConsoleWriteQueue(qp.arr[i]);
        }
    }

    static void ConsoleWriteQueue(Queue q)
    {
        int i = q.count;
        int j = q.front;

        while(i != 0)
        {
            if(q.front == MAXL) q.front = 0;
            Console.Write($"{q.arr[j++]} ");
            i--;
        }
        Console.WriteLine();
    }

    static void ShiftQueue(ref Queue q)
    {
        for(int i = 0; i < q.count; i++)
            q.arr[i] = q.arr[q.front + i];
            
        q.front = 0; 
        q.back = q.count;
    }

    static void Main(string[] args)
    {
        Random r = new Random(); 
        int i; 
        QueueP pf = CreatePQ(5); 
        for (i = 0; i < 90; i++) Enqueue(ref pf, r.Next(0, 50)); 
        for (i = 0; i < 80; i++) Dequeue(ref pf); 
        for (i = 0; i < 10; i++) Enqueue(ref pf, r.Next(0, 50)); 
        ConsoleWriteQueue(pf); 

        int fr = Front(pf);
        System.Console.WriteLine(fr);
    }
}