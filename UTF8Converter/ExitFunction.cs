using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTF8Converter
{
    public class ExitFunction
    {
        public ExitFunction()
        {
            var f = new ProgramFunction("Exit", ExitProgram);
        }

        void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
