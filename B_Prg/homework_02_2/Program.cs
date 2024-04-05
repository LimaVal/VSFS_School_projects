// Tento zdrojovy kod jsem vypracoval zcela samostatne bez cizi pomoci
// Nekopiroval jsem ani neopsal jsem cizi zdrojove kody
// Nikdo me pri vypracovani neradil
// Pokud nektery radek porusuje toto pravidlo je oznacen komentarem
// NENI MOJE TVORBA
// Poruseni techto pravidel se povazuje za podvod, ktery lze potrestat VYLOUCENIM ZE STUDIA
// Valiantsin Lubinski 40491


// Příklad 2.2: Cyklický obousměrný spojový seznam 
// Implementujte následující funkce pro práci s cyklickým obousměrným spojovým seznamem: 
// a) Funkce Vypis vypíše seznam na obrazovku. [1 bod] 
// b) Funkce Find vrátí první nalezený prvek seznamu obsahující hledanou hodnotu. [1 bod] 
// c) Funkce InsertAfter vloží do seznamu nový prvek se zadanou hodnotou. [3 body] 
// d) Funkce Delete smaže ze seznamu zadaný prvek. [3 body]


using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Transactions;

namespace priklad2;
class Program
{
    static void PrintTest(string s)
    {
        ConsoleColor originalForeColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(s);
        Console.ForegroundColor = originalForeColor;
    }

    public class Node
    {
        public int? data;
        public Node prev = null;
        public Node next = null;
    }

    static void Print(Node head)
    {
        if(head == null || head.data == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        Node curNode = head;
        for (; curNode.next != head; curNode = curNode.next)
            Console.Write($"{curNode.data}->");
        Console.Write($"{curNode.data}\n");
    }

    static Node CreateNode(int data)
    {
        Node node = new Node();
        node.data = data;
        node.prev = node.next = null;
        return node;
    }

    //          InsertAfter(place,         data)
    static Node InsertAfter(Node head, int data)
    {
        Node newNode = CreateNode(data);
        if (head == null)
        {
            head = newNode.next = newNode.prev = newNode;
        }
        else if (head == head.next)
        {
            head.next = head.prev = newNode;
            newNode.next = newNode.prev = head;
        }
        else
        {
            // link new
            newNode.next = head.next;
            newNode.prev = head;
            // set next item prev parm
            head.next.prev = newNode;
            // set head item next parm
            head.next = newNode;
        }
        return head;

    }

    static Node Delete(Node head)
    {
        if (head == null) return null;

        if (head == head.next)
        {
            head.data = null;
            // head = null;
            return head;
        }

        Node delNode = head;
  
        head.prev.next = delNode.next;
        head.next.prev = delNode.prev;
        head = delNode.next;
        
        //clear 
        delNode.next = delNode.prev = null;
        
        return head;
    }

    static Node Find(Node head, int pattern)
    {
        Node startNode = head;
        for (; head.next != startNode; head = head.next)
            if (head.data == pattern) break;
        return head;
    }

    static void Main(string[] args)
    {
        // circular doubly linked list
        Node cdll = null;
        PrintTest("Test Print() with empty list"); Print(cdll);

        cdll = InsertAfter(cdll, 5);
        PrintTest("Test Print() after InsertAfter() with 1 (one) node"); Print(cdll);

        cdll = InsertAfter(cdll, 7);
        PrintTest("Test Print() after InsertAfter() with 2 (two) node"); Print(cdll);

        cdll = InsertAfter(cdll, 2);
        PrintTest("Test Print() after InsertAfter() with 3 (three) node"); Print(cdll);

        InsertAfter(cdll.next, 1); // neukladame novy zacatek
        PrintTest("Test Print() after InsertAfter() with 4 (four) node"); Print(cdll);

        cdll = InsertAfter(cdll.next, 9);
        PrintTest("Test Print() after InsertAfter() with 5 (five) node"); Print(cdll);

        Delete(cdll.next); // neukladame novy zacatek
        PrintTest("Test Delete() with 4 (four) node"); Print(cdll);

        Node s2 = Find(cdll, 7);
        cdll = Delete(s2); 
        PrintTest("Test Delete() after Find and Delete for 3 (three) node"); Print(cdll);

        Delete(cdll.next); Delete(cdll.next); 
        PrintTest("Test Delete() after 2x Delete"); Print(cdll);

        Delete(cdll.next);
        PrintTest("Test Delete() after last item Delete"); Print(cdll);
    }
}
