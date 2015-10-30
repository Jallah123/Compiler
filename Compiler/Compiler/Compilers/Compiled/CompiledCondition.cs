using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Nodes;

namespace Compiler.Compilers.Compiled
{
    class CompiledCondition : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledCondition();
        }

        public override void Compile()
        {
            var left = CurrentToken.Previous;
            var right = CurrentToken.Next;

            DirectFunctionCallNode calc = new DirectFunctionCallNode();

            switch (CurrentToken.Value.TokenType)
            {
                case TokenType.GREATERTHAN: calc.Parameters.Add("GreaterThan"); break;
                case TokenType.SMALLERTHAN: calc.Parameters.Add("SmallerThan"); break;
                case TokenType.DOUBLE_EQUALS: calc.Parameters.Add("Equals"); break;
            }

            calc.Parameters.Add(left.Value.Text);
            calc.Parameters.Add(right.Value.Text);

            Compiled.Add(calc);
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.DOUBLE_EQUALS || currentToken.Value.TokenType == TokenType.SMALLERTHAN;
        }
    }
}
