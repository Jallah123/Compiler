using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class VariableToReturnCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.ReturnValue = vm.Variables[parameters[1]];

            vm.DebugPrint("Return is now " + vm.ReturnValue);
        }
    }
}
