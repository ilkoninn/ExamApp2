using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Business.Exceptions.Account
{
    public class UsedEmailException : Exception
    {
        public string ParamName { get; set; }
        public UsedEmailException(string? message, string paramName) : base(message)
        {
            ParamName = paramName ?? string.Empty;
        }

    }
}
