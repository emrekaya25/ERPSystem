using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.StockDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class StockDetailManager : IStockDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StockDetailManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<StockDetailDTOResponse> AddAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            var stock = await _uow.StockRepository.GetAsync(x=>x.Id==stockDetail.StockId);

            if (RequestEntity.Quantity != 0 && RequestEntity.ProcessTypeId == 1)
            {
                stock.Quantity += RequestEntity.Quantity;
            }
            else if (RequestEntity.Quantity != 0 && (RequestEntity.ProcessTypeId == 2 || RequestEntity.ProcessTypeId == 4))
            {
                var stockQuantity = stock.Quantity - RequestEntity.Quantity;
                if (stockQuantity < 0)
                {
                    return new StockDetailDTOResponse();
                }
                stock.Quantity -= RequestEntity.Quantity;
            }
            await _uow.StockRepository.UpdateAsync(stock);
            await _uow.SaveChangeAsync();

            var addedStockDetail = await _uow.StockDetailRepository.AddAsync(stockDetail);
            await _uow.SaveChangeAsync();

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(addedStockDetail.Entity);
            return stockDetailDTOResponse;
        }

        public async Task DeleteAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            await _uow.StockDetailRepository.RemoveAsync(stockDetail);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<StockDetailDTOResponse>> GetAllAsync(StockDetailDTORequest RequestEntity)
        {
            if (RequestEntity.StockId!=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x=>x.StockId==stockDetail.StockId,"Stock.Product", "Stock.Unit", "ProcessType","Receiver","Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                var stockDetailDTOResponseList = stockDetailDTOResponses.OrderByDescending(x=>x.Id).ToList();
                return stockDetailDTOResponseList;
            }
            else if (RequestEntity.ProcessTypeId!=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x => x.ProcessTypeId == stockDetail.ProcessTypeId, "Stock.Product", "Stock.Unit", "ProcessType","Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                var stockDetailDTOResponseList = stockDetailDTOResponses.OrderByDescending(x => x.Id).ToList();
                return stockDetailDTOResponseList;
            }
            else if(RequestEntity.DelivererId !=0)
            {
                var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x => x.DelivererId == stockDetail.DelivererId, "Stock.Product","Stock.Unit", "ProcessType", "Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                var stockDetailDTOResponseList = stockDetailDTOResponses.OrderByDescending(x => x.Id).ToList();
                return stockDetailDTOResponseList;
            }
            else
            {
                
                var dbStockDetails = await _uow.StockDetailRepository.GetAllAsync(x=>true, "Stock.Product", "Stock.Unit", "ProcessType", "Receiver", "Deliverer");

                List<StockDetailDTOResponse> stockDetailDTOResponses = new();

                foreach (var dbStockDetail in dbStockDetails)
                {
                    stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(dbStockDetail));
                }
                var stockDetailDTOResponseList = stockDetailDTOResponses.OrderByDescending(x => x.Id).ToList();
                return stockDetailDTOResponseList;
            }
        }

        public async Task<StockDetailDTOResponse> GetAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = _mapper.Map<StockDetail>(RequestEntity);
            var dbStockDetail = await _uow.StockDetailRepository.GetAsync(x=>x.Id==stockDetail.Id, "Stock.Product", "Stock.Unit", "ProcessType", "Receiver", "Deliever");

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(dbStockDetail);

            return stockDetailDTOResponse;
        }

        public async Task UpdateAsync(StockDetailDTORequest RequestEntity)
        {
            var stockDetail = await _uow.StockDetailRepository.GetAsync(x=>x.Id==RequestEntity.Id);
            if (RequestEntity.StockId == 0)
            {
                RequestEntity.StockId = stockDetail.StockId;
            }
            if (RequestEntity.Quantity != 0)
            {
                stockDetail.Quantity += RequestEntity.Quantity;
            }
            stockDetail = _mapper.Map(RequestEntity,stockDetail);
            await _uow.StockDetailRepository.UpdateAsync(stockDetail);
            await _uow.SaveChangeAsync();
        }
    }
}
