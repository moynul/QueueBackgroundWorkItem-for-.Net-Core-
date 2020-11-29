using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueBackground.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreDbContext _CoreDbContext;

        public UserRepository(CoreDbContext coreDbContext)
        {
            _CoreDbContext = coreDbContext;
        }

        public async Task Add(User user)
        {
            try
            {
                await _CoreDbContext.Users.AddAsync(user);
                await _CoreDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(User user)
        {
            try
            {
                _CoreDbContext.Users.Update(user);
                await _CoreDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            User user = await _CoreDbContext.Users.FindAsync(id);
            if (user == null)
            {
                //return NotFound();
            }

            _CoreDbContext.Users.Remove(user);
            await _CoreDbContext.SaveChangesAsync();

            //return user;
        }
        public async Task<User> GetUserByid(int? id)
        {
            try
            {
                return await _CoreDbContext.Users.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            try
            {
                return  _CoreDbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
