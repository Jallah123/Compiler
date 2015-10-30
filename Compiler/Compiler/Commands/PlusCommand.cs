using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    public class PlusCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, IList<string> parameters)
        {
            int var1 = 0;
            int var2 = 0;

            switch(parameters[3])
            {
                case "NUMBER": var1 = Int32.Parse(parameters[1]); break;
                case "IDENTIFIER": var1 = Int32.Parse(vm.Variables[parameters[1]]); break;
            }

            switch (parameters[4])
            {
                case "NUMBER": var2 = Int32.Parse(parameters[2]); break;
                case "IDENTIFIER": var2 = Int32.Parse(vm.Variables[parameters[2]]); break;
            }
            int total = var1 + var2;

            vm.DebugPrint("Temp is now " + vm.Variables["$tempPlus"]);
            vm.Variables["$tempPlus"] = (Int32.Parse(vm.Variables["$tempPlus"]) + total).ToString();
            vm.ReturnValue = vm.Variables["$tempPlus"];
            
           vm.DebugPrint("Temp is now " + vm.Variables["$tempPlus"]);
            
        }
    }
}
