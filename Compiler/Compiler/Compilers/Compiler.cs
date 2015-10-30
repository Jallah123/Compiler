using Compiler.Nodes;
using System.Collections.Generic;

namespace Compiler
{
    public class Compiler
    {
        public LinkedList<Token> TokenList { get; set; }

        public Compiler(LinkedList<Token> _TokenList)
        {
            TokenList = _TokenList;
        }

        public NodeLinkedList compile()
        {
            LinkedListNode<Token> currentToken = TokenList.First;

            NodeLinkedList LinkedList = new NodeLinkedList();
            LinkedList.Add(new DoNothingNode());
            
            while(currentToken != null)
            {
                var compiled = CompilerFactory.getInstance().GetCompiled(currentToken);
                compiled.CurrentToken = currentToken;
                compiled.Compile();

                currentToken = compiled.CurrentToken.Next;
                LinkedList.InsertAfter(compiled.Compiled);
            }
           
            return LinkedList;
        }
    }
}
