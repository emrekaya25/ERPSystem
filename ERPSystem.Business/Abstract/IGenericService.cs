using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IGenericService<TRequest,TResponse> where TRequest : BaseRequestDTO where TResponse : BaseResponseDTO
    {
        public Task<TResponse> AddAsync(TRequest RequestEntity);
        public Task UpdateAsync(TRequest RequestEntity);
        public Task DeleteAsync(TRequest RequestEntity);
        public Task<List<TResponse>> GetAllAsync(TRequest RequestEntity);
        public Task<TResponse> GetAsync(TRequest RequestEntity);


    }
}
