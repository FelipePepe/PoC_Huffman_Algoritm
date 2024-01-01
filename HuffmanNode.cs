using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanAlgoritm
{
    internal class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set;}

        public int CompareTo(HuffmanNode other)
        {
            return Frequency - other.Frequency;
        }

    }
}
