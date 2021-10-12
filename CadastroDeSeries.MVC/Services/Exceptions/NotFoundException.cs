using System;

namespace CadastroDeSeries.MVC.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}
