using System;
using System.Collections.Generic;

namespace Compiler.Commands
{
    public class PrintLineCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            Console.WriteLine(vm.ReturnValue);
        }
    }
}
