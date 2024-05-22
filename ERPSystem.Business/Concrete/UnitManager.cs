using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.UnitDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class UnitManager : IUnitService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UnitManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UnitDTOResponse> AddAsync(UnitDTORequest RequestEntity)
        {
            var unit = _mapper.Map<Unit>(RequestEntity);
            var addedUnit = await _uow.UnitRepository.AddAsync(unit);
            await _uow.SaveChangeAsync();
            UnitDTOResponse unitDTOResponse = _mapper.Map<UnitDTOResponse>(addedUnit.Entity);
            return unitDTOResponse;
        }

        public async Task DeleteAsync(UnitDTORequest RequestEntity)
        {
            var unit = _mapper.Map<Unit>(RequestEntity);
            await _uow.UnitRepository.RemoveAsync(unit);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<UnitDTOResponse>> GetAllAsync(UnitDTORequest RequestEntity)
        {
            var unit = _mapper.Map<Unit>(RequestEntity);
            var dbUnits = await _uow.UnitRepository.GetAllAsync(x=>x.IsActive ==true);

            List<UnitDTOResponse> unitDTOResponses = new();

            foreach (var dbUnit in dbUnits)
            {
                unitDTOResponses.Add(_mapper.Map<UnitDTOResponse>(dbUnit));
            }

            return unitDTOResponses;
        }

        public async Task<UnitDTOResponse> GetAsync(UnitDTORequest RequestEntity)
        {
            var unit = _mapper.Map<Unit>(RequestEntity);
            var dbUnit = await _uow.UnitRepository.GetAsync(x=>x.Id==unit.Id && x.IsActive==true);

            UnitDTOResponse unitDTOResponse = _mapper.Map<UnitDTOResponse>(dbUnit);
            return unitDTOResponse;
        }

        public async Task UpdateAsync(UnitDTORequest RequestEntity)
        {
            var unit = await _uow.UnitRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            unit = _mapper.Map(RequestEntity,unit);
            await _uow.UnitRepository.UpdateAsync(unit);
            await _uow.SaveChangeAsync();
        }
    }
}
