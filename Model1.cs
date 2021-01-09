namespace DealerProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1NEW")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bil> Bil { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Forhandler> Forhandler { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Medarbejder> Medarbejder { get; set; }

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

            modelBuilder.Entity<Booking>()
                .Property(e => e.KundeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.KundeNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.ForhandlerNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BilModel)
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
                .HasMany(e => e.Bil)
                .WithRequired(e => e.Forhandler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forhandler>()
                .HasMany(e => e.Medarbejder)
                .WithRequired(e => e.Forhandler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.KundeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.MedarbejderNavn)
                .IsUnicode(false);
        }
    }
}
