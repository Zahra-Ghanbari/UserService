using DataContext;
using NSubstitute;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestUserApi.Repository
{
    public class RepositoryTest
    {
        private UserContext userContext;
        private Repository<Model.User> testObject;
        public RepositoryTest()
        {
            this.userContext = Substitute.For<UserContext>(new DbContextOptions<UserContext> ());
            this.testObject = new Repository<User>(this.userContext);
        }

        [Fact]
        public void Constructor_NullAugument_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository<User>(null));
        }

        [Fact(Skip ="TODO")]
        public void Add_CallWithUserEntity_AddSuccessfully()
        {
            User user = new User();
            user.FirstName = "test";
            var dbSetMock = Substitute.For<DbSet<User>>();
            this.userContext.Set<User>().Returns(dbSetMock);

            this.testObject.Add(user);


            dbSetMock.Received(1).Add(Arg.Is<User>( user));
        }
    }
}
