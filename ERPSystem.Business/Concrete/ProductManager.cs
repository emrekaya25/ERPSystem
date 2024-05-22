using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.ProductDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ProductDTOResponse> AddAsync(ProductDTORequest RequestEntity)
        {
            var product = _mapper.Map<Product>(RequestEntity);
            var addedProduct = await _uow.ProductRepository.AddAsync(product);
            await _uow.SaveChangeAsync();

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(addedProduct.Entity);
            return productDTOResponse;
        }

        public async Task DeleteAsync(ProductDTORequest RequestEntity)
        {
            var product = _mapper.Map<Product>(RequestEntity);
            await _uow.ProductRepository.RemoveAsync(product);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<ProductDTOResponse>> GetAllAsync(ProductDTORequest RequestEntity)
        {
            if (RequestEntity.CategoryId>0)
            {
                var product = _mapper.Map<Product>(RequestEntity);
                var dbProducts = await _uow.ProductRepository.GetAllAsync(x=>true,"Category");

                List<ProductDTOResponse> productDTOResponses = new();

                foreach (var dbProduct in dbProducts)
                {
                    productDTOResponses.Add(_mapper.Map<ProductDTOResponse>(dbProduct));
                }

                return productDTOResponses;
            }
            else if (!(RequestEntity.BrandName.Contains("string")))
            {
                var product = _mapper.Map<Product>(RequestEntity);
                var dbProducts = await _uow.ProductRepository.GetAllAsync(x => x.BrandName.Contains($"{RequestEntity.BrandName}"), "Category");

                List<ProductDTOResponse> productDTOResponses = new();

                foreach (var dbProduct in dbProducts)
                {
                    productDTOResponses.Add(_mapper.Map<ProductDTOResponse>(dbProduct));
                }

                return productDTOResponses;
            }
            else if (!(RequestEntity.Name.Contains("string")))
            {
                var product = _mapper.Map<Product>(RequestEntity);
                var dbProducts = await _uow.ProductRepository.GetAllAsync(x => x.Name.Contains($"{RequestEntity.Name}"), "Category");

                List<ProductDTOResponse> productDTOResponses = new();

                foreach (var dbProduct in dbProducts)
                {
                    productDTOResponses.Add(_mapper.Map<ProductDTOResponse>(dbProduct));
                }

                return productDTOResponses;
            }
            else
            {
                var dbProducts = await _uow.ProductRepository.GetAllAsync(x=>true, "Category");

                List<ProductDTOResponse> productDTOResponses = new();

                foreach (var dbProduct in dbProducts)
                {
                    productDTOResponses.Add(_mapper.Map<ProductDTOResponse>(dbProduct));
                }

                return productDTOResponses;

            }
        }

        public async Task<ProductDTOResponse> GetAsync(ProductDTORequest RequestEntity)
        {
            var product = _mapper.Map<Product>(RequestEntity);
            var dbProduct = await _uow.ProductRepository.GetAsync(x=>x.Id==product.Id, "Category");

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(dbProduct);

            return productDTOResponse;
        }

        public async Task UpdateAsync(ProductDTORequest RequestEntity)
        {

            var product =await _uow.ProductRepository.GetAsync(x=>x.Id==RequestEntity.Id);
            if (RequestEntity.CategoryId == 0)
            {
                RequestEntity.CategoryId = product.CategoryId;
            }
            if (RequestEntity.Image == "string")
            {
                RequestEntity.Image = product.Image;
            }
            product = _mapper.Map(RequestEntity,product);
            await _uow.ProductRepository.UpdateAsync(product);
            await _uow.SaveChangeAsync();
        }
    }
}
