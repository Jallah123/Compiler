using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Token
    {
        public int LineNumber { get; set; }
        public int Position { get; set; }
        public int Partner { get; set; }
        public int Level { get; set; }
        public string Text { get; set; }
        public TokenType TokenType { get; set; }
    }
}
