
namespace Compiler.Nodes
{
    public class ConditionalJumpNode : Node
    {
        public Node NextOnFalse { get; internal set; }
        public Node NextOnTrue { get; internal set; }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
