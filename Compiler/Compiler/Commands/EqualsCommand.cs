using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    class EqualsCommand : BaseCommand
    {
        public override void Execute(VirtualMachine vm, List<string> parameters)
        {
            int a, b;

            bool var1 = Int32.TryParse(parameters[1], out a);
            bool var2 = Int32.TryParse(parameters[2], out b);

            if(var1 && var2)
            {
                vm.ReturnValue = (vm.Variables[parameters[1]] == vm.Variables[parameters[1]]).ToString();
            }
            else
            {
                if(!var1)
                {
                    vm.ReturnValue = (vm.Variables[parameters[1]] == b.ToString()).ToString();
                }
                else if (!var2)
                {
                    vm.ReturnValue = (vm.Variables[parameters[2]] == a.ToString()).ToString();
                }
                else
                {
                    vm.ReturnValue = (parameters[1] == parameters[2]).ToString();
                }
            }

            vm.DebugPrint("Return is now " + vm.ReturnValue);


        }
    }
}
