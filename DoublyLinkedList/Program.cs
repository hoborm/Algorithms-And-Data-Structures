using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinkedList<int> lista = new LinkedList<int>();
            lista.AddFirst(10);
            lista.AddFirst(20);
            lista.AddLast(51);
            lista.AddFirst(52);
            lista.AddFirst(53);
            lista.AddFirst(54);
            lista.AddFirst(55);
            lista.Remove(53);
            foreach (int item in lista)
            {
                Console.WriteLine("{0}", item);
            }
            Console.ReadKey();
        }
    }
}