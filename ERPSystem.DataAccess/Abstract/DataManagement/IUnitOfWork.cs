using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; }
        IOfferRepository OfferRepository { get; }
        IProcessTypeRepository ProcessTypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IRequestRepository RequestRepository { get; }
        IRoleRepository RoleRepository { get; }
        IStatusRepository StatusRepository { get; }
        IStockDetailRepository StockDetailRepository { get; }
        IStockRepository StockRepository { get; }
        IUnitRepository UnitRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangeAsync();

    }
}
