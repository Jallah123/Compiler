using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class NodeLinkedList
    {
        public Node First { get; private set; }
        public Node Last { get; private set; }

        public void Add(Node n)
        {
            if(this.First == null)
            {
                this.First = n;
                this.Last = n;
            }

            if(this.Last != null)
            {
                this.Last.Next = n;
                n.Previous = this.Last;
                this.Last = n;
            }
        }

        public void InsertBefore(NodeLinkedList list)
        {
            Node last = list.Last;

            last.Next = this.First;
            this.First.Previous = last;
            this.First = list.First;
        }

        public void InsertAfter(NodeLinkedList list)
        {
            Node first = list.First;

            first.Previous = this.Last;
            Last.Next = first;
            this.Last = list.Last;
        }
    }
}
