﻿using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    internal class PastaTypeRepository : Repository<PasteType>, IPastaTypeRepository
    {
        private ApplicationDbContext _db;
        public PastaTypeRepository(ApplicationDbContext db) : base(db) => _db = db;
    }
}
