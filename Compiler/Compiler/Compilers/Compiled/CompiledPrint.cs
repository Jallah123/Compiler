using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            this.Compiled.Add(print);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            if(currentToken.Value.TokenType == TokenType.PRINT)
            {
                return true;
            }

            return false;
        }
    }
}
