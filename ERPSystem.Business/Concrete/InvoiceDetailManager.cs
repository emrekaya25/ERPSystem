using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.InvoiceDetailDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class InvoiceDetailManager : IInvoiceDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public InvoiceDetailManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<InvoiceDetailDTOResponse> AddAsync(InvoiceDetailDTORequest RequestEntity)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(RequestEntity);

            invoiceDetail.Sum = invoiceDetail.Quantity * invoiceDetail.UnitPrice;
            var addedInvoiceDetail = await _uow.InvoiceDetailRepository.AddAsync(invoiceDetail);

            await _uow.SaveChangeAsync();

            InvoiceDetailDTOResponse invoiceDetailDTOResponse = _mapper.Map<InvoiceDetailDTOResponse>(addedInvoiceDetail.Entity);

            return invoiceDetailDTOResponse;
        }

        public async Task DeleteAsync(InvoiceDetailDTORequest RequestEntity)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(RequestEntity);
            await _uow.InvoiceDetailRepository.RemoveAsync(invoiceDetail);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<InvoiceDetailDTOResponse>> GetAllAsync(InvoiceDetailDTORequest RequestEntity)
        {
            List<InvoiceDetailDTOResponse> invoiceDetails = new();
            if (RequestEntity.InvoiceId != 0)
            {
                var invoiceDetail = _mapper.Map<InvoiceDetail>(RequestEntity);
                var details = await _uow.InvoiceDetailRepository.GetAllAsync(x=>x.InvoiceId == invoiceDetail.InvoiceId,"Invoice");

                foreach (var item in details)
                {
                    invoiceDetails.Add(_mapper.Map<InvoiceDetailDTOResponse>(item));
                }

                return invoiceDetails;
            }
            else
            {
                var invoiceDetail = _mapper.Map<InvoiceDetail>(RequestEntity);
                var details = await _uow.InvoiceDetailRepository.GetAllAsync(x => true, "Invoice");

                foreach (var item in details)
                {
                    invoiceDetails.Add(_mapper.Map<InvoiceDetailDTOResponse>(item));
                }

                return invoiceDetails;
            }
        }

        public async Task<InvoiceDetailDTOResponse> GetAsync(InvoiceDetailDTORequest RequestEntity)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(RequestEntity);
            var detail = await _uow.InvoiceDetailRepository.GetAsync(x=>x.Id == invoiceDetail.Id,"Invoice");
            var detailResponse = _mapper.Map<InvoiceDetailDTOResponse>(detail);
            return detailResponse;

        }

        public async Task UpdateAsync(InvoiceDetailDTORequest RequestEntity)
        {
            var detail = _mapper.Map<InvoiceDetail>(RequestEntity);
            var invoiceDetail = await _uow.InvoiceDetailRepository.GetAsync(x=>x.Id == detail.Id);
            invoiceDetail = _mapper.Map(detail,invoiceDetail);
            await _uow.InvoiceDetailRepository.UpdateAsync(invoiceDetail);
            await _uow.SaveChangeAsync();
        }
    }
}
