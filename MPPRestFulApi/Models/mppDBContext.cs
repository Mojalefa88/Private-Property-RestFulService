using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MPPRestFulApi.Models
{
    public partial class mppDBContext : DbContext
    {
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Advices> Advices { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<PropertyCategories> PropertyCategories { get; set; }
        public virtual DbSet<PropertyCategoryAdvices> PropertyCategoryAdvices { get; set; }
        public virtual DbSet<PropertyPropertyCategories> PropertyPropertyCategories { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=mppDB;Trusted_Connection=True;");
        //}

            public mppDBContext(DbContextOptions<mppDBContext> options) : base(options) { }
//        public BloggingContext(DbContextOptions<BloggingContext> options)
//    : base(options)
//{ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirmPassword")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Advices>(entity =>
            {
                entity.HasKey(e => e.AdvideId)
                    .HasName("PK_dbo.Advices");

                entity.Property(e => e.AdvideId).HasColumnName("advideID");

                entity.Property(e => e.AdiveDesc).HasColumnName("adiveDesc");

                entity.Property(e => e.Advice)
                    .IsRequired()
                    .HasColumnName("advice");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Properties>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK_dbo.Properties");

                entity.Property(e => e.PropertyId).HasColumnName("propertyID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Desc).IsRequired();

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            modelBuilder.Entity<PropertyCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_dbo.PropertyCategories");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category");
            });

            modelBuilder.Entity<PropertyCategoryAdvices>(entity =>
            {
                entity.HasKey(e => new { e.PropertyCategoryCategoryId, e.AdviceAdvideId })
                    .HasName("PK_dbo.PropertyCategoryAdvices");

                entity.HasIndex(e => e.AdviceAdvideId)
                    .HasName("IX_Advice_advideID");

                entity.HasIndex(e => e.PropertyCategoryCategoryId)
                    .HasName("IX_PropertyCategory_categoryID");

                entity.Property(e => e.PropertyCategoryCategoryId).HasColumnName("PropertyCategory_categoryID");

                entity.Property(e => e.AdviceAdvideId).HasColumnName("Advice_advideID");

                entity.HasOne(d => d.AdviceAdvide)
                    .WithMany(p => p.PropertyCategoryAdvices)
                    .HasForeignKey(d => d.AdviceAdvideId)
                    .HasConstraintName("FK_dbo.PropertyCategoryAdvices_dbo.Advices_Advice_advideID");

                entity.HasOne(d => d.PropertyCategoryCategory)
                    .WithMany(p => p.PropertyCategoryAdvices)
                    .HasForeignKey(d => d.PropertyCategoryCategoryId)
                    .HasConstraintName("FK_dbo.PropertyCategoryAdvices_dbo.PropertyCategories_PropertyCategory_categoryID");
            });

            modelBuilder.Entity<PropertyPropertyCategories>(entity =>
            {
                entity.HasKey(e => new { e.PropertyPropertyId, e.PropertyCategoryCategoryId })
                    .HasName("PK_dbo.PropertyPropertyCategories");

                entity.HasIndex(e => e.PropertyCategoryCategoryId)
                    .HasName("IX_PropertyCategory_categoryID");

                entity.HasIndex(e => e.PropertyPropertyId)
                    .HasName("IX_Property_propertyID");

                entity.Property(e => e.PropertyPropertyId).HasColumnName("Property_propertyID");

                entity.Property(e => e.PropertyCategoryCategoryId).HasColumnName("PropertyCategory_categoryID");

                entity.HasOne(d => d.PropertyCategoryCategory)
                    .WithMany(p => p.PropertyPropertyCategories)
                    .HasForeignKey(d => d.PropertyCategoryCategoryId)
                    .HasConstraintName("FK_dbo.PropertyPropertyCategories_dbo.PropertyCategories_PropertyCategory_categoryID");

                entity.HasOne(d => d.PropertyProperty)
                    .WithMany(p => p.PropertyPropertyCategories)
                    .HasForeignKey(d => d.PropertyPropertyId)
                    .HasConstraintName("FK_dbo.PropertyPropertyCategories_dbo.Properties_Property_propertyID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirmPassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subscribe).HasColumnName("subscribe");
            });
        }
    }
}