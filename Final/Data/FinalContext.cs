using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final.Models;

namespace Final.Data
{
    public class FinalContext : DbContext
    {
        public FinalContext (DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public DbSet<Final.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<Final.Models.Visits> Visits { get; set; } = default!;
        public DbSet<Final.Models.Patient> Patient { get; set; } = default!;
        public DbSet<Final.Models.UserModel> UserModel { get; set; } = default!;
        
    }
}
