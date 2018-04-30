using System;

namespace Fabi.Rest.Api.Logging.Logging
{
    public interface IRestApiLogger
    {
         void Info(string message, object obj);
         void Info(string message);
         void Warning(string message, object obj);
         void Warning(string message);
         void Error(string message, object obj, Exception ex);
         void Error(string message, object obj);
         void Error(string message, Exception ex);
         void Error(string message);
    }
}