//using AutoMapper;
using Interfaces;

using NSubstitute;
//using User.API.Controllers;
using Xunit;

namespace TestUserApi.UserAPI
{
   public class UserControllerTest
    {
      //  private ILogger<UserController> loggerMock;
        private IUserService userServiceMock;
       // private IMapper mapperMock;

        public UserControllerTest()
        {
           // loggerMock = Substitute.For<ILogger<UserController>>();
            userServiceMock = Substitute.For<IUserService>();
           // mapperMock = Substitute.For<IMapper>();
        }

        [Fact]
        public void Constructor_CallWithNullArgument_ThrowException()
        {
           // Assert.Throws<System.ArgumentNullException>(() => new UserController(null, mapperMock, loggerMock));
        }


    }
}
