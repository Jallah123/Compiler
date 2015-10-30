using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    class CompiledPlus : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledPlus();
        }

        public override void Compile()
        {
            LinkedListNode<Token> Left = CurrentToken.Previous;
            LinkedListNode<Token> Right = CurrentToken.Next;
            
            DirectFunctionCallNode assign = new DirectFunctionCallNode();
            assign.Parameters.Add("Plus");
            assign.Parameters.Add(Left.Value.Text);
            assign.Parameters.Add(Right.Value.Text);
            assign.Parameters.Add(Left.Value.TokenType.ToString());
            assign.Parameters.Add(Right.Value.TokenType.ToString());

            this.CurrentToken = CurrentToken.Next;

            this.Compiled.Add(assign);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            if(currentToken.Value.TokenType == TokenType.PLUS)
            {
                return true;
            }

            return false;
        }
    }
}
