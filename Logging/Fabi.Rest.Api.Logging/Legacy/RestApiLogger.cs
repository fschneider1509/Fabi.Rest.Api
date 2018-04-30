using System;
using Fabi.Rest.Api.Logging.Colors;
using Fabi.Rest.Api.Logging.Logging;
using Fabi.Rest.Api.Logging.Types;

namespace Fabi.Rest.Api.Logging.Legacy
{
    public class RestApiLogger : IRestApiLogger
    {
        public void Error(string message, object obj, Exception ex)
        {
            LogMessage(LoggingTypes.ERROR, message, obj, ex);
        }

        public void Error(string message, object obj)
        {
            LogMessage(LoggingTypes.ERROR, message, obj);
        }

        public void Error(string message, Exception ex)
        {
            LogMessage(LoggingTypes.ERROR, message, ex);
        }

        public void Error(string message) 
        {
            LogMessage(LoggingTypes.ERROR, message);
        }

        public void Info(string message, object obj)
        {
            LogMessage(LoggingTypes.INFO, message, obj);
        }

        public void Info(string message)
        {
            LogMessage(LoggingTypes.INFO, message);
        }

        public void Warning(string message, object obj)
        {
            LogMessage(LoggingTypes.WARNING, message, obj);
        }

        public void Warning(string message)
        {
            LogMessage(LoggingTypes.WARNING, message);
        }

        private void LogMessage(LoggingTypes type, string message, object obj = null, Exception ex = null) 
        {
            Console.ForegroundColor = LoggingColors.ColorFromLoggingType(type);
            Console.WriteLine($"[{Enum.GetName(type.GetType(), type)}] {message}");
            if(obj != null) 
            {
                Console.WriteLine($"[{Enum.GetName(type.GetType(), type)}] {obj.ToString()}");
            }
            if(ex != null) 
            {
                Console.WriteLine($"[{Enum.GetName(type.GetType(), type)}] {ex.Message} {ex.InnerException?.Message}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}