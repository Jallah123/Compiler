using Compiler.Commands;
using Compiler.Nodes;
using System;
using System.Collections.Generic;

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
            Commands = new Dictionary<string, BaseCommand>();
            Commands.Add("CreateVariable", new CreateVariableCommand());
            Commands.Add("SetReturnValue", new SetReturnValueCommand());
            Commands.Add("VariableToReturn", new SmallerThanCommand());
            Commands.Add("ReturnToVariable", new ReturnToVariableCommand());
            Commands.Add("Print", new PrintCommand());
            Commands.Add("PrintLine", new PrintLineCommand());
            Commands.Add("Equals", new EqualsCommand());
            Commands.Add("Plus", new PlusCommand());
            Commands.Add("SmallerThan", new SmallerThanCommand());
            Commands.Add("ClearTempVariables", new ClearTempVariablesCommand());

            Variables = new Dictionary<string, string>();
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

                if (IsDebug)
                {
                    System.Threading.Thread.Sleep(100);
                }

            }
        }

        public void DebugPrint(string s)
        {
            if(IsDebug)
            {
                Console.WriteLine(s);
            }
        }
    }
}
