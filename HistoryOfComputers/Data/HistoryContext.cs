using HistoryOfComputers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Data
{
    public class HistoryContext: DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext>options):base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<TimePeriod> TimePeriods { get; set; }
        //public DbSet<Favorite> Favorites { get; set; }
        //public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<TimePeriod>().ToTable("TimePeriod");
            //modelBuilder.Entity<Favorite>().ToTable("Favorite");
            //modelBuilder.Entity<Comment>().ToTable("Comment");

            ////Complex Data Model
            //modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            //modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //modelBuilder.Entity<Department>().ToTable("Department");

            ////Composite PK on CourseAssignment (CourseID, InstructorID)
            //modelBuilder.Entity<CourseAssignment>().HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}
