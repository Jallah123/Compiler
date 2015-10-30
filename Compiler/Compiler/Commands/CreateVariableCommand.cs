using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class CreateVariableCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            if(!vm.Variables.ContainsKey(parameters[1]))
            {
                vm.Variables[parameters[1]] = "0";
                vm.DebugPrint(parameters[1] + " is now created");
            }
        }
    }
}
