namespace dhimancars.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreModel : DbContext
    {
        public StoreModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Store2> Store2 { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .Property(e => e.CarModel)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.CarYear)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Price)
                .IsFixedLength();

            modelBuilder.Entity<Store2>()
                .Property(e => e.Colour)
                .IsFixedLength();

            modelBuilder.Entity<Store2>()
                .Property(e => e.Wheels)
                .IsFixedLength();

            modelBuilder.Entity<Store2>()
                .Property(e => e.Model)
                .IsFixedLength();
        }
    }
}
