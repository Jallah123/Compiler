
namespace Compiler.Nodes
{
    class NextNodeVisitor : NodeVisitor
    {
        private VirtualMachine virtualMachine;
        public Node NextNode { get; private set; }

        public NextNodeVisitor(VirtualMachine _virtualMachine)
        {
            virtualMachine = _virtualMachine;
        }

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
