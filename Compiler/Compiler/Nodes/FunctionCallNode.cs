using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class FunctionCallNode : AbstractFunctionCallNode
    {
        public FunctionCallNode()
        {
            this.Parameters = new List<string>();
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
