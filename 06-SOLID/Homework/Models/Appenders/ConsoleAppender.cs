using Logger.Enums;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        private int messagesAppended;

        private ConsoleAppender()
        {
            messagesAppended = 0;
        }
        public ConsoleAppender(ILayout layout, Level level)
            : this()
        {
            Layout = layout;
            Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formattedMessage = string.Format(format
                , dateTime.ToString(dateFormat, CultureInfo.InvariantCulture)
                , level.ToString()
                , message);

            Console.WriteLine(formattedMessage);
            messagesAppended++;

        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
