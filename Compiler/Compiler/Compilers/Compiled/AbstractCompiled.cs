using Compiler.Nodes;
using System.Collections.Generic;

namespace Compiler.Compilers.Compiled
{
    public abstract class AbstractCompiled
    {
        public NodeLinkedList Compiled { get; }
        public LinkedListNode<Token> CurrentToken { get; set; }

        public AbstractCompiled()
        {
            Compiled = new NodeLinkedList();
            Compiled.Add(new DoNothingNode());
        }

        public abstract void Compile();
        public abstract AbstractCompiled Clone();
        public abstract bool IsMatch(LinkedListNode<Token> currentToken);
    }
}
