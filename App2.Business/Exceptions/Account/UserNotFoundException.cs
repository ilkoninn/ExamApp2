﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App2.Business.Exceptions.Account;
using System.Threading.Tasks;

namespace App2.Business.Exceptions.Account
{
    public class UserNotFoundException : Exception
    {
        public string ParamName { get; set; }
        public UserNotFoundException(string? message, string paramName) : base(message)
        {
            ParamName = paramName ?? string.Empty;
        }
    }
}
