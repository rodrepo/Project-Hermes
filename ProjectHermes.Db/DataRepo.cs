using Microsoft.AspNet.Identity.EntityFramework;
using ProjectHermes.Db.Contracts;
using ProjectHermes.Db.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHermes.Db
{
    public class DataRepo : IDataRepo
    {
        #region Default
        private DataContext _db;

        public DataRepo(DataContext db)
        {
            _db = db;
        }

        public static DataRepo Create()
        {
            return new DataRepo(new DataContext());
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        #endregion

        #region Users

        public User GetUser(string userId)
        {
            return _db.Users.FirstOrDefault(u => u.Id == userId);
        }
        #endregion

        #region Roles
        public IdentityRole GetRoleById(string Id)
        {
            return _db.Roles.FirstOrDefault(u => u.Id == Id);
        }
        #endregion
    }
}
