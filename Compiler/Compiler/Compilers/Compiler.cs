using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Compiler
    {
        public LinkedList<Token> TokenList { get; set; }

        public NodeLinkedList compile()
        {
            LinkedListNode<Token> currentToken = this.TokenList.First;

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
