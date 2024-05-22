using ERPSystem.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Concrete.Context
{
    public class ERPContext :DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<ProcessType> ProcessType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockDetail> StockDetail { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {

                entity.ToTable("Sirket");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {

                entity.ToTable("Departman");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(x => x.Company).WithMany(x => x.Departments).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {

                entity.ToTable("Fatura");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
                entity.Property(e => e.InvoiceNo).IsRequired();
                entity.Property(e => e.SupplierName).HasMaxLength(200);
                entity.Property(e => e.SupplierPhone).HasMaxLength(20);
                entity.Property(e => e.SupplierAddress).HasMaxLength(150);
                entity.HasOne(x => x.Company).WithMany(x => x.Invoices).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {

                entity.ToTable("FaturaDetay");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e=>e.ProductName).HasMaxLength(500);
                entity.Property(e=>e.ProductDescription).HasMaxLength(2000);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e=>e.UnitPrice).IsRequired();
                entity.Property(e=>e.Sum).IsRequired();
                entity.HasOne(e => e.Invoice).WithMany(e => e.InvoiceDetails).HasForeignKey(e => e.InvoiceId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Offer>(entity =>
            {

                entity.ToTable("Teklif");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.SupplierName).HasMaxLength(500);
                entity.Property(e => e.Description).HasMaxLength(2000);
                entity.Property(e=>e.ApproverUserId).IsRequired(false);
                
                entity.HasOne(x => x.Status).WithMany(x => x.Offers).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.ApproverOfferUser).WithMany(x => x.ApproverOfferUsers).HasForeignKey(x => x.ApproverUserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Request).WithMany(x => x.Offers).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ProcessType>(entity =>
            {

                entity.ToTable("IslemTuru");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {

                entity.ToTable("Kategori");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {

                entity.ToTable("Urun");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.BrandName).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Request>(entity =>
            {

                entity.ToTable("Istek");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Title).HasMaxLength(500);
                entity.Property(e => e.Description).HasMaxLength(2000);
                entity.Property(e => e.ApproverId).IsRequired(false);

                entity.HasOne(x => x.Product).WithMany(x => x.Requests).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Unit).WithMany(x => x.Requests).HasForeignKey(x => x.UnitId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.RequesterUser).WithMany(x => x.RequesterUsers).HasForeignKey(x => x.RequesterId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.ApproverUser).WithMany(x => x.ApproverUsers).HasForeignKey(x => x.ApproverId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Status).WithMany(x => x.Requests).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Role>(entity =>
            {

                entity.ToTable("Rol");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);

            });

            modelBuilder.Entity<Status>(entity =>
            {

                entity.ToTable("Durum");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);


            });

            modelBuilder.Entity<Stock>(entity =>
            {

                entity.ToTable("Stok");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Quantity).IsRequired();


                entity.HasOne(x => x.Product).WithMany(x => x.Stocks).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Unit).WithMany(x => x.Stocks).HasForeignKey(x => x.UnitId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Department).WithMany(x => x.Stocks).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<StockDetail>(entity =>
            {

                entity.ToTable("StokDetay");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.DelivererId).IsRequired(false);
                entity.Property(e => e.ReceiverId).IsRequired(false);


                entity.HasOne(x => x.Stock).WithMany(x => x.StockDetails).HasForeignKey(x => x.StockId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.ProcessType).WithMany(x => x.StockDetails).HasForeignKey(x => x.ProcessTypeId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.Receiver).WithMany(x => x.RecieverStockDetails).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Deliverer).WithMany(x => x.DelivererStockDetails).HasForeignKey(x => x.DelivererId).OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Unit>(entity =>
            {

                entity.ToTable("Birim");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

            });

            modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("Kullanıcı");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(x => x.Department).WithMany(x => x.Users).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<UserRole>(entity =>
            {

                entity.ToTable("KullanıcıRol");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.AddedTime).HasColumnType("datetime");

                entity.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);

            });
        }

    }
}
