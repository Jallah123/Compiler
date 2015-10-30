using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
