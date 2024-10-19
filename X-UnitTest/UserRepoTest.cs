
using Unit_test.Models;
using Unit_test.Repository;

namespace X_UnitTest
{
    public class UserRepoTest
    {
        private readonly UserRepo _userRepo;

        public UserRepoTest()
        {
            _userRepo = new UserRepo();

        }
        [Theory]
        [InlineData(1, true)]
        [InlineData(99, false)]
        public void GetUserById_returnExpectedResult(int id, bool userExist)
        {
            var user = _userRepo.GetById(id);
            if (userExist)
            {
                Assert.NotNull(user);
                Assert.Equal(id, user.Id);
            }
            else
            {
                Assert.Null(user);
            }

        }
        [Fact]
        public void GetUsers_ReturnsAllUser()
        {
            var users = _userRepo.GetAll();
            Assert.NotNull(users);
            Assert.Equal(2, users.Count());
        }
        [Fact]
        public void AddUser_ShouldAddUSer()
        {
            var newuser = new Users { Id = 1, Name = "Adith", EmailAddress = "Adith.com", Password = "asdfghjkl" };
            _userRepo.AddUser(newuser);
            var result = _userRepo.GetById(1);
            Assert.NotNull(result);
            Assert.Equal(newuser.Name, result.Name);
            Assert.Equal(newuser.EmailAddress, result.EmailAddress);
            Assert.Equal(newuser.Password, result.Password);

        }
        [Fact]
        public void Update_ShouldUpdateUSer()
        {
            var updateuser = new Users { Id = 1, Name = "adithUpdated", EmailAddress = "Adithupdate.com", Password = "updated" };
            _userRepo.Update(updateuser);
            var result = _userRepo.GetById(updateuser.Id);
            Assert.NotNull(result);
            Assert.Equal(result.Name, updateuser.Name);
            Assert.Equal(result.EmailAddress, updateuser.EmailAddress);
            Assert.Equal(result.Password, updateuser.Password);
        }
        [Fact]
        public void Delete_ShouldDeleteUSer()
        {
            var deleteUSer = new Users { Id = 1, Name = "adith", EmailAddress = "adith@.com", Password = "adithlndafn" };
            _userRepo.Delete(deleteUSer.Id);
            var check = _userRepo.GetById(deleteUSer.Id);
            Assert.Null(check);
        }
    }
}