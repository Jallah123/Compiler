using System.Collections.Generic;

namespace Compiler.Nodes
{
    public abstract class AbstractFunctionCallNode : Node
    {
        public List<string> Parameters { get; set; }
    }
}
