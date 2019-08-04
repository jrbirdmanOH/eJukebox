using System;
using DebugEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data.Models
{
    public partial class eJukeboxContext : DbContext
    {
        public eJukeboxContext()
        {
        }

        public eJukeboxContext(DbContextOptions<eJukeboxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CouponUser> CouponUser { get; set; }
        public virtual DbSet<Gig> Gig { get; set; }
        public virtual DbSet<GigCoupon> GigCoupon { get; set; }
        public virtual DbSet<GigSong> GigSong { get; set; }
        public virtual DbSet<Performer> Performer { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongPerformer> SongPerformer { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.CouponImage).HasMaxLength(1);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<CouponUser>(entity =>
            {
                entity.HasKey(e => new { e.CouponId, e.UserId });

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.Issued).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouponUser_Coupon");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouponUser_User");
            });

            modelBuilder.Entity<Gig>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GigCoupon>(entity =>
            {
                entity.HasKey(e => new { e.GigId, e.CouponId });

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Gigs)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GigCoupon_Coupon");

                entity.HasOne(d => d.Gig)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.GigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GigCoupon_Gig");
            });

            modelBuilder.Entity<GigSong>(entity =>
            {
                entity.HasKey(e => new { e.GigId, e.SongId });

                entity.HasOne(d => d.Gig)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.GigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GigSong_Gig");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Gigs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GigSong_Song");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(140);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Set)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.SetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Set");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Song");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_User");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.Property(e => e.Ends).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Gig)
                    .WithMany(p => p.Sets)
                    .HasForeignKey(d => d.GigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Set_Gig");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.OriginalArtist).HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Song_ToCategory");
            });

            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(e => new { e.SongId, e.PerformerId });

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.PerformerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SongPerformer_Performer");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Performers)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SongPerformer_Song");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Added).HasColumnType("smalldatetime");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20);
            });
        }
    }
}
