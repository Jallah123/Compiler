using System.Collections.Generic;

namespace Compiler.Commands
{
    class ClearTempVariablesCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            vm.Variables["$tempPlus"] = "0";
        }
    }
}
