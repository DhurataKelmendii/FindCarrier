﻿using FindCarrier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Domain.FindCarrierDbContext
{
    public interface ICarrierDbContext
    {
        DbSet<Job> Job { get; set; }
        DbSet<University> Univerisity { get; set; }
    }
}
