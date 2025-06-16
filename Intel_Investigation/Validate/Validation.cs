using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Validate
{
    static class Validation
    {
        public static bool IsBetween(int input, int limit)
        {
            if(input >= 0 && input < limit)
            {
                return true;
            }
            
            return false;
        }

        
    }
}
