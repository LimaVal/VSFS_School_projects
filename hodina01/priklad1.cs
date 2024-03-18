namespace priklad1;
class Program
{
    static void PrintTest(string s)
    {
        ConsoleColor originalForeColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(s);
        Console.ForegroundColor = originalForeColor;
    }

    class LinkedL
    {
        public int data = 0;
        public LinkedL next = null;
    }

    static void Print(LinkedL Node)
    {
        if(Node == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        for (; Node.next != null; Node = Node.next)
            Console.Write($"{Node.data}->");
        Console.Write($"{Node.data}\n");
    }

    static LinkedL CreateNode(int n)
    {
        LinkedL node = new LinkedL();
        node.data = n;
        node.next = null;
        return node;
    }

    static LinkedL ConvertArray(int[] array)
    {
        if (array.Length == 0) return null;
        LinkedL firstNode = CreateNode(array[0]);
        LinkedL prevNode = firstNode;
        for (int i = 1; i < array.Length; i++)
        {
            LinkedL currentNode = CreateNode(array[i]);
            prevNode.next = currentNode;
            prevNode = currentNode;
        }
        return firstNode;
    }

    // a) Save to text file
    static void Save(string path, LinkedL Node)
    {
        StreamWriter sw = new StreamWriter(path);

        for (; Node != null; Node = Node.next)
            sw.Write($"{Node.data} ");
        sw.Close();
    }

    //TODO b) Load from text file
    static LinkedL Load(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();
        LinkedL firstNode = null;
        LinkedL prevNode = null;

        string data = "";
        for (int i = 0; i < line.Length; i++)
            if (char.IsWhiteSpace(line[i]))
            {
                LinkedL currentNode = CreateNode(Convert.ToInt32(data));
                if (firstNode == null) firstNode = currentNode;
                prevNode.next = currentNode;
                prevNode = currentNode;
                data = "";
            }
            else
                data += line[i];

        sr.Close();
        return firstNode;
    }

    // c) 
    static int Count(LinkedL Node, int pattern) 
    {
        int counter = 0;
        for (; Node != null; Node = Node.next)
            if (Node.data == pattern) counter++;
        return counter;
    }

    // d)
    static LinkedL DeleteLast(LinkedL currNode, int pattern)
    {
        LinkedL firstNode = currNode;
        LinkedL prevNode = currNode;
        for (int patternCount = Count(currNode, pattern); patternCount != 0;)
        {
            if (currNode.data == pattern && patternCount == 1)
            {
                prevNode.next = currNode.next;
                return firstNode;
            }
            if (currNode.data == pattern) patternCount--;
            prevNode = currNode;
            currNode = currNode.next;
        }
        return firstNode;
    }

    // e)
    static LinkedL DeleteMax(LinkedL currNode)
    {
        LinkedL firstNode = currNode;
        LinkedL prevNode = null;
        int maxNumber = -1;

        // find Node where data is maximum
        for (; currNode != null; currNode = currNode.next)
            if(currNode.data > maxNumber) maxNumber = currNode.data;

        //return to first Node, delete first max Node
        for (currNode = firstNode; currNode != null; prevNode = currNode, currNode = currNode.next)
            if (currNode.data == maxNumber)
            {
                if(prevNode == null) firstNode = currNode.next;
                else prevNode.next = currNode.next;
                return firstNode;
            }
        return null;
    }

    // f)
    static LinkedL Reverse(LinkedL currNode)
    {
        LinkedL prevNode = null;
        LinkedL prevPrevNode = null;
        for (;currNode != null; prevPrevNode = prevNode, prevNode = currNode, currNode = currNode.next)
            if(prevNode != null) prevNode.next = prevPrevNode;
        prevNode.next = prevPrevNode;
        return prevNode;
    }



    static void Main(string[] args)
    {
        int[] arr = { 1055, 2, 29, 8, 7, 15, 29, 8, 22, 6, 29 };
        int[] arrEmpty = { };
        int[] arrOneItem = { 0 };
        int[] arrTwoItem = { 0, 2 };
        LinkedL s1 = ConvertArray(arr);
        LinkedL sE = ConvertArray(arrEmpty);
        LinkedL sOne = ConvertArray(arrOneItem);

        PrintTest("\nTest ConvertArray()");
        Print(s1);
        Print(sE);
        Print(sOne);

        PrintTest("\nTest Save()");
        Save("linkedlist.txt", s1);
        Save("linkedlist_empty.txt", sE);
        Save("linkedlist_one_zero.txt", sOne);

        // LinkedL s2 = Load("spojak.txt");
        // Print(s2);

        PrintTest("\nTest Count()");
        Console.WriteLine(Count(s1, 29));
        Console.WriteLine(Count(sE, 0));
        Console.WriteLine(Count(sOne, 0));

        PrintTest("\nTest DeleteLast()");
        s1 = DeleteLast(s1, 8);
        Print(s1);

        PrintTest("\nTest DeleteMax()");
        s1 = DeleteMax(s1);
        Print(s1);
        sE = DeleteMax(sE);
        Print(sE);
        sOne = DeleteMax(sOne);
        Print(sOne);

        PrintTest("\nTest Reverse()");
        sOne = ConvertArray(arrOneItem);
        LinkedL sTwo = ConvertArray(arrTwoItem);
        s1 = Reverse(s1); 
        Print(s1);
        sOne = Reverse(sOne); 
        Print(sOne);
        sTwo = Reverse(sTwo); 
        Print(sTwo);
    }
}
