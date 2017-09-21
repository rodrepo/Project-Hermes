using Microsoft.AspNet.Identity.EntityFramework;
using ProjectHermes.Db.Entities;
using System;
using System.Threading.Tasks;

namespace ProjectHermes.Db.Contracts
{
    public interface IDataRepo : IDisposable
    {
        bool SaveAll();
        Task<bool> SaveAllAsync();
        User GetUser(string userId);

        #region Roles
        IdentityRole GetRoleById(string Id);
        #endregion
    }
}
