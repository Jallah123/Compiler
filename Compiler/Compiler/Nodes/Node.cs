
namespace Compiler.Nodes
{
    public abstract class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public abstract void Accept(NodeVisitor visitor);
    }
}
