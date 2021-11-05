using Microsoft.EntityFrameworkCore;
using RoadRunner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core
{
    public class RoadRunnerContext : DbContext
    {
        public RoadRunnerContext(DbContextOptions<RoadRunnerContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    }
}
