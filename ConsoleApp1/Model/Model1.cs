using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Companii> Companii { get; set; }
        public virtual DbSet<Dolzhnosti> Dolzhnosti { get; set; }
        public virtual DbSet<Kandidati> Kandidati { get; set; }
        public virtual DbSet<Kontrakti> Kontrakti { get; set; }
        public virtual DbSet<Naviki> Naviki { get; set; }
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
                .Property(e => e.Naimenovanie)
                .IsUnicode(false);

            modelBuilder.Entity<Companii>()
                .Property(e => e.Familia_Directora)
                .IsUnicode(false);

            modelBuilder.Entity<Companii>()
                .Property(e => e.Imea_Directora)
                .IsUnicode(false);

            modelBuilder.Entity<Companii>()
                .Property(e => e.Otchestvo_Directora)
                .IsUnicode(false);

            modelBuilder.Entity<Companii>()
                .HasMany(e => e.Vakansii)
                .WithRequired(e => e.Companii)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dolzhnosti>()
                .Property(e => e.Nazvanie_dolzhnosti)
                .IsUnicode(false);

            modelBuilder.Entity<Dolzhnosti>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Dolzhnosti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidati>()
                .Property(e => e.Imia)
                .IsUnicode(false);

            modelBuilder.Entity<Kandidati>()
                .Property(e => e.Familia)
                .IsUnicode(false);

            modelBuilder.Entity<Kandidati>()
                .Property(e => e.Obrazovanie)
                .IsUnicode(false);

            modelBuilder.Entity<Kandidati>()
                .HasMany(e => e.Otklik)
                .WithRequired(e => e.Kandidati)
                .HasForeignKey(e => e.id_kondidata)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kandidati>()
                .HasMany(e => e.Sobesedovanie)
                .WithRequired(e => e.Kandidati)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kontrakti>()
                .Property(e => e.Zarplata)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Kontrakti>()
                .Property(e => e.Graphik_raboti)
                .IsFixedLength();

            modelBuilder.Entity<Naviki>()
                .Property(e => e.Nazvanie_navika)
                .IsUnicode(false);

            modelBuilder.Entity<Naviki>()
                .HasMany(e => e.NavikiKandidata)
                .WithRequired(e => e.Naviki)
                .HasForeignKey(e => e.ID_navika)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NavikiKandidata>()
                .HasMany(e => e.Kandidati)
                .WithRequired(e => e.NavikiKandidata)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sobesedovanie>()
                .Property(e => e.Rezultati_sobesedovania)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Imia)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Familia)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Otchestvo)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Adres)
                .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Kontrakti)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Sobesedovanie)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Parol)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vakansii>()
                .Property(e => e.Trebovania)
                .IsFixedLength();

            modelBuilder.Entity<Vakansii>()
                .Property(e => e.Zarplata)
                .HasPrecision(19, 4);

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
