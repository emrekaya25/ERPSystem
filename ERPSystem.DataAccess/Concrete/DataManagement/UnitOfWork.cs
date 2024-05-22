using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.DataAccess.Abstract;
using ERPSystem.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPSystem.DataAccess.Concrete.Context;

namespace ERPSystem.DataAccess.Concrete.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ERPContext _context;

        public EfUnitOfWork(ERPContext context)
        {

            _context = context;

            CompanyRepository = new EfCompanyRepository(_context);
            DepartmentRepository = new EfDepartmentRepository(_context);
            InvoiceRepository = new EfInvoiceRepository(_context);
            InvoiceDetailRepository = new EfInvoiceDetailRepository(_context);
            OfferRepository = new EfOfferRepository(_context);
            ProductRepository = new EfProductRepository(_context);
            RequestRepository = new EfRequestRepository(_context);
            RoleRepository = new EfRoleRepository(_context);
            StockRepository = new EfStockRepository(_context);
            StockDetailRepository = new EfStockDetailRepository(_context);
            UserRepository = new EfUserRepository(_context);
            UserRoleRepository = new EfUserRoleRepository(_context);
            ProcessTypeRepository = new EfProcessTypeRepository(_context);
            StatusRepository = new EfStatusRepository(_context);
            UnitRepository = new EfUnitRepository(_context);
            CategoryRepository = new EfCategoryRepository(_context);

        }

        public ICompanyRepository CompanyRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public IInvoiceRepository InvoiceRepository { get; }

        public IOfferRepository OfferRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IRequestRepository RequestRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public IStockRepository StockRepository { get; }

        public IStockDetailRepository StockDetailRepository { get; }

        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }

        public IProcessTypeRepository ProcessTypeRepository { get; }

        public IStatusRepository StatusRepository { get; }

        public IUnitRepository UnitRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public IInvoiceDetailRepository InvoiceDetailRepository {  get; }

        public Task<int> SaveChangeAsync()
        {
            foreach (var item in _context.ChangeTracker.Entries<BaseEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;

                    if (item.Entity.IsActive == false)
                    {
                        item.Entity.IsActive = true;
                    }

                }

            }

            return _context.SaveChangesAsync();
        }
    }
}
