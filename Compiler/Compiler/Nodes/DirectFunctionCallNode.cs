using System.Collections.Generic;

namespace Compiler.Nodes
{
    public class DirectFunctionCallNode : AbstractFunctionCallNode
    {
        public DirectFunctionCallNode()
        {
            Parameters = new List<string>();
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
