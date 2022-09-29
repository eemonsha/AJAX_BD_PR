using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AJAX_BD_PR.Models;

namespace AJAX_BD_PR.Data
{
    public class AppBDContext : DbContext
    {
        public AppBDContext (DbContextOptions<AppBDContext> options)
            : base(options)
        {
        }

        public DbSet<AJAX_BD_PR.Models.divList> divList { get; set; }

        public DbSet<AJAX_BD_PR.Models.District> District { get; set; }

        public DbSet<AJAX_BD_PR.Models.Upazila> Upazila { get; set; }
    }
}
