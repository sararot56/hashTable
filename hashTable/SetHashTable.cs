using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashTable
{
    public class SetHashTable<T>
    {
        private class Node//ניהול הרשימה
        {
            public T Key;
            public Node Next;

            public Node(T key)//פעולה בונה
            {
                Key = key;
                Next = null;
            }
        }
        private Node[] arr;
        private int count;
        private  int Capacity ;

        public SetHashTable(int n)
        {
            arr = new Node[n];
            count = 0;
            Capacity = n;
        }

        public bool Add(T key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key), "לא ניתן להוסיף מפתח ריק (Null).");

            int index = Math.Abs(key.GetHashCode()) % arr.Length;//דוג לפונקצית גיבוב
            Node current = arr[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return false; // המפתח כבר קיים
                }
                current = current.Next;
            }

            Node newNode = new Node(key);
            newNode.Next = arr[index];
            arr[index] = newNode;
            count++;

            return true;
        }

        public bool Find(T key)
        {
            if (key == null) return false;

            int index = Math.Abs(key.GetHashCode()) % arr.Length;
            Node current = arr[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool Remove(T key)
        {
            if (key == null) return false;

            int index = Math.Abs(key.GetHashCode()) % arr.Length;
            Node current = arr[index];
            Node prev = null;

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (prev == null)
                    {
                        arr[index] = current.Next; // הסרת החוליה הראשונה
                    }
                    else
                    {
                        prev.Next = current.Next; // דילוג על החוליה הנוכחית
                    }

                    count--;
                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

    }
}
