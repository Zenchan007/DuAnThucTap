using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DuAnThucTap.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opt): base(opt) {
        }
        #region dbset
        public DbSet<Customer>?  Customers { get; set; }
        #endregion
    }
}
