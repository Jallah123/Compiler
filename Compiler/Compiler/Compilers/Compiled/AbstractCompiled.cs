using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Compilers.Compiled
{
    public abstract class AbstractCompiled
    {
        public NodeLinkedList Compiled { get; }
        public LinkedListNode<Token> CurrentToken { get; set; }

        public AbstractCompiled()
        {
            this.Compiled = new NodeLinkedList();
            this.Compiled.Add(new DoNothingNode());
        }

        public abstract void Compile();
        public abstract AbstractCompiled Clone();
        public abstract bool IsMatch(LinkedListNode<Token> currentToken);
    }
}
