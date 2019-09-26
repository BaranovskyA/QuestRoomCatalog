namespace DataLayer.Entities
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
        }

        public virtual DbSet<QuestsLogos> QuestsLogos { get; set; }
        public virtual DbSet<QuestsRooms> QuestsRooms { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestsLogos>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<QuestsRooms>()
                .HasMany(e => e.QuestsLogos)
                .WithRequired(e => e.QuestsRooms)
                .HasForeignKey(e => e.QuestRoomId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestsRooms>()
                .HasMany(e => e.Rating)
                .WithRequired(e => e.QuestsRooms)
                .HasForeignKey(e => e.QuestRoomId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);
        }
    }
}
