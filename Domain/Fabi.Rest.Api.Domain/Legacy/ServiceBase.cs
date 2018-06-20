using System;
using AutoMapper;
using Fabi.Rest.Api.DataAccess.UnitOfWork;
using Fabi.Rest.Api.Logging.Logging;

namespace Fabi.Rest.Api.Domain.Legacy
{
    public abstract class ServiceBase : IDisposable
    {
        protected readonly IRestApiLogger _apiLogger;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        private bool disposedValue = false;

        public ServiceBase(IRestApiLogger apiLogger, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _apiLogger = apiLogger ?? throw new ArgumentNullException(nameof(apiLogger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Dispose()
        {
            _apiLogger.Info($"Disposing the service {this.GetType().ToString()} ...");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}