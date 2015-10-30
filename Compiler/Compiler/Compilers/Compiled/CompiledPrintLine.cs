using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    class CompiledPrintLine : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledPrintLine();
        }

        public override void Compile()
        {
            CurrentToken = CurrentToken.Next.Next;

            while (CurrentToken.Value.TokenType != TokenType.ELLIPSISCLOSE)
            {
                var compiled = CompilerFactory.getInstance().GetCompiled(CurrentToken);
                compiled.CurrentToken = CurrentToken;
                compiled.Compile();

                CurrentToken = CurrentToken.Next;
                Compiled.InsertAfter(compiled.Compiled);
            }

            FunctionCallNode print = new FunctionCallNode();
            print.Parameters.Add("PrintLine");

            this.Compiled.Add(print);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            if (currentToken.Value.TokenType == TokenType.PRINTLINE)
            {
                return true;
            }

            return false;
        }
    }
}
