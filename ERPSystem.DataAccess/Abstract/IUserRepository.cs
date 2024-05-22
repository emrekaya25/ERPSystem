using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
