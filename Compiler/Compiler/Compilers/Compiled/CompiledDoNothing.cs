using Compiler.Nodes;
using System.Collections.Generic;

namespace Compiler.Compilers.Compiled
{
    class CompiledDoNothing : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledDoNothing();
        }

        public override void Compile()
        {
            DirectFunctionCallNode node = new DirectFunctionCallNode();

            node.Parameters.Add("ClearTempVariables");

            Compiled.Add(node);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return false;
        }
    }
}
