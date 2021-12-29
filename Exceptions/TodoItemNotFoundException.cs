using System;

namespace TodoApiDTO.Exceptions
{
    public class TodoItemNotFoundException : Exception
    {
        public TodoItemNotFoundException()
        {
        }

        public TodoItemNotFoundException(string message)
            : base(message)
        {
        }

        public TodoItemNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
