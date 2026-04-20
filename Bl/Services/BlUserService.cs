using Bl.Api;
using Bl.Models;
using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{
    public class BlUserService : IBlUser
    {
        IDal dal;
        public BlUserService(IDal dal)
        {
            this.dal = dal;

        }
        public Task<bool> Create(BlUser t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BlUser t)
        {
            throw new NotImplementedException();
        }

        public Task<List<BlUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BlUser> GetById(int t)
        {
            throw new NotImplementedException();
        }
        public async Task<BlUser> GetByPassword(int t)
        {
            return Converts.ConvertFromUserToBlUser(dal.Users.GetByPassword(t).Result);
        }


        public Task<bool> Update(BlUser t)
        {
            throw new NotImplementedException();
        }
    }
}
