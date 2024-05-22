﻿using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.Entities
{
    public class Invoice:BaseEntity
    {
        public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
        public Company Company { get; set; }
        public Int64 CompanyId { get; set; }
        public DateTime? InvoiceDate { get; set; } = null;
        public int InvoiceNo { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierMail { get; set; }

    }
}
