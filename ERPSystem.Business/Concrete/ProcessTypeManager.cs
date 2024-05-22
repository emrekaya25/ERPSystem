using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.ProcessTypeDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class ProcessTypeManager : IProcessTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProcessTypeManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ProcessTypeDTOResponse> AddAsync(ProcessTypeDTORequest RequestEntity)
        {
            var processType = _mapper.Map<ProcessType>(RequestEntity);
            var addedProcessType = await _uow.ProcessTypeRepository.AddAsync(processType);
            await _uow.SaveChangeAsync();
            ProcessTypeDTOResponse processTypeDTOResponse = _mapper.Map<ProcessTypeDTOResponse>(addedProcessType.Entity);
            return processTypeDTOResponse;
        }

        public async Task DeleteAsync(ProcessTypeDTORequest RequestEntity)
        {
            var processType = _mapper.Map<ProcessType>(RequestEntity);
            await _uow.ProcessTypeRepository.RemoveAsync(processType);
            await _uow.SaveChangeAsync();

        }

        public async Task<List<ProcessTypeDTOResponse>> GetAllAsync(ProcessTypeDTORequest RequestEntity)
        {
            var processType = _mapper.Map<ProcessType>(RequestEntity);
            var processTypes = await _uow.ProcessTypeRepository.GetAllAsync();

            List<ProcessTypeDTOResponse> processTypeDTOResponses = new();

            foreach (var dbProcessType in processTypes)
            {
                processTypeDTOResponses.Add(_mapper.Map<ProcessTypeDTOResponse>(dbProcessType));
            }

            return processTypeDTOResponses;
        }

        public async Task<ProcessTypeDTOResponse> GetAsync(ProcessTypeDTORequest RequestEntity)
        {
            var processType = _mapper.Map<ProcessType>(RequestEntity);
            var dbProcessType = await _uow.ProcessTypeRepository.GetAsync(x=>x.Id==processType.Id);
            ProcessTypeDTOResponse processTypeDTOResponse = _mapper.Map<ProcessTypeDTOResponse>(dbProcessType);
            return processTypeDTOResponse;
        }

        public async Task UpdateAsync(ProcessTypeDTORequest RequestEntity)
        {

            var processType = await _uow.ProcessTypeRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            processType = _mapper.Map(RequestEntity,processType);
            await _uow.ProcessTypeRepository.UpdateAsync(processType);
            await _uow.SaveChangeAsync();
        }
    }
}
