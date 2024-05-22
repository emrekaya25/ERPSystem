using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.DTO.StockDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<StockDTOResponse> AddAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            var addedStock = await _uow.StockRepository.AddAsync(stock);
            await _uow.SaveChangeAsync();

            // ilk girişte detay ekleme
            StockDetail stockDetail = new();
            stockDetail.StockId = addedStock.Entity.Id;
            stockDetail.Quantity = addedStock.Entity.Quantity;
            stockDetail.ProcessTypeId = 3;
            await _uow.StockDetailRepository.AddAsync(stockDetail);
            await _uow.SaveChangeAsync();


            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(addedStock.Entity);
            return stockDTOResponse;
        }

        public async Task DeleteAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);

            //stokla birlikte stok detay silme
            var stockDetails = await _uow.StockDetailRepository.GetAllAsync(x=>x.StockId == RequestEntity.Id);
            foreach (var item in stockDetails)
            {
                await _uow.StockDetailRepository.RemoveAsync(item);
            }
            await _uow.SaveChangeAsync();


            await _uow.StockRepository.RemoveAsync(stock);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<StockDTOResponse>> GetAllAsync(StockDTORequest RequestEntity)
        {
            if (RequestEntity.ProductId!=0)
            {
                var stock = _mapper.Map<Stock>(RequestEntity);
                var dbStocks =await _uow.StockRepository.GetAllAsync(x=>x.ProductId==stock.ProductId,"Product","Unit","Department.Company");

                List<StockDTOResponse> stockDTOResponses = new();
                foreach(var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
            else if (RequestEntity.DepartmentId>0)
            {
                var stock = _mapper.Map<Stock>(RequestEntity);
                var dbStocks = await _uow.StockRepository.GetAllAsync(x => x.Department.CompanyId == stock.DepartmentId, "Product", "Unit", "Department.Company");

                List<StockDTOResponse> stockDTOResponses = new();
                foreach (var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
            else
            {
                var dbStocks = await _uow.StockRepository.GetAllAsync(x => true, "Product", "Unit", "Department.Company");

                List<StockDTOResponse> stockDTOResponses = new();
                foreach (var dbStock in dbStocks)
                {
                    stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(dbStock));
                }
                return stockDTOResponses;
            }
        }

        public async Task<StockDTOResponse> GetAsync(StockDTORequest RequestEntity)
        {
            var stock = _mapper.Map<Stock>(RequestEntity);
            var dbStock = await _uow.StockRepository.GetAsync(x=>x.Id==stock.Id, "Product", "Unit", "Department.Company");
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(dbStock);
            return stockDTOResponse;

        }

        public async Task UpdateAsync(StockDTORequest RequestEntity)
        {
            var stock = await _uow.StockRepository.GetAsync(x => x.Id == RequestEntity.Id);
            stock = _mapper.Map(RequestEntity,stock);
            await _uow.StockRepository.UpdateAsync(stock);
            await _uow.SaveChangeAsync();
        }
    }
}
