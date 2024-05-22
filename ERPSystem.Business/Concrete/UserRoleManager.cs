using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.UserRoleDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserRoleManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UserRoleDTOResponse> AddAsync(UserRoleDTORequest RequestEntity)
        {
            UserRoleDTOResponse userRoleDTOResponse = new();
            var userRole = _mapper.Map<UserRole>(RequestEntity);

            var currentUserRole = await _uow.UserRoleRepository.GetAllAsync(x=>x.UserId==userRole.UserId&&x.RoleId==userRole.RoleId);

            if (currentUserRole.Count() > 0)
            {
                return userRoleDTOResponse;
            }
            else 
            {
                var addedUserRole = await _uow.UserRoleRepository.AddAsync(userRole);
                await _uow.SaveChangeAsync();
                userRoleDTOResponse = _mapper.Map<UserRoleDTOResponse>(addedUserRole.Entity);
            }
            return userRoleDTOResponse;
        }

        public async Task DeleteAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);

            var currentUserRole = await _uow.UserRoleRepository.GetAsync(x=>x.RoleId==userRole.RoleId&&x.UserId==userRole.UserId);


            await _uow.UserRoleRepository.RemoveAsync(currentUserRole);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<UserRoleDTOResponse>> GetAllAsync(UserRoleDTORequest RequestEntity)
        {
            List<UserRoleDTOResponse> userRoleDTOResponses = new();

            if (RequestEntity.UserId!=0)
            {

                var userRole = _mapper.Map<UserRole>(RequestEntity);
                var filterRoleUsers = await _uow.UserRoleRepository.GetAllAsync(x => x.UserId == userRole.UserId && x.IsActive == true, "Role", "User");

                foreach (var filterRoleUser in filterRoleUsers)
                {
                    userRoleDTOResponses.Add(_mapper.Map<UserRoleDTOResponse>(filterRoleUser));
                }

            }
            else if(RequestEntity.RoleId!=0)
            {
                var userRole = _mapper.Map<UserRole>(RequestEntity);
                var filterRoleUsers = await _uow.UserRoleRepository.GetAllAsync(x => x.RoleId == userRole.RoleId && x.IsActive == true, "Role", "User");

                foreach (var filterRoleUser in filterRoleUsers)
                {
                    userRoleDTOResponses.Add(_mapper.Map<UserRoleDTOResponse>(filterRoleUser));
                }
            }
            else
            {
                var noFilterRoleUsers = await _uow.UserRoleRepository.GetAllAsync(x => x.IsActive == true, "Role", "User");

                foreach (var noFilterRoleUser in noFilterRoleUsers)
                {
                    userRoleDTOResponses.Add(_mapper.Map<UserRoleDTOResponse>(noFilterRoleUser));
                }
            }

            return userRoleDTOResponses;
        }

        public async Task<UserRoleDTOResponse> GetAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);
            var dbUserRole = await _uow.UserRoleRepository.GetAsync(x => x.Id == userRole.Id, "Role", "User");

            UserRoleDTOResponse userRoleDTOResponse = _mapper.Map<UserRoleDTOResponse>(dbUserRole);
            return userRoleDTOResponse;
        }

        public async Task UpdateAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = await _uow.UserRoleRepository.GetAsync(x => x.Id == RequestEntity.Id);
            userRole = _mapper.Map(RequestEntity, userRole);
            await _uow.UserRoleRepository.UpdateAsync(userRole);
            await _uow.SaveChangeAsync();
        }
    }
}
