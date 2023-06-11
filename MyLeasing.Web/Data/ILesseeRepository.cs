using MyLeasing.Web.Data.Entities;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public interface ILesseeRepository : IGenericRepository<Lessee>
    {
        public IQueryable GetAllWithUsers();
    }
}
