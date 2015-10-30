using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class SetReturnValueCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            if(parameters.Count == 3)
            {
                vm.ReturnValue = vm.Variables[parameters[1]];
                vm.DebugPrint("Return is " + vm.Variables[parameters[1]]);
            }
            else
            {
                vm.ReturnValue = parameters[1];
                vm.DebugPrint("Return is " + parameters[1]);
            }
            
        }
    }
}
