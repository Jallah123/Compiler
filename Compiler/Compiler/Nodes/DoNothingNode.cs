
namespace Compiler.Nodes
{
    public class DoNothingNode : Node
    {
        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
