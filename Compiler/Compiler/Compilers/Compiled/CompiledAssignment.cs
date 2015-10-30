using System.Collections.Generic;
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


            DirectFunctionCallNode assignment = new DirectFunctionCallNode();
            assignment.Parameters.Add("ReturnToVariable");
            assignment.Parameters.Add(Left.Value.Text);

            Compiled.Add(assignment);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Previous != null
                && currentToken.Previous.Value.TokenType == TokenType.IDENTIFIER
                    && currentToken.Value.TokenType == TokenType.EQUALS;
        }
    }
}
