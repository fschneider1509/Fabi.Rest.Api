using System;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.DataAccess.Legacy
{
    public abstract class RepositoryBase : IDisposable
    {
        IRestApiLogger _apiLogger;
        private bool _disposedValue = false;

        public RepositoryBase(IRestApiLogger apiLogger) 
        {
            _apiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
        }

        public virtual void Dispose()
        {
            _apiLogger.Info($"Disposing repository: {this.GetType().ToString()}");
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (var property in GetType().GetProperties())
                    {
                        var disposable = property.GetValue(this) as IDisposable;
                        disposable?.Dispose();
                    }
                }
                _disposedValue = true;
            }
        }
    }
}