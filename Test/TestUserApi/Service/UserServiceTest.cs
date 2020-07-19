using Microsoft.Extensions.Logging;
using Interfaces;
using Entity;
using NSubstitute;
using Service;
using System;
using Xunit;

namespace TestUserApi.Service
{
    public class UserServiceTest
    {
        private readonly IUnitOfWork<Entity.User> unitOfWorkMock;
        private readonly ILogger<UserService> loggerMock;

        private UserService testObject;
        public UserServiceTest()
        {
            this.unitOfWorkMock = Substitute.For<IUnitOfWork<User>>();
            this.loggerMock = Substitute.For<ILogger<UserService>>();
            this.testObject = new UserService(this.unitOfWorkMock, this.loggerMock);
        }

        [Fact]
        public void UserService_CallWithNullArgument_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(this.unitOfWorkMock, null));
            Assert.Throws<ArgumentNullException>(() => new UserService(null, loggerMock));

        }
      
        [Fact]
        public void UserRegistration_Call_Success()
        {
            //Arrange
            var user = new User()
            {
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new Address() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            IRepository<User> repository = Substitute.For<IRepository<User>>();
            this.unitOfWorkMock.GetRepository().Returns(repository);
            //Act
            var result = this.testObject.UserRegistration(user);
            //Assert
            unitOfWorkMock.Received(1).GetRepository();
            repository.Received(1).Add(user);
            unitOfWorkMock.GetRepository().DidNotReceive().Dispose();
            unitOfWorkMock.Received(1).Commit();
            Assert.True(result);
        }
        //??
        [Fact]
        public void UserRegistration_WithCommitReturnFalse_ReturnFalse()
        {
            //Arrange
            var user = new User()
            {
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new Address() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            IRepository<User> repository = Substitute.For<IRepository<User>>();
            this.unitOfWorkMock.GetRepository().Returns(repository);
            this.unitOfWorkMock.Commit().Returns(false);
            //Act
            var result = this.testObject.UserRegistration(user);
            //Assert
            unitOfWorkMock.Received(1).GetRepository();
            repository.Received(1).Add(user);
            Assert.False(result);
        }
    }
}
