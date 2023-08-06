using JsonEntities.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEntities.DataAccessLayer.Data
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=TUNAHAN;initial catalog=JsonEntitiesDatabase;integrated Security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
