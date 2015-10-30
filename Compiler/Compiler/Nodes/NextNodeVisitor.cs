using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Nodes
{
    class NextNodeVisitor : NodeVisitor
    {
        private VirtualMachine virtualMachine;

        public NextNodeVisitor(VirtualMachine virtualMachine)
        {
            this.virtualMachine = virtualMachine;
        }

        public Node NextNode { get; private set; }

        public override void Visit(DoNothingNode node)
        {
            NextNode = node.Next;
        }

        public override void Visit(ConditionalJumpNode node)
        {
            if (virtualMachine.ReturnValue == "True")
            {
                NextNode = node.NextOnTrue;
            }
            else
            {
                NextNode = node.NextOnFalse;
            }
        }

        public override void Visit(JumpNode node)
        {
            NextNode = node.JumpToNode;
        }

        public override void Visit(DirectFunctionCallNode node)
        {
            NextNode = node.Next;
        }

        public override void Visit(FunctionCallNode node)
        {
            NextNode = node.Next;
        }
    }
}
