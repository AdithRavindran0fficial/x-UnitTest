using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_test.Models;
using Unit_test.Repository;
using Unit_test.Services;

namespace X_UnitTest
{
    public  class UserServiceTest
    {
        private readonly Mock<IUserRepo> _userRepo;
        private readonly IUserService _userService;
        public UserServiceTest()
        {
            _userRepo = new Mock<IUserRepo>();
            _userService = new UserService(_userRepo.Object);
        }
        [Fact]
        public void  GetUsers_CallsGetUsersInRepo()
        {
             var newusers = new List<Users>
            {
                new Users{Id=1,Name="Adith",EmailAddress="Adith.com",Password="asdfghjkl"},
                new Users{Id=2,Name="Adith",EmailAddress="Adith.com",Password="asdfghjkl"}
            };
            _userRepo.Setup(rep=>rep.GetAll()).Returns(newusers);
            var result = _userService.GetUsers();
            Assert.NotNull(result);
            Assert.Equal(newusers.Count(), result.Count());
        }
        [Fact]
        public void GetUserByid_CallsGetUserByid()
        {
            var userid = 1;
            var expected = new Users { Id = 1, Name = "adith", EmailAddress = "Adith.com", Password = "Asdsfsdfd" };
            _userRepo.Setup(rep => rep.GetById(expected.Id)).Returns(expected);

            var reuslt = _userService.GetByIdUser(userid);
            Assert.NotNull(reuslt);
            Assert.Equal(expected.Id, reuslt.Id);
            Assert.Equal(expected.Name, reuslt.Name);
            Assert.Equal(expected.EmailAddress, reuslt.EmailAddress);
            Assert.Equal(expected.Password,reuslt.Password);
        }
        [Fact]
        public void GetNUllWhenCallingUSer()
        {
            var userid = 99;
            _userRepo.Setup(rep => rep.GetById(userid)).Returns((Users)null);

            var result = _userService.GetByIdUser(userid);
            Assert.Null(result);
        }
        [Fact]
        public void AddUser_CallsAdduserInRepo()
        {
            var user= new Users { Id = 1, Name = "adith", EmailAddress = "Adith.com", Password = "Asdsfsdfd" };

            _userService.Add(user);

            _userRepo.Verify(rep => rep.AddUser(user), Times.Once);

            

        }
        [Fact]
        public void UpdateUser_CallsUPdateUserinREpo()
        {
            var updated = new Users { Id = 1, Name = "adith", EmailAddress = "Adith.com", Password = "Asdsfsdfd" }; 
            _userService.Update(updated);
            _userRepo.Verify(rep=>rep.Update(updated), Times.Once);
        }
        [Fact]
        public void DeleteUser_CallsDELETEUserInRepo()
        {
            var id = 1;
            _userService.Delete(id);
            _userRepo.Verify(rep=>rep.Delete(id),Times.Once);
        }
    }
}
