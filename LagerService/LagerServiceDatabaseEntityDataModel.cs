namespace LagerService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LagerServiceDatabaseEntityDataModel : DbContext
    {
        public LagerServiceDatabaseEntityDataModel()
            : base("name=LagerServiceDatabaseEntityDataModel")
        {
        }

        public virtual DbSet<Vara> Vara { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vara>()
                .Property(e => e.Namn)
                .IsUnicode(false);
        }
    }
}
