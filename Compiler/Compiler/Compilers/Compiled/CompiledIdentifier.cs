using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    class CompiledIdentifier : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledIdentifier();
        }

        public override void Compile()
        {
            DirectFunctionCallNode identifierNode = new DirectFunctionCallNode();
            identifierNode.Parameters.Add("CreateVariable");
            identifierNode.Parameters.Add(CurrentToken.Value.Text);

            DirectFunctionCallNode returnValue = new DirectFunctionCallNode();
            returnValue.Parameters.Add("SetReturnValue");
            returnValue.Parameters.Add(CurrentToken.Value.Text);
            returnValue.Parameters.Add("true");

            Compiled.Add(identifierNode);
            Compiled.Add(returnValue);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.IDENTIFIER;
        }
    }
}
