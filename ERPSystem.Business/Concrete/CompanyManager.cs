using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.CompanyDTO;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CompanyManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CompanyDTOResponse> AddAsync(CompanyDTORequest RequestEntity)
        {
            var company = _mapper.Map<Company>(RequestEntity);
            await _uow.CompanyRepository.AddAsync(company);
            await _uow.SaveChangeAsync();
            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(company);
            return companyDTOResponse;
        }

        public async Task DeleteAsync(CompanyDTORequest RequestEntity)
        {
            var company = _mapper.Map<Company>(RequestEntity);
            await _uow.CompanyRepository.RemoveAsync(company);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<CompanyDTOResponse>> GetAllAsync(CompanyDTORequest RequestEntity)
        {
            List<CompanyDTOResponse> companyDTOResponses = new();

            if (RequestEntity.Id != 0)
            {
                var company = _mapper.Map<Company>(RequestEntity); /*Filtreleme yapmak istersek kullanbiliriz */

                var dbCompanies = await _uow.CompanyRepository.GetAllAsync(x => x.Id == RequestEntity.Id);

                foreach (var dbCompany in dbCompanies)
                {
                    companyDTOResponses.Add(_mapper.Map<CompanyDTOResponse>(dbCompany));
                }

            }
            else
            {
                var company = _mapper.Map<Company>(RequestEntity); /*Filtreleme yapmak istersek kullanbiliriz */

                var dbCompanies = await _uow.CompanyRepository.GetAllAsync(x => true);

                foreach (var dbCompany in dbCompanies)
                {
                    companyDTOResponses.Add(_mapper.Map<CompanyDTOResponse>(dbCompany));
                }
            }
            return companyDTOResponses;


        }

        public async Task<CompanyDTOResponse> GetAsync(CompanyDTORequest RequestEntity)
        {
            var company = _mapper.Map<Company>(RequestEntity);

            var dbCompany = await _uow.CompanyRepository.GetAsync(x=>x.Id==company.Id);

            CompanyDTOResponse companyDTOResponse = _mapper.Map<CompanyDTOResponse>(dbCompany);

            return companyDTOResponse;
        }

        public async Task UpdateAsync(CompanyDTORequest RequestEntity)
        {
            var company = await _uow.CompanyRepository.GetAsync(x=>x.Id==RequestEntity.Id);
            if (RequestEntity.Image == "string")
            {
                RequestEntity.Image = company.Image;
            }
            company = _mapper.Map(RequestEntity, company);

            await _uow.CompanyRepository.UpdateAsync(company);

            await _uow.SaveChangeAsync();
        }
    }
}
