using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Business.Exceptions.Common
{
    public class IdNullOrZeroException : Exception
    {
        public string ParamName { get; set; }
        public IdNullOrZeroException(string? message, string paramName) : base(message)
        {
            ParamName = paramName ?? string.Empty;
        }
    }
}
