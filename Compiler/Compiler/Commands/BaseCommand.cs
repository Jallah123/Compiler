using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Commands
{
    public abstract class BaseCommand
    {
        public abstract void Execute(VirtualMachine vm, List<string> parameters);
    }
}
