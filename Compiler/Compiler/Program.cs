using System;
using System.IO;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = (File.ReadAllLines(Environment.CurrentDirectory + @"\..\..\Language.txt"));

            Tokenizer tokenizer = new Tokenizer(code);

            Compiler compiler = new Compiler(tokenizer.tokenList);

            VirtualMachine vm = new VirtualMachine();

            vm.Run(compiler.compile());

            Console.ReadKey();

        }
    }
}
