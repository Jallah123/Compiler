using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    class CompiledNumber : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledNumber();
        }

        public override void Compile()
        {
            DirectFunctionCallNode toReturn = new DirectFunctionCallNode();
            toReturn.Parameters.Add("SetReturnValue");
            toReturn.Parameters.Add(CurrentToken.Value.Text);

            Compiled.Add(toReturn);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.NUMBER;
        }
    }
}
