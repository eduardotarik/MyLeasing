using MyLeasing.Web.Data.Entities;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        public IQueryable GetAllWithUsers();
    }
}
