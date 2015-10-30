using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    public abstract class NodeVisitor
    {
        public abstract void Visit(JumpNode node);
        public abstract void Visit(DoNothingNode doNothingNode);
        public abstract void Visit(FunctionCallNode functionCallNode);
        public abstract void Visit(DirectFunctionCallNode directFunctionCall);
        public abstract void Visit(ConditionalJumpNode conditionalJump);
    }
}
