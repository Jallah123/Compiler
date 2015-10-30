using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public class JumpNode : Node
    {
        public Node JumpToNode { get; set; }

        public JumpNode(Node Jump)
        {
            JumpToNode = Jump;
        }

        public override void Accept(NodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
