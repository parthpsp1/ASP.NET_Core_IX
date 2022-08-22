using Microsoft.EntityFrameworkCore;
using Restful_CRUD_API_Repo_Pattern.Entities;
using Restful_CRUD_API_Repo_Pattern.Entity;
using Restful_CRUD_API_Repo_Pattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student_Table { get; set; }
        public DbSet<College> College_Table { get; set; }

    }
}
