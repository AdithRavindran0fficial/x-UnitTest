using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_test.Controllers;
using Unit_test.Models;
using Unit_test.Services;

namespace X_UnitTest
{
    public class ControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;
        public ControllerTest()
        {

            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }
        [Fact]
        public void GetAllUsers_ReturnOKWIthUSers()
        {
            var expectedUsers = new List<Users>
            {
                new Users { Id = 1, Name = "John Doe", EmailAddress = "john@example.com",Password="addsfdsv" },
                new Users { Id = 2, Name = "Jane Smith", EmailAddress = "jane@example.com",Password="asdfdwedfefb" }
            };
            _userServiceMock.Setup(rep=>rep.GetUsers()).Returns(expectedUsers);

            var result = _userController.GetAll() as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void GetUsers_ReturnNUll()
        {
            int id = 99;
            _userServiceMock.Setup(rep => rep.GetByIdUser(id)).Returns((Users)null);

            var result = _userController.GetId(id) as NotFoundResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
        [Fact]
        public void GetUSer_returnOKwithUSer()
        {
            int id = 1;
            var expected = new Users { Id = 1, Name = "John Doe", EmailAddress = "john@example.com", Password = "addsfdsv" };
            _userServiceMock.Setup(rep=>rep.GetByIdUser(id)).Returns(expected);

            var result = _userController.GetId(id) as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode);
            Assert.Equal(expected, result.Value);
        }
        [Fact]
        public void addUSer_returnCreatedAtActionObject()
        {
            var user = new Users { Id = 1, Name = "John Doe", EmailAddress = "john@example.com", Password = "addsfdsv" };
            var result = _userController.Add_User(user) as CreatedAtActionResult;
            Assert.NotNull(result);
            Assert.Equal("GetId", result.ActionName);
            Assert.Equal(201,result.StatusCode);
        }
        [Fact]
        public void UpdateUser_returnNoContent()
        {
            int id = 1;
            var update =new Users { Id = 1, Name = "John Doe", EmailAddress = "john@example.com", Password = "addsfdsv" };
            _userServiceMock.Setup(rep => rep.Update(update));
            var result = _userController.Update(id, update) as NoContentResult;
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
        [Fact]
        public void DelteUser_ReturnNOcontent()
        {
            int id = 1;
            _userServiceMock.Setup(rep=>rep.Delete(id));
            var result = _userController.Delete(id) as NoContentResult;
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
        
    }
}
