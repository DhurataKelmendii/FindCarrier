using FindCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindCarrier.Domain
{
    public class CarrierDbContext : DbContext
    {
        public CarrierDbContext(DbContextOptions<CarrierDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<University> University { get; set; }
    }
}
