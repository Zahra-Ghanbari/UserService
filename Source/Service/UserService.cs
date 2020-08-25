using Interfaces;
using Microsoft.Extensions.Logging;
using Entity;
using System;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<User> _unitOfWork;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork<User> iUnitOfWork, ILogger<UserService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be a null object.");

            if (iUnitOfWork == null)
            {
                this._logger.LogError("Unit of work must be a Not-Null object");
                throw new ArgumentNullException("Unit of work must be a Not-Null object");
            }

            this._unitOfWork = iUnitOfWork;
        }

        public bool UserRegistration(User user)
        {
            if(user==null)
            {
                this._logger.LogError($"{nameof(user)} cannot be null.");
                return false;
            }
            _unitOfWork.GetRepository()?.Add(user);

            if (!_unitOfWork.Commit())
            {
                return false;
            }
           else return true;
        }
    }
}
