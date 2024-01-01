using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgoritm
{
    internal class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;

        public int Count => heap.Count;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = heap.Count - 1;

            while (i > 0)
            {
                int parent = (i - 1) / 2;

                if (heap[parent].CompareTo(heap[i]) <= 0)
                    break;

                T temp = heap[i];
                heap[i] = heap[parent];
                heap[parent] = temp;

                i = parent;
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T result = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int i = 0;

            while (true)
            {
                int leftChild = 2 * i + 1;
                int rightChild = 2 * i + 2;

                if (leftChild >= heap.Count)
                    break;

                int minChild = leftChild;

                if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[leftChild]) < 0)
                    minChild = rightChild;

                if (heap[i].CompareTo(heap[minChild]) <= 0)
                    break;

                T temp = heap[i];
                heap[i] = heap[minChild];
                heap[minChild] = temp;

                i = minChild;
            }

            return result;
        }
    }
}
