using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.RequestValidator;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RequestManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        
        public async Task<RequestDTOResponse> AddAsync(RequestDTORequest RequestEntity)
        {
            if(RequestEntity.ApproverId == 0)
            {
                RequestEntity.ApproverId = null;
            }
            var request = _mapper.Map<Request>(RequestEntity);
            var addedRequest = await _uow.RequestRepository.AddAsync(request);
            await _uow.SaveChangeAsync();
            RequestDTOResponse requestDTOResponse =_mapper.Map<RequestDTOResponse>(addedRequest.Entity);
            return requestDTOResponse;
        }

        public async Task DeleteAsync(RequestDTORequest RequestEntity)
        {
            var request = _mapper.Map<Request>(RequestEntity);
            await _uow.RequestRepository.RemoveAsync(request);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<RequestDTOResponse>> GetAllAsync(RequestDTORequest RequestEntity)
        {
            List<RequestDTOResponse> requestDTOResponses = new();
            if (RequestEntity.StatusId!=0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x=>x.StatusId==request.StatusId, "RequesterUser", "ApproverUser", "Status","Product","Unit");

                

                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            else if (RequestEntity.ProductId != 0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x => x.ProductId == request.ProductId, "RequesterUser", "ApproverUser", "Status", "Product", "Unit");

                

                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            else if (RequestEntity.ApproverId != 0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x => x.ApproverId == request.ApproverId, "RequesterUser", "ApproverUser", "Status", "Product", "Unit");



                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
            }
            else if (RequestEntity.RequesterId != 0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x => x.RequesterId == request.RequesterId, "RequesterUser", "ApproverUser", "Status", "Product", "Unit");



                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
            }
            else if (RequestEntity.CompanyId != 0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x => x.RequesterUser.Department.CompanyId == RequestEntity.CompanyId, "RequesterUser", "ApproverUser", "Status", "Product", "Unit");



                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
            }
            else
            {
                var dbRequests = await _uow.RequestRepository.GetAllAsync(x=>true,"RequesterUser","ApproverUser", "Status", "Product", "Unit");

                var descList = dbRequests.OrderByDescending(x=>x.Id);

                foreach (var dbRequest in descList)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            return requestDTOResponses;
        }

        public async Task<RequestDTOResponse> GetAsync(RequestDTORequest RequestEntity)
        {
            var request = _mapper.Map<Request>(RequestEntity);

            var dbRequest = await _uow.RequestRepository.GetAsync(x=>x.Id==request.Id,"RequesterUser","ApproverUser", "Status", "Product", "Unit");
            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(dbRequest);
            return requestDTOResponse;

        }

        [ValidationFilter(typeof(RequestValidation))]
        public async Task UpdateAsync(RequestDTORequest RequestEntity)
        {

            var request = await _uow.RequestRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            if (RequestEntity.ApproverId == 0   )
            {
                RequestEntity.ApproverId = null;

            }
            else if (RequestEntity.RequesterId == 0)
            {
                RequestEntity.RequesterId = request.RequesterId;
            }
            else if ( RequestEntity.UnitId == 0 )
            {
                RequestEntity.UnitId = request.UnitId;
            }
            else if (RequestEntity.ProductId == 0)
            {
                RequestEntity.ProductId = request.ProductId;
            }

            request = _mapper.Map(RequestEntity,request);
            await _uow.RequestRepository.UpdateAsync(request);
            await _uow.SaveChangeAsync();
        }
    }
}
