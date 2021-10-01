using AutoMapper;
using CodingAssignment.Database;
using CodingAssignment.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Service
{
    public class SupplierService: ISupplier
    {
        private readonly NorthWindContext _ctx;
        private readonly IMapper _mapper;

        public SupplierService(NorthWindContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public List<Supplier> Get()
        {
            return _ctx.Suppliers.AsQueryable().ToList();
        }

        public Supplier GetById(int id)
        {
            return _ctx.Suppliers.Where(x => x.SupplierId == id).Include(x => x.Products).FirstOrDefault();
        }

        public Supplier Create(Model.Request.Supplier supplier)
        {
            var entity = _mapper.Map<Supplier>(supplier);
            _ctx.Suppliers.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }
    }
}
