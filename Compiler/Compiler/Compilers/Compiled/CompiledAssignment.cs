using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Nodes;

namespace Compiler.Compilers.Compiled
{
    class CompiledAssignment : AbstractCompiled
    {

        public override AbstractCompiled Clone()
        {
            return new CompiledAssignment();
        }

        public override void Compile()
        {

            var Left = CurrentToken.Previous;
            CurrentToken = CurrentToken.Next;

            while (CurrentToken.Value.TokenType != TokenType.SEMICOLUM)
            {
                var compiled = CompilerFactory.getInstance().GetCompiled(CurrentToken);
                compiled.CurrentToken = CurrentToken;
                compiled.Compile();

                CurrentToken = compiled.CurrentToken.Next;
                Compiled.InsertAfter(compiled.Compiled);
            }


            DirectFunctionCallNode assign = new DirectFunctionCallNode();
            assign.Parameters.Add("ReturnToVariable");
            assign.Parameters.Add(Left.Value.Text);

            this.Compiled.Add(assign);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            if(currentToken.Previous != null
                && currentToken.Previous.Value.TokenType == TokenType.IDENTIFIER
                    && currentToken.Value.TokenType == TokenType.EQUALS)
            {
                return true;
            }
            
            return false;
        }
    }
}
