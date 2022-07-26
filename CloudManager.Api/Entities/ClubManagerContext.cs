using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CloudManager.Api.Entities
{
    public partial class ClubManagerContext : DbContext
    {
        public ClubManagerContext()
        {
        }

        public ClubManagerContext(DbContextOptions<ClubManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetType> AssetTypes { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeTeam> EmployeeTeams { get; set; } = null!;
        public virtual DbSet<EmployeeWorkplace> EmployeeWorkplaces { get; set; } = null!;
        public virtual DbSet<RegistryType> RegistryTypes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<StatusGroup> StatusGroups { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VAsset> VAssets { get; set; } = null!;
        public virtual DbSet<Workplace> Workplaces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ClubManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.Condition).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_Status");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_AssetType");

                entity.HasOne(d => d.UserCreatedNavigation)
                    .WithMany(p => p.AssetUserCreatedNavigations)
                    .HasForeignKey(d => d.UserCreated)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asset_User");

                entity.HasOne(d => d.UserLastModifiedNavigation)
                    .WithMany(p => p.AssetUserLastModifiedNavigations)
                    .HasForeignKey(d => d.UserLastModified)
                    .HasConstraintName("FK_Asset_User1");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.ToTable("AssetType");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Birthday).HasPrecision(0);

                entity.Property(e => e.DateCreated).HasPrecision(0);

                entity.Property(e => e.DateEmployeed).HasPrecision(0);

                entity.Property(e => e.EmployedTo).HasPrecision(0);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityUserId).HasMaxLength(450);

                entity.Property(e => e.LastModified).HasPrecision(0);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Oib).HasMaxLength(11);

                entity.HasOne(d => d.ClubNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Club)
                    .HasConstraintName("FK_Employee_Club");

                entity.HasOne(d => d.IdentityUser)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdentityUserId)
                    .HasConstraintName("FK_Employee_AspNetUsers");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Status");

                entity.HasOne(d => d.UserCreatedNavigation)
                    .WithMany(p => p.EmployeeUserCreatedNavigations)
                    .HasForeignKey(d => d.UserCreated)
                    .HasConstraintName("FK_Employee_User");

                entity.HasOne(d => d.UserLastModifiedNavigation)
                    .WithMany(p => p.EmployeeUserLastModifiedNavigations)
                    .HasForeignKey(d => d.UserLastModified)
                    .HasConstraintName("FK_Employee_User1");
            });

            modelBuilder.Entity<EmployeeTeam>(entity =>
            {
                entity.ToTable("EmployeeTeam");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.EmployeeTeams)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTeam_Employee");

                entity.HasOne(d => d.TeamNavigation)
                    .WithMany(p => p.EmployeeTeams)
                    .HasForeignKey(d => d.Team)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTeam_Team");
            });

            modelBuilder.Entity<EmployeeWorkplace>(entity =>
            {
                entity.ToTable("EmployeeWorkplace");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.EmployeeWorkplaces)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeWorkplace_Employee");

                entity.HasOne(d => d.WorkplaceNavigation)
                    .WithMany(p => p.EmployeeWorkplaces)
                    .HasForeignKey(d => d.Workplace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeWorkplace_Workplace");
            });

            modelBuilder.Entity<RegistryType>(entity =>
            {
                entity.ToTable("RegistryType");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_StatusGroup");

                entity.HasOne(d => d.RegistryType)
                    .WithMany(p => p.Statuses)
                    .HasForeignKey(d => d.RegistryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_RegistryType");
            });

            modelBuilder.Entity<StatusGroup>(entity =>
            {
                entity.ToTable("StatusGroup");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.League).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.ClubNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.Club)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_Club");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_Status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateCreated)
                    .HasPrecision(0)
                    .HasDefaultValueSql("((sysdatetimeoffset() AT TIME ZONE 'UTC'))");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityUserId).HasMaxLength(450);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_User_Club");

                entity.HasOne(d => d.IdentityUser)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdentityUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_AspNetUsers");
            });

            modelBuilder.Entity<VAsset>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAsset");

                entity.Property(e => e.AssetTypeLabel).HasMaxLength(50);

                entity.Property(e => e.AssetTypeName).HasMaxLength(50);

                entity.Property(e => e.Condition).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StatusColor).HasMaxLength(50);

                entity.Property(e => e.StatusGroupLabel).HasMaxLength(50);

                entity.Property(e => e.StatusGroupName).HasMaxLength(50);

                entity.Property(e => e.StatusLabel).HasMaxLength(50);

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.ToTable("Workplace");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(19, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
