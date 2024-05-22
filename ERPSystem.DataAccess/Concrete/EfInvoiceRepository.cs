﻿using ERPSystem.DataAccess.Abstract;
using ERPSystem.DataAccess.Concrete.DataManagement;
using ERPSystem.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Concrete
{
    public class EfInvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public EfInvoiceRepository(DbContext context) : base(context)
        {
        }
    }
}