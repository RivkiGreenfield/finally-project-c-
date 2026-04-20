using Bl.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Api
{
    public interface IBlUser:IBlCrud<BlUser>
    {
        public Task<BlUser> GetByPassword(int id);

    }
}
