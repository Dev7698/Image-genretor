using Microsoft.EntityFrameworkCore;

namespace CroudeDemoMvc.Models
{
    public class EmpDataContext : DbContext
    {
        public EmpDataContext(DbContextOptions<EmpDataContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        
    }
}
