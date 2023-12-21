using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrandMonitorTest.Models.Entities;

namespace BrandMonitorTest.Data
{
    public class BrandMonitorTestContext : DbContext
    {
        public BrandMonitorTestContext (DbContextOptions<BrandMonitorTestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<BrandMonitorTest.Models.Entities.TaskEntity> TaskEntity { get; set; } = default!;
    }
}
