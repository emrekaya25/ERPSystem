using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.Business.Utilities.Attributes;
using ERPSystem.Business.Utilities.Validation.CategoryValidator;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.CategoryDTO;
using ERPSystem.Entity.Entities;
using ERPSystem.Entity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<CategoryDTOResponse> AddAsync(CategoryDTORequest RequestEntity)
        {
            var category = _mapper.Map<Category>(RequestEntity);
            await _uow.CategoryRepository.AddAsync(category);
            await _uow.SaveChangeAsync();
            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
            return categoryDTOResponse;
        }

        public async Task DeleteAsync(CategoryDTORequest RequestEntity)
        {
            var category = _mapper.Map<Category>(RequestEntity);
            await _uow.CategoryRepository.RemoveAsync(category);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<CategoryDTOResponse>> GetAllAsync(CategoryDTORequest RequestEntity)
        {
            var category = _mapper.Map<Category>(RequestEntity); /*Filtreleme yapmak istersek kullanbiliriz */

            var dbCategories = await _uow.CategoryRepository.GetAllAsync(x => true);

            List<CategoryDTOResponse> categoryDTOResponses = new();

            foreach (var dbCategory in dbCategories)
            {
                categoryDTOResponses.Add(_mapper.Map<CategoryDTOResponse>(dbCategory));
            }
            return categoryDTOResponses;
        }

        public async Task<CategoryDTOResponse> GetAsync(CategoryDTORequest RequestEntity)
        {
            var category = _mapper.Map<Category>(RequestEntity);

            var dbCategory = await _uow.CategoryRepository.GetAsync(x => x.Id == category.Id);

            CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(dbCategory);

            return categoryDTOResponse;
        }

        public async Task UpdateAsync(CategoryDTORequest RequestEntity)
        {
            var category = await _uow.CategoryRepository.GetAsync(x=>x.Id==RequestEntity.Id);
            category = _mapper.Map(RequestEntity,category);

            await _uow.CategoryRepository.UpdateAsync(category);

            await _uow.SaveChangeAsync();
        }
    }
}
