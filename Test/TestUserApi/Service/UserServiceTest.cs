using Interfaces;
using Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUserApi.Service
{
    public class UserServiceTest
    {
        private IUnitOfWork<User> unitOfWork;
        public UserServiceTest()
        {
            unitOfWork = Substitute.For<IUnitOfWork<User>>();
        }
        
    }
}
