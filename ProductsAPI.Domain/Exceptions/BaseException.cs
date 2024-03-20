using System;

namespace ProductsAPI.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string title, string message) : base(message)
        {
            Title = title;
            Message = message;
        }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
