using DBEntityModule.Test;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkModule
{
    public class StepByStepDbContext:DbContext
    {
        public StepByStepDbContext(DbContextOptions<StepByStepDbContext> dbContextOptions):base(dbContextOptions)
        {
        }
        public DbSet<StudentTest> StudentTests { get; set; }
    }
}
