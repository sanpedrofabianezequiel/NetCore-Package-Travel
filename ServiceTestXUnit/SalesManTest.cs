using Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using ServicioRest.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace ServiceTestXUnit
{
    public class SalesManTest
    {
        IRepositoryWrapper _repoWrapper;
        RepositorySQL _Inyecction;
        [Fact]
        public void GetAllSalesManTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new SalesmanController(repo);
            //Act
            var result = controller.Get();
            //Assert
            var foundValue = Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetSalesManByIdTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new SalesmanController(repo);
            //Act
            var result = controller.Get(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PostSalesManTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            CreateSalesmanDTO salesmanDTO = new CreateSalesmanDTO() { FullName="TestPost",UserName="UserTest1"};
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new SalesmanController(repo);
            //Act
            var result = controller.Post(salesmanDTO);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void DeleteSalesManTest()
        {
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new SalesmanController(repo);
            //Act
            var result = controller.Delete(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PostConfirmSaleTest()
        {
             CalculateCommissionRequestDTO requestDTO = new CalculateCommissionRequestDTO() {ClientTypeId=2,PassengersAmmount=2,TripDuration=3,TravelPackageIds= new List<int>{ 1 } };
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new SalesmanController(repo);
            //Act
            var result = controller.Confirm(requestDTO);
            var foundValue = Assert.IsType<OkResult>(result);
        }
    }
}
