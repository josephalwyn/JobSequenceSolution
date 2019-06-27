using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSequenceSolution
{
    class Constant
    {
        public const string CircularDependencies = "Error: Jobs can't have circular dependencies";
        public const string SelfDependencies = "Error: Job can't depend on themself";
    }
}
