using System.Collections.Generic;

namespace Compiler.Commands
{
    public abstract class BaseCommand
    {
        public abstract void Execute(VirtualMachine vm, List<string> parameters);
    }
}
