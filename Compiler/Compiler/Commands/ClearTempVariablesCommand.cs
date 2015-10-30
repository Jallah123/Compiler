using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class ClearTempVariablesCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            vm.Variables["$tempPlus"] = "0";
        }
    }
}
