using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadith.WebApi.Exceptions
{
    public class AmbiguousException : Exception
    {
        public AmbiguousException(string message) : base(message) { }
    }
}
