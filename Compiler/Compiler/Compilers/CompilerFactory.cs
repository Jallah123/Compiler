using Compiler.Compilers.Compiled;
using System.Collections.Generic;

namespace Compiler
{
    public class CompilerFactory
    {
        private List<AbstractCompiled> compilers;
        private static CompilerFactory instance;

        public static CompilerFactory getInstance()
        {
            if(instance == null)
            {
                instance = new CompilerFactory();
            }

            return instance;
        }

        private CompilerFactory()
        {
            compilers = new List<AbstractCompiled>();
            compilers.Add(new CompiledCondition());
            compilers.Add(new CompiledAssignment());
            compilers.Add(new CompiledNumber());
            compilers.Add(new CompiledIdentifier());
            compilers.Add(new CompiledPrint());
            compilers.Add(new CompiledPrintLine());
            compilers.Add(new CompiledString());
            compilers.Add(new CompiledWhile());
            compilers.Add(new CompiledPlus());
            compilers.Add(new CompiledIf());
        }

        public AbstractCompiled GetCompiled(LinkedListNode<Token> currentToken)
        {
            foreach (var compiledStatement in compilers)
            {
                if (compiledStatement.IsMatch(currentToken))
                {
                    return compiledStatement.Clone();
                }
            }

            return new CompiledDoNothing();
        }
    }
}
