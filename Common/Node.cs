using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Node
    {
        public Person Data { get; set; }
        public Node Next { get; set; }

        public Node(Person data)
        {
            Data = data;
            Next = null;
        }
    }
}