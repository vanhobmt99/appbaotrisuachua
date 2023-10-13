using CMMSBT.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMMSBT.Dao
{
    public interface ICrmFunctionService
    {
        Task<List<CrmFunction>> GetAll(int ParentID);
    }
    public class CrmFunctionService: ICrmFunctionService
    {
        private readonly CmmsbtContext _db;
        public CrmFunctionService(CmmsbtContext context)
        {
            this._db = context;
        }
        public async Task<List<CrmFunction>> GetAll(int ParentID) 
        {
            return await _db.CrmFunctions.Where(s => s.Parent.Equals(ParentID)).OrderBy(s => s.Order).ToListAsync();
        }
    }
}
