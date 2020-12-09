namespace DealerProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bil> Bils { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Forhandler> Forhandlers { get; set; }
        public virtual DbSet<Kunde> Kundes { get; set; }
        public virtual DbSet<Medarbejder> Medarbejders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bil>()
                .Property(e => e.BilMaerke)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.BilModel)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.BilUdstyr)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.BilMotor)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Bil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.KundeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Forhandler>()
                .Property(e => e.ForhandlerNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Forhandler>()
                .Property(e => e.ForhandlerAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<Forhandler>()
                .Property(e => e.ForhandlerBy)
                .IsUnicode(false);

            modelBuilder.Entity<Forhandler>()
                .Property(e => e.ForhandlerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Forhandler>()
                .HasMany(e => e.Bils)
                .WithRequired(e => e.Forhandler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forhandler>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Forhandler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forhandler>()
                .HasMany(e => e.Medarbejders)
                .WithRequired(e => e.Forhandler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.KundeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Kunde)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.MedarbejderNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Medarbejder)
                .WillCascadeOnDelete(false);
        }
    }
}
