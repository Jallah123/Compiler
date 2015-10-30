using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class SmallerThanCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {

            if (Int32.Parse(vm.Variables[parameters[1]]) < Int32.Parse(parameters[2]))
            {
                vm.ReturnValue = "True";
                vm.DebugPrint("Return is true");
            }
            else
            {
                vm.ReturnValue = "False";
                vm.DebugPrint("Return is false");
            }
        }
    }
}
