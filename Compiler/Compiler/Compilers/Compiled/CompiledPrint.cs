using Compiler.Nodes;
using System.Collections.Generic;

namespace Compiler.Compilers.Compiled
{
    class CompiledPrint : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledPrint();
        }

        public override void Compile()
        {
            CurrentToken = CurrentToken.Next.Next;

            while(CurrentToken.Value.TokenType != TokenType.ELLIPSISCLOSE)
            {
                var compiled = CompilerFactory.getInstance().GetCompiled(CurrentToken);
                compiled.CurrentToken = CurrentToken;
                compiled.Compile();

                CurrentToken = CurrentToken.Next;
                Compiled.InsertAfter(compiled.Compiled);
            }           

            FunctionCallNode print = new FunctionCallNode();
            print.Parameters.Add("Print");

            Compiled.Add(print);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.PRINT;
        }
    }
}
