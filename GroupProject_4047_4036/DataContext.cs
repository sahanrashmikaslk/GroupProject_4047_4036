using GroupProject_4047_4036.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_4047_4036
{
    public class DataContext : DbContext
    {
        public static readonly string workingDirectory = Directory.GetCurrentDirectory();
        public string projectDirectory = Directory.GetParent(workingDirectory).FullName;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=" +
          Path.Combine(projectDirectory, "Database2.db"));

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<StudentModule> StudentModules { get; set; }

     
    }
}
