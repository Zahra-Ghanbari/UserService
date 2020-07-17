using DataContext;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork;
using Xunit;

namespace TestUserApi.UnitOfWork
{
    public class UnitOfWorkTest
    {
        private readonly IRepository<User> repository;
        public UnitOfWorkTest()
        {
            this.repository=Substitute.For<IRepository<User>>();

        }
        //??
        [Fact]
        public void Commit_AddAnItemSuccessfully_ReturnOne()
        {
            //Arrange
            var userContextMock = Substitute.For<UserContext>(new DbContextOptions<UserContext>());
            this.repository.GetDbContext().Returns(userContextMock);

            //act
            int intActual = new UnitOfWork<User>(repository).Commit();

            //Assert 
            userContextMock.Received(1).SaveChanges();

            //??
            Assert.Equal(userContextMock.SaveChanges(),intActual);
        }
        //??
        [Fact]
        public void GetRepository_CheckFunctionalityOfMethod_ReturnRepository()
        {
            //Arrange
            IRepository<User> expected = repository;
            //Act
            IRepository<User> actual= new UnitOfWork<User>(repository).GetRepository();
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
