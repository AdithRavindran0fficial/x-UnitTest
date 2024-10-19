using Unit_test.Models;

namespace Unit_test.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
        Users GetByIdUser(int id);
        void Add(Users user);
        void Update(Users user);
        void Delete(int id);
        
    }
}
