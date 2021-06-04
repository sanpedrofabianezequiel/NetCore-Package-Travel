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
    public class PackageTest
    {

        IRepositoryWrapper _repoWrapper;
        RepositorySQL _Inyecction;
        [Fact]
        public void GetAllPackageTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new PackageController(repo);
            //Act
            var result = controller.Get();
            //Assert
            var foundValue = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_PackageByIdTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new PackageController(repo);
            //Act
            var result = controller.Get_PackageById(1);
            var foundValue = Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_PackageByDescriptionTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new PackageController(repo);
            //Act
            var result = controller.Get_PackageByDescription("hoteles");
            var foundValue = Assert.IsType<ActionResult<IEnumerable<Package>>>(result);
        }
    }
}
