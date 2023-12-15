using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_API_EF_Three_Tier.BLL.Exeptions
{
    internal class BadExtensionFileException : Exception
    {

        public BadExtensionFileException(string message) : base(message)
        {
            
        }
    }
}
