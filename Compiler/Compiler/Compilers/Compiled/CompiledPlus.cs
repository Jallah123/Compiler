using Compiler.Nodes;
using System.Collections.Generic;

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

            CurrentToken = CurrentToken.Next;

            Compiled.Add(assign);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.PLUS;
        }
    }
}
