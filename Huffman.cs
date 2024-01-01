using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgoritm
{
    internal class Huffman
    {
        public static HuffmanNode BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            PriorityQueue<HuffmanNode> priorityQueue = new PriorityQueue<HuffmanNode>();

            foreach (var entry in frequencies)
            {
                priorityQueue.Enqueue(new HuffmanNode { Symbol = entry.Key, Frequency = entry.Value });
            }

            while (priorityQueue.Count > 1)
            {
                HuffmanNode left = priorityQueue.Dequeue();
                HuffmanNode right = priorityQueue.Dequeue();

                HuffmanNode parent = new HuffmanNode
                {
                    Symbol = '\0',
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                priorityQueue.Enqueue(parent);
            }

            return priorityQueue.Dequeue();
        }

        public static Dictionary<char, string> BuildHuffmanCodes(HuffmanNode root)
        {
            Dictionary<char, string> huffmanCodes = new Dictionary<char, string>();
            BuildHuffmanCodesRecursive(root, "", huffmanCodes);
            return huffmanCodes;
        }

        private static void BuildHuffmanCodesRecursive(HuffmanNode node, string code, Dictionary<char, string> huffmanCodes)
        {
            if (node == null)
                return;

            if (node.Symbol != '\0')
            {
                huffmanCodes[node.Symbol] = code;
            }

            BuildHuffmanCodesRecursive(node.Left, code + "0", huffmanCodes);
            BuildHuffmanCodesRecursive(node.Right, code + "1", huffmanCodes);
        }

        public static string Compress(string input, Dictionary<char, string> huffmanCodes)
        {
            return string.Join("", input.Select(c => huffmanCodes[c]));
        }

        public static string Decompress(string compressed, HuffmanNode root)
        {
            HuffmanNode current = root;
            string result = "";

            foreach (char bit in compressed)
            {
                if (bit == '0')
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current.Symbol != '\0')
                {
                    result += current.Symbol;
                    current = root;
                }
            }

            return result;
        }
    }

}
