using System;
using System.Collections.Generic;

namespace Compiler.Commands
{
    public class PrintCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            Console.Write(vm.ReturnValue);
        }
    }
}
