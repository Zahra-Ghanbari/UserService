using System;
using Interfaces;
using Model;

namespace Service
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork<User> _unitOfWork;
        public UserService(IUnitOfWork<User> iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;            
        }   
        
        public bool UserRegistration(User user)
        {
            _unitOfWork.GetRepository().Add(user);
            _unitOfWork.Commit();
            return true;
        }
    }
}
