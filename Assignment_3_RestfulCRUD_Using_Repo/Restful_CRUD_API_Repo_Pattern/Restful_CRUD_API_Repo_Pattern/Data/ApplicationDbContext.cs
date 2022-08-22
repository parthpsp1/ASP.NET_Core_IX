using Microsoft.EntityFrameworkCore;
using Restful_CRUD_API_Repo_Pattern.Entities;
using Restful_CRUD_API_Repo_Pattern.Entity;

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

        public DbSet<StudentEntity> Student_Table { get; set; }
        public DbSet<CollegeEntity> College_Table { get; set; }

    }
}
