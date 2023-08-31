using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunikime.Application.Util
{
    public class CompareSame
    {
        public static bool IsSame(string value1, string value2)
        {
            return value1.Equals(value2);
        }
    }
}