using DataContext;
using NSubstitute;
using Repository;
using System;
using System.Collections.Generic;
using Xunit;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestUserApi.Repository
{
    public class RepositoryTest
    {
        private UserContext userContext;
        private Repository<User> testObject;
        public RepositoryTest()
        {
            this.userContext = Substitute.For<UserContext>(new DbContextOptions<UserContext>());       
        }

        [Fact]
        public void Constructor_NullArgument_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository<User>(null));
        }

        [Fact]
        public void Add_CallWithUserEntity_AddSuccessfully()
        {
            //arrange
            var user = new User()
            {
                FirstName = "Zahra",
                LastName = "GhanbariNezhad",
                Email = "Z@gmail.com",
                Birthdate = "18/08/1984",
                Address = new Address() { Country = "Iran", State = "Tehran", City = "Tehran" },
            };
            var expectedUser = this.Seed(user);
            var dbSetMock = Substitute.For<DbSet<User>, IQueryable<User>>();

            ((IQueryable<User>)dbSetMock).Provider.Returns(expectedUser.Provider);
            ((IQueryable<User>)dbSetMock).Expression.Returns(expectedUser.Expression);
            ((IQueryable<User>)dbSetMock).ElementType.Returns(expectedUser.ElementType);
            ((IQueryable<User>)dbSetMock).GetEnumerator().Returns(expectedUser.GetEnumerator());
                    
            this.userContext.Set<User>().Returns(dbSetMock);
            this.testObject = new Repository<User>(this.userContext);         
         
             //act
            this.testObject.Add(user);

            //assert
            dbSetMock.Received(1).Add(user);            
        }

        public IQueryable<User> Seed(User user)
        {
            List<User> userList = new List<User> {
                user
                };
            return userList.AsQueryable<User>();
        }
        //??
        [Fact]
        public void GetDbContext_DbContextNotNull_ReturnDbContext()
        {
            //Arrange
            this.testObject = new Repository<User>(this.userContext);
            //acto


            DbContext actual =  this.testObject.GetDbContext();

            //Assert
            Assert.Equal(this.userContext, actual);

        }

    }
}
