using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueueBackground.Models
{
    public interface IUserRepository
    {
        Task Add(User content);
        Task Update(User content);
        Task Delete(int id);
        //Task<User> GetUser(string id);
        Task<User> GetUserByid(int? id);
        Task<IEnumerable<User>> GetUser();
    }
}
