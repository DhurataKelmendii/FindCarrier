using FindCarrier.Models;
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

        public DbSet<Job> Jobs { get; set; }
    }
}
