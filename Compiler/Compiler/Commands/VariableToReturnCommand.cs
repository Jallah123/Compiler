using System.Collections.Generic;

namespace Compiler.Commands
{
    class VariableToReturnCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            vm.ReturnValue = vm.Variables[parameters[1]];

            vm.DebugPrint("Return is now " + vm.ReturnValue);
        }
    }
}
