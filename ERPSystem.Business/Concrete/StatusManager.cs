using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.StatusDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class StatusManager : IStatusService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StatusManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<StatusDTOResponse> AddAsync(StatusDTORequest RequestEntity)
        {
            var status = _mapper.Map<Status>(RequestEntity);
            var addedStatus = await _uow.StatusRepository.AddAsync(status);
            await _uow.SaveChangeAsync();
            StatusDTOResponse statusDTOResponse = _mapper.Map<StatusDTOResponse>(addedStatus.Entity);
            return statusDTOResponse;
        }

        public async Task DeleteAsync(StatusDTORequest RequestEntity)
        {
            var status = _mapper.Map<Status>(RequestEntity);
            await _uow.StatusRepository.RemoveAsync(status);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<StatusDTOResponse>> GetAllAsync(StatusDTORequest RequestEntity)
        {
            var dbStatuses =  await _uow.StatusRepository.GetAllAsync();
            List<StatusDTOResponse> statusDTOResponses = new();
            foreach (var dbStatus in dbStatuses)
            {
                statusDTOResponses.Add(_mapper.Map<StatusDTOResponse>(dbStatus));
            }
            return statusDTOResponses;
        }

        public async Task<StatusDTOResponse> GetAsync(StatusDTORequest RequestEntity)
        {
            var status = _mapper.Map<Status>(RequestEntity);
            var dbStatus = await _uow.StatusRepository.GetAsync(x=>x.Id==status.Id);
            StatusDTOResponse statusDTOResponse = _mapper.Map<StatusDTOResponse>(dbStatus);
            return statusDTOResponse;

        }

        public async Task UpdateAsync(StatusDTORequest RequestEntity)
        {
            var status = await _uow.StatusRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            status = _mapper.Map(RequestEntity,status);
            await _uow.StatusRepository.UpdateAsync(status);
            await _uow.SaveChangeAsync();
        }
    }
}
