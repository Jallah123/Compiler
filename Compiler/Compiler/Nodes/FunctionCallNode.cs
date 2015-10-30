using System.Collections.Generic;

namespace Compiler.Nodes
{
    public class FunctionCallNode : AbstractFunctionCallNode
    {
        public FunctionCallNode()
        {
            Parameters = new List<string>();
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
