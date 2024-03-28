using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNETReflection.Implementations
{
    internal interface ICustomAction
    {
        public string Name { get; }

        public void Execute(params object[] parameters);
    }
}
