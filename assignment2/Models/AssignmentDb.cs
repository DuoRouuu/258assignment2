using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace assignment2.Models
{
    public partial class AssignmentDb : DbContext
    {
        public AssignmentDb()
            : base("name=AssignmentDb")
        {
        }

        public virtual DbSet<Stoty> Stoty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
