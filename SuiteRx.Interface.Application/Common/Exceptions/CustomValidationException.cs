using SuiteRx.Interface.Application.Common.Models;
using System;
using System.Collections.Generic;

namespace SuiteRx.Interface.Application.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; }

        public CustomValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<ValidationError>();
        }

        public CustomValidationException(IEnumerable<ValidationError> failures) : this()
        {
            Errors = failures;
        }

        public CustomValidationException(string message) : base(message)
        {
            Errors = new List<ValidationError>();
        }

        public CustomValidationException(string message, IEnumerable<ValidationError> failures) : base(message)
        {
            Errors = failures;
        }
    }
}
