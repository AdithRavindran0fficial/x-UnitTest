
using Unit_test.Models;

namespace Unit_test.Repository
{
    public class UserRepo : IUserRepo
    {
        private List<Users> _users;
        public UserRepo()
        {
            _users = new List<Users>
            {
                new Users{Id=1,Name="Adith",EmailAddress="Adith.com",Password="asdfghjkl"},
                new Users{Id=2,Name="Adithcss",EmailAddress="Aditsxsh.com",Password="assxsxdfghjkl"}
            };
        }

       public  IEnumerable<Users> GetAll()
        {
            return _users;

        }
        public Users GetById(int id)
        {
            return _users.FirstOrDefault(us=>us.Id == id);
           
        }
        public void AddUser(Users user)
        {
            _users.Add(user);

        }
        public void Update(Users user)
        {
            var exist = GetById(user.Id);
            if(exist!= null)
            {
               
                exist.EmailAddress = user.EmailAddress;
                exist.Name = user.Name;
                exist.Password = user.Password;
            }
        }
        public void Delete(int id)
        {
            var user = GetById(id);
            if(user!= null)
            {
                _users.Remove(user);
            }
        }
    }
}
