
using Unit_test.Models;
using Unit_test.Repository;

namespace Unit_test.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userrepo) 
        {
            _userRepo = userrepo;
        }
        public IEnumerable<Users> GetUsers()
        {
            return _userRepo.GetAll();
        }
        public Users GetByIdUser(int id)
        {
            return  _userRepo.GetById(id);
        }
        public void Add(Users user)
        {
             _userRepo.AddUser(user);

        }
        public void Update(Users user)
        {
            _userRepo.Update(user);
        }
        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }
    }
}
