using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Giselle.DAL.Models
{
    public partial class GiselleContext : DbContext
    {
        public GiselleContext()
        {
        }

        public GiselleContext(DbContextOptions<GiselleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Leauge> Leauge { get; set; }
        public virtual DbSet<MoveType> MoveType { get; set; }
        public virtual DbSet<Moves> Moves { get; set; }
        public virtual DbSet<PlayerProfile> PlayerProfile { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-92NCKVU\\SQLEXPRESS01;Database=Giselle;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountId)
                    .HasName("UQ__Account__B19E45C8F4E05CEB")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("Account_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.PhoneNumberConfirmed)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SecurityStamp).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasIndex(e => e.ClubId)
                    .HasName("UQ__Club__FF602E980FC16AF2")
                    .IsUnique();

                entity.Property(e => e.ClubId).HasColumnName("Club_ID");

                entity.Property(e => e.ClubAddress)
                    .HasColumnName("Club_Address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ClubName)
                    .HasColumnName("Club_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Leauge>(entity =>
            {
                entity.HasIndex(e => e.LeaugeId)
                    .HasName("UQ__Leauge__BA8B75C60EB09B01")
                    .IsUnique();

                entity.Property(e => e.LeaugeId)
                    .HasColumnName("Leauge_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LeaugeName)
                    .HasColumnName("Leauge_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoveType>(entity =>
            {
                entity.ToTable("Move_Type");

                entity.HasIndex(e => e.MoveTypeId)
                    .HasName("UQ__Move_Typ__DE8DA891DB9230B3")
                    .IsUnique();

                entity.Property(e => e.MoveTypeId)
                    .HasColumnName("Move_Type_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MoveTypeDesc)
                    .HasColumnName("Move_Type_Desc")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Moves>(entity =>
            {
                entity.HasKey(e => e.MoveId)
                    .HasName("PK__Moves__A181E83AF512A283");

                entity.HasIndex(e => e.MoveId)
                    .HasName("UQ__Moves__A181E83BB2E56671")
                    .IsUnique();

                entity.Property(e => e.MoveId).HasColumnName("Move_ID");

                entity.Property(e => e.MoveDesc)
                    .HasColumnName("Move_Desc")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MoveName)
                    .HasColumnName("Move_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MoveTypeId).HasColumnName("Move_Type_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.HasOne(d => d.MoveType)
                    .WithMany(p => p.Moves)
                    .HasForeignKey(d => d.MoveTypeId)
                    .HasConstraintName("FK_Move_Type_ID");
            });

            modelBuilder.Entity<PlayerProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Player_P__206D919049796474");

                entity.ToTable("Player_Profile");

                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Player_P__206D9191244BA0B7")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PositionOne)
                    .HasColumnName("Position_One")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionThree)
                    .HasColumnName("Position_Three")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTwo)
                    .HasColumnName("Position_Two")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.TeamId)
                    .HasName("UQ__Team__02215C0B8661EAD9")
                    .IsUnique();

                entity.Property(e => e.TeamId)
                    .HasColumnName("Team_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClubId).HasColumnName("Club_ID");

                entity.Property(e => e.HeadCoach)
                    .HasColumnName("Head_Coach")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.HeadPhysio)
                    .HasColumnName("Head_Physio")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LeaugeId).HasColumnName("Leauge_ID");

                entity.Property(e => e.MoveId).HasColumnName("Move_ID");

                entity.Property(e => e.TeamName)
                    .HasColumnName("Team_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_Team_Club_ID");

                entity.HasOne(d => d.Leauge)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.LeaugeId)
                    .HasConstraintName("FK_Team_Leauge_ID");

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.MoveId)
                    .HasConstraintName("FK_Team_Move_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__User__206D9191635A27E1")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClubId).HasColumnName("Club_ID");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("Email_Address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("Home_Address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerProfileId).HasColumnName("Player_Profile_ID");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.UserTypeId).HasColumnName("User_Type_ID");

                entity.Property(e => e.WorkAddress)
                    .HasColumnName("Work_Address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Team_ID");

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Profile_ID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_User_Type_ID");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("User_Type");

                entity.HasIndex(e => e.UserTypeId)
                    .HasName("UQ__User_Typ__D3A592DD9E90E5BD")
                    .IsUnique();

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("User_Type_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserDesc)
                    .HasColumnName("User_Desc")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
