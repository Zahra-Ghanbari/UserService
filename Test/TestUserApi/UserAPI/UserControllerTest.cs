using AutoMapper;
using Entity;
using Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using UserAPI.Controllers;
using Xunit;
using UserAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestUserApi.UserAPI
{
   public class UserControllerTest
    {
        private ILogger<UserController> loggerMock;
        private IUserService userServiceMock;
        private IMapper mapperMock;
        private UserController userController;

        public UserControllerTest()
        {
            loggerMock = Substitute.For<ILogger<UserController>>();
            userServiceMock = Substitute.For<IUserService>();
            mapperMock = Substitute.For<IMapper>();
            userController = new UserController(userServiceMock, mapperMock, loggerMock);
        }

        [Fact]
        public void Constructor_CallWithNullArgument_ThrowException()
        {
            Assert.Throws<System.ArgumentNullException>(() => new UserController(null, mapperMock, loggerMock));
            Assert.Throws<ArgumentNullException>(()=>new UserController(userServiceMock,null,loggerMock));
            Assert.Throws<ArgumentNullException>(()=>new UserController(userServiceMock, mapperMock, null));
        }

        [Fact]
        public void CreateUser_CallWithInvalidObject_ReturnBadRequest()
        {
            //Arrange
            userController.ModelState.AddModelError("FirstName", "You should provide a FirstName value.");
            var UserForCreationDto = new UserForCreationDto()
            {                
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new AddressForCreationDto() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            //Act
            var actual = userController.CreateUser(UserForCreationDto);
            //Assert
            Assert.IsType<BadRequestObjectResult>(actual);
        }

        [Fact]
        public void CreateUser_CallWithValidObject_ReturnOk()
        {
            //Arrange
           
            var userForCreationDto = new UserForCreationDto()
            {
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new AddressForCreationDto() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            var user = new User()
            {
                Id = new Guid(),
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new Address() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            mapperMock.Map<User>(userForCreationDto).Returns(user);
            this.userServiceMock.UserRegistration(user).Returns(true);
            //Act
            var actual = userController.CreateUser(userForCreationDto);
            //Assert
            Assert.IsType<OkResult>(actual);
        }

        [Fact]
        public void CreateUser_CallWithFailedUserService_Return500StatusCode()
        {
            //Arrange

            var userForCreationDto = new UserForCreationDto()
            {
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new AddressForCreationDto() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            var user = new User()
            {
                Id = new Guid(),
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new Address() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            mapperMock.Map<User>(userForCreationDto).Returns(user);
            this.userServiceMock.UserRegistration(user).Returns(false);
            //Act
            var actual = userController.CreateUser(userForCreationDto);
            //Assert
            Assert.IsType<ObjectResult>(actual);
        }
    }
}
