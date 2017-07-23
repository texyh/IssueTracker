using IssueTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Data.DbContexts
{
    public class IssueTrackerDbContext : DbContext
    {
        public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> options) 
            : base(options)
        { }
         
        public DbSet<Issue> Issues { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var issueEntry = modelBuilder.Entity<Issue>();
            issueEntry.ToTable("Issues");
            issueEntry.HasKey(x => x.Id);
            issueEntry.HasOne(x => x.Reporter).WithMany().HasForeignKey(x => x.ReporterId);
            issueEntry.HasOne(x => x.Resolver).WithMany().HasForeignKey(x => x.ResolverId);
            issueEntry.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);

            var departmentEntry = modelBuilder.Entity<Department>();
            departmentEntry.ToTable("Departments");
            departmentEntry.HasKey(x => x.Id);
            departmentEntry.HasOne(x => x.Admin).WithMany().HasForeignKey(x => x.AdminId);

            var userEntry = modelBuilder.Entity<User>();
            userEntry.ToTable("Users");
            userEntry.HasKey(x => x.Id);
        }
        
    }
}
