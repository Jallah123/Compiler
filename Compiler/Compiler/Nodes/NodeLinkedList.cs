namespace Compiler.Nodes
{
    public class NodeLinkedList
    {
        public Node First { get; private set; }
        public Node Last { get; private set; }

        public void Add(Node n)
        {
            if(First == null)
            {
                First = n;
                Last = n;
            }

            if(Last != null)
            {
                Last.Next = n;
                n.Previous = Last;
                Last = n;
            }
        }

        public void InsertBefore(NodeLinkedList list)
        {
            Node last = list.Last;

            last.Next = First;
            First.Previous = last;
            First = list.First;
        }

        public void InsertAfter(NodeLinkedList list)
        {
            Node first = list.First;

            first.Previous = Last;
            Last.Next = first;
            Last = list.Last;
        }
    }
}
