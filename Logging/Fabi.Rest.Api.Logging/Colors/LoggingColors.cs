using System;
using Fabi.Rest.Api.Logging.Types;

namespace Fabi.Rest.Api.Logging.Colors
{
    public static class LoggingColors
    {
        public static ConsoleColor ColorFromLoggingType(LoggingTypes type) 
        {
            switch(type)
            {
                case LoggingTypes.INFO:
                    return ConsoleColor.Green;
                case LoggingTypes.WARNING:
                    return ConsoleColor.Yellow;
                case LoggingTypes.ERROR:
                    return ConsoleColor.Red;
                case LoggingTypes.UNKNOWN:
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.Cyan;
            }
        }
    }
}