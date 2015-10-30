using Compiler.Nodes;
using System.Collections.Generic;

namespace Compiler.Compilers.Compiled
{
    class CompiledWhile : AbstractCompiled
    {
        public override AbstractCompiled Clone()
        {
            return new CompiledWhile();
        }

        public override void Compile()
        {
            DoNothingNode firstDN = new DoNothingNode();
            DoNothingNode lastDN = new DoNothingNode();

            Compiled.Add(firstDN);

            compileCondition(lastDN);

            compileStatements();

            Compiled.Add(new JumpNode(firstDN));

            Compiled.Add(lastDN);
        }

        private void compileCondition(DoNothingNode lastDN)
        {
            DoNothingNode middleDN = new DoNothingNode();
            CompiledCondition condition = new CompiledCondition();

            while (CurrentToken.Value.TokenType != TokenType.ELLIPSISOPEN)
            {
                CurrentToken = CurrentToken.Next;
            }

            condition.CurrentToken = CurrentToken.Next.Next;
            condition.Compile();
            CurrentToken = condition.CurrentToken;

            Compiled.InsertAfter(condition.Compiled);

            ConditionalJumpNode jump = new ConditionalJumpNode();
            jump.NextOnTrue = middleDN;
            jump.NextOnFalse = lastDN;

            Compiled.Add(jump);
            Compiled.Add(middleDN);
        }

        private void compileStatements()
        {
            while (CurrentToken.Value.TokenType != TokenType.BRACKETOPEN)
            {
                CurrentToken = CurrentToken.Next;
            }

            CurrentToken = CurrentToken.Next;

            while (CurrentToken.Value.TokenType != TokenType.BRACKETCLOSE)
            {
                AbstractCompiled compiled = CompilerFactory.getInstance().GetCompiled(CurrentToken);
                compiled.CurrentToken = CurrentToken;
                compiled.Compile();
                Compiled.InsertAfter(compiled.Compiled);
                CurrentToken = CurrentToken.Next;
            }
        }

        public override bool IsMatch(LinkedListNode<Token> currentToken)
        {
            return currentToken.Value.TokenType == TokenType.WHILE;
        }
    }
}
