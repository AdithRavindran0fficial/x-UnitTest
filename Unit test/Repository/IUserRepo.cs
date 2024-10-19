
using Unit_test.Models;

namespace Unit_test.Repository
{
    public interface IUserRepo
    {
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        void AddUser(Users user);
        void Update(Users user);
        void Delete(int id);
    }
}
