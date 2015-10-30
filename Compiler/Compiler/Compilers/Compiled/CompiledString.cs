using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    class CompiledString : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledString();
        }

        public override void Compile()
        {
            string CompiledString = "";

            while(CurrentToken.Value.TokenType != TokenType.STRINGOPENCLOSE)
            {
                
                CurrentToken = CurrentToken.Next;
            }

            CompiledString += " " + CurrentToken.Value.Text;

            CompiledString = CompiledString.Trim();

            DirectFunctionCallNode returnVariable = new DirectFunctionCallNode();
            returnVariable.Parameters.Add("SetReturnValue");
            returnVariable.Parameters.Add(CompiledString);

            Compiled.Add(returnVariable);

        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            if(currentToken.Value.TokenType == TokenType.STRINGOPENCLOSE)
            {
                return true;
            }

            return false;
        }
    }
}
