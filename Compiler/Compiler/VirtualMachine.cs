using Compiler.Commands;
using Compiler.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class VirtualMachine
    {
        private readonly bool IsDebug = false;

        public string ReturnValue { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public Dictionary<string, BaseCommand> Commands { get; set; }

        public VirtualMachine()
        {
            this.Commands = new Dictionary<string, BaseCommand>();
            this.Commands.Add("CreateVariable", new CreateVariableCommand());
            this.Commands.Add("SetReturnValue", new SetReturnValueCommand());
            this.Commands.Add("VariableToReturn", new SmallerThanCommand());
            this.Commands.Add("ReturnToVariable", new ReturnToVariableCommand());
            this.Commands.Add("Print", new PrintCommand());
            this.Commands.Add("PrintLine", new PrintLineCommand());
            this.Commands.Add("Equals", new EqualsCommand());
            this.Commands.Add("Plus", new PlusCommand());
            this.Commands.Add("SmallerThan", new SmallerThanCommand());
            this.Commands.Add("ClearTempVariables", new ClearTempVariablesCommand());

           

            this.Variables = new Dictionary<string, string>();
            Variables["$tempPlus"] = "0";
        }

        public void Run(NodeLinkedList list)
        {
            Node currentNode = list.First;
            NextNodeVisitor visitor = new NextNodeVisitor(this);

            while(currentNode != null)
            {
                AbstractFunctionCallNode node = currentNode as AbstractFunctionCallNode;

                if(node != null)
                {                    
                    string name = node.Parameters[0];
                    Commands[name].Execute(this, node.Parameters);
                }

                currentNode.Accept(visitor);
                currentNode = visitor.NextNode;

                if (this.IsDebug)
                {
                    System.Threading.Thread.Sleep(100);
                }

            }
        }

        public void DebugPrint(string s)
        {
            if(this.IsDebug)
            {
                Console.WriteLine(s);
            }
        }
    }
}
