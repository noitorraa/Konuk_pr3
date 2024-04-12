using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp2.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public static Model1 model;
        public static Model.Model1 GetContext()
        {
            if (model == null)
            {
                model = new Model1();
            }
            return model;
        }
        public virtual DbSet<Companii> Companii { get; set; }
        public virtual DbSet<Dolzhnosti> Dolzhnosti { get; set; }
        public virtual DbSet<Kandidati> Kandidati { get; set; }
        public virtual DbSet<Kontrakti> Kontrakti { get; set; }
        public virtual DbSet<Navik> Navik { get; set; }
        public virtual DbSet<NavikiKandidata> NavikiKandidata { get; set; }
        public virtual DbSet<Otklik> Otklik { get; set; }
        public virtual DbSet<Sobesedovanie> Sobesedovanie { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vakansii> Vakansii { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companii>()
                .HasMany(e => e.Vakansii)
                .WithRequired(e => e.Companii)
                .HasForeignKey(e => e.ID_kompanii)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dolzhnosti>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Dolzhnosti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidati>()
                .Property(e => e.Telefon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Kandidati>()
                .HasMany(e => e.NavikiKandidata1)
                .WithRequired(e => e.Kandidati1)
                .HasForeignKey(e => e.ID_kandidata)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidati>()
                .HasMany(e => e.Otklik)
                .WithRequired(e => e.Kandidati)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidati>()
                .HasMany(e => e.Sobesedovanie)
                .WithRequired(e => e.Kandidati)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kontrakti>()
                .Property(e => e.Zarplata)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Navik>()
                .HasMany(e => e.NavikiKandidata)
                .WithRequired(e => e.Navik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NavikiKandidata>()
                .HasMany(e => e.Kandidati)
                .WithRequired(e => e.NavikiKandidata)
                .HasForeignKey(e => e.id_navikakondidata)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Telephon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Kontrakti)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Sobesedovanie)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vakansii>()
                .Property(e => e.Zarplata)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Vakansii>()
                .Property(e => e.Telephon)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Vakansii>()
                .HasMany(e => e.Otklik)
                .WithRequired(e => e.Vakansii)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vakansii>()
                .HasMany(e => e.Sobesedovanie)
                .WithRequired(e => e.Vakansii)
                .WillCascadeOnDelete(false);
        }
    }
}
