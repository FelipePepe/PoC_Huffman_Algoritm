using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgoritm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Huffman coding is a compression algorithm";
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (frequencies.ContainsKey(c))
                {
                    frequencies[c]++;
                }
                else
                {
                    frequencies[c] = 1;
                }
            }

            HuffmanNode huffmanTree = Huffman.BuildHuffmanTree(frequencies);
            Dictionary<char, string> huffmanCodes = Huffman.BuildHuffmanCodes(huffmanTree);

            string compressed = Huffman.Compress(input, huffmanCodes);
            string decompressed = Huffman.Decompress(compressed, huffmanTree);

            Console.WriteLine("Original: " + input);
            Console.WriteLine("Compressed: " + compressed);
            Console.WriteLine("Decompressed: " + decompressed);

            Console.Read();
        }
    }
}

