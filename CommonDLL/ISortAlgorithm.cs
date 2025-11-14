using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenstrukturen
{
    public interface ISortAlgorithm<T>
    {
        void Sort(Node<T> head);
    }
}
