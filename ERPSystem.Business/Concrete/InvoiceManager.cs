using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public InvoiceManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<InvoiceDTOResponse> AddAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);

            await _uow.InvoiceRepository.AddAsync(invoice);
            await _uow.SaveChangeAsync();

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(invoice);

            return invoiceDTOResponse;

        }

        public async Task DeleteAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);
            await _uow.InvoiceRepository.RemoveAsync(invoice);
            await _uow.SaveChangeAsync();
        }

        public async Task<List<InvoiceDTOResponse>> GetAllAsync(InvoiceDTORequest RequestEntity)
        {
            List<InvoiceDTOResponse> invoiceDTOResponses = new();
            if (RequestEntity.Id != 0)
            {
                var invoice = _mapper.Map<Invoice>(RequestEntity);
                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.Id == RequestEntity.Id&&x.IsActive==false,   "Company", "InvoiceDetails");
                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }
            }
            
             else if (RequestEntity.CompanyId!=0)
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.Company.Id == RequestEntity.CompanyId && x.IsActive == false, "Company","InvoiceDetails");

                

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                
            }
             else if (!(RequestEntity.SupplierName.Contains("string")))
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.SupplierName == invoice.SupplierName && x.IsActive == false, "Company", "InvoiceDetails");

               

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                

            }
            else
            {
                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x=>true, "Company", "InvoiceDetails");
                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }
                
            }
            return invoiceDTOResponses;


        }

        public async Task<List<InvoiceDTOResponse>> GetAllAsyncByDate(string date)
        {
            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            if (date=="string")
            {
                var invoices = await _uow.InvoiceRepository.GetAllAsync(x => true, "Company", "InvoiceDetails");


                foreach (var invoice in invoices)
                {
                    invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));

                }
            }
            else
            {
                string[] dates = date.Split('-');
                DateTime startDate = Convert.ToDateTime(dates[0]);
                DateTime endDate = Convert.ToDateTime(dates[1]);
                endDate = endDate.AddDays(1).AddSeconds(-1);

                var invoices = await _uow.InvoiceRepository.GetAllAsync(x => x.IsActive == true && x.InvoiceDate <= endDate && x.InvoiceDate >= startDate, "Company", "InvoiceDetails");

                
                foreach (var invoice in invoices)
                {
                    invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));

                }
            }

            

            return invoiceDTOResponseList;
        }

        public async Task<InvoiceDTOResponse> GetAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);

            var dbInvoice = await _uow.InvoiceRepository.GetAsync(x=>x.Id==invoice.Id, "Company", "InvoiceDetails");

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(dbInvoice);

            return invoiceDTOResponse;
        }

        public async Task UpdateAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = await _uow.InvoiceRepository.GetAsync(x=>x.Id == RequestEntity.Id);
            invoice = _mapper.Map(RequestEntity,invoice);

            await _uow.InvoiceRepository.UpdateAsync(invoice);

            await _uow.SaveChangeAsync();
        }
    }
}
