﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeSeries.MVC.Services.Exceptions
{
    public class DbConcurrencyException : Exception
    {
        public DbConcurrencyException(string message) : base(message)
        { }
    }
}
