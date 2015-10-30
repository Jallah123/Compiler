using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
