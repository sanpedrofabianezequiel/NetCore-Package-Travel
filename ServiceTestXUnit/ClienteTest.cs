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
    public class ClienteTest
    {
        IRepositoryWrapper _repoWrapper;
        RepositorySQL _Inyecction;
        [Fact]
        public void Get_ClientTypesTest()
        {
            //Arrange
            _Inyecction = new RepositorySQL();
            RepositoryWrapper repo = new RepositoryWrapper(_Inyecction);
            var controller = new ClientController(repo);
            //Act
            var result = controller.Get_ClientTypes();
            //Assert
            var foundValue = Assert.IsType<ActionResult<List<Client_Type>>>(result);
        }
    }
}
