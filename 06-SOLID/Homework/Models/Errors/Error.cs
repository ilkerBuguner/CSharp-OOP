using System;
using Logger.Enums;
using Logger.Models.Contracts;

namespace Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            DateTime = dateTime;
            Message = message;
            Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
