using CMMSBT.Domain;
using CMMSBT.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CMMSBT.Dao
{
    public interface IUserRepository
    {
        Task<UserAdmin?> GetUser(LoginModel model);
        bool CheckLogin(string Username, string Password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly CmmsbtContext _dbcontext;        
        public UserRepository(CmmsbtContext dbcontext
            )
        {
            this._dbcontext = dbcontext;
        }
        public async Task<UserAdmin?> GetUser(LoginModel model)
        {
            return await _dbcontext.UserAdmins.SingleOrDefaultAsync(p => (
                                                           (p.Username == model.Username) &&
                                                           (p.Password == model.Password) &&
                                                           (p.Active.Equals(true)) &&
                                                           (p.Deleted.Equals(false))));
        }
        public bool CheckLogin(string Username, string Password)
        {

            var exists = _dbcontext.UserAdmins.SingleOrDefault(p => (
                                                           (p.Username == Username) &&
                                                           (p.Password == Password) &&
                                                           (p.Active.Equals(true)) &&
                                                           (p.Deleted.Equals(false))));
            if (exists != null)
                return true;
            else
                return false;

        }        

    }
}
