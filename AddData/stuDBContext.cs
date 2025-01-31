using Microsoft.EntityFrameworkCore;

namespace day2_wk.StuDB
{
    public class stuDBContext : DbContext
    {
        public stuDBContext(DbContextOptions<stuDBContext> options)
        { 
        
        }
    }
}
