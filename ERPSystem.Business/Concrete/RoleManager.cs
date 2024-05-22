using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.RoleDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class RoleManager : IRoleService 
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RoleManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<RoleDTOResponse> AddAsync(RoleDTORequest RequestEntity)
        {
            var role = _mapper.Map<Role>(RequestEntity);
            var addedRole = await _uow.RoleRepository.AddAsync(role);
            await _uow.SaveChangeAsync();
            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(addedRole.Entity);

            return roleDTOResponse;
        }

        public async Task DeleteAsync(RoleDTORequest RequestEntity)
        {
            var role = _mapper.Map<Role>(RequestEntity);
            await _uow.RoleRepository.RemoveAsync(role);
            await _uow.SaveChangeAsync();

        }

        public async Task<List<RoleDTOResponse>> GetAllAsync(RoleDTORequest RequestEntity)
        {
            var role = _mapper.Map<Role>(RequestEntity);

            var dbRoles = await _uow.RoleRepository.GetAllAsync();

            List<RoleDTOResponse> roleDTOResponses = new();

            foreach (var dbRole in dbRoles)
            {
                roleDTOResponses.Add(_mapper.Map<RoleDTOResponse>(dbRole));
            }
            return roleDTOResponses;
        }

        public async Task<RoleDTOResponse> GetAsync(RoleDTORequest RequestEntity)
        {
            var role = _mapper.Map<Role>(RequestEntity);
            var dbRole = await _uow.RoleRepository.GetAsync(x=>x.Id==role.Id);

            RoleDTOResponse roleDTOResponse = _mapper.Map<RoleDTOResponse>(dbRole);
            return roleDTOResponse;
        }

        public async Task UpdateAsync(RoleDTORequest RequestEntity)
        {
            var role = await _uow.RoleRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            role = _mapper.Map(RequestEntity,role);
            await _uow.RoleRepository.UpdateAsync(role);
            await _uow.SaveChangeAsync();
        }
    }
}
