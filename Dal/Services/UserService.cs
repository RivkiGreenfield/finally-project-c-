using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class UserService : IUsers
    {
        DbManager dbm;
        public UserService(DbManager dbm)
        {
            this.dbm = dbm;
        }
        public Task<bool> Create(User t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User t)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int t)
        {
            throw new NotImplementedException();
        }
        public async Task<User> GetByPassword(int t)
        {
            return dbm.Users.ToList().Find(x  => x.Password == t)?? throw new Exception("The customer isnt exist!!");
        }
        public Task<bool> Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
