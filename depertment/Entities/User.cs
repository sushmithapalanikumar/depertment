using Microsoft.EntityFrameworkCore;
namespace depertment.Entities
{
    public class User
    {

        private Angular_Developer_ProgramContext _context;
        public User()
        {
            _context = new Angular_Developer_ProgramContext();
        }

        public Task<bool> AddUser(UserRegister userDetail)
        {

            _context.UserRegisters.Add(userDetail);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
        public async Task<UserRegister> Authenticate(Userlogin userlogin)
        {
            var user = await _context.UserRegisters.FirstOrDefaultAsync(_user => _user.EmailAddress == userlogin.EmailAddress
            && _user.Password == userlogin.Password);
            if (user != null)
            {
                user.UserName = user.UserName; // Include the username in the response
            }


            return user;
        }
    }
}
