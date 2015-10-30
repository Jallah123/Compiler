using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public abstract class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public abstract void Accept(NodeVisitor visitor);
    }
}
