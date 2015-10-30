using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class ReturnToVariableCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            if(vm.Variables.ContainsKey(parameters[1]))
            {
                vm.Variables[parameters[1]] = vm.ReturnValue;
            }
            else
            {
                throw new Exception("Variable does not exist");
            }

            vm.DebugPrint("Variable " + parameters[1] + " = " + vm.ReturnValue);
        }
    }
}
