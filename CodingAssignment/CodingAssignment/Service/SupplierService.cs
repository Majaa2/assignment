using AutoMapper;
using CodingAssignment.Database;
using CodingAssignment.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Model.CAResponse;

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

        public CAResponse Get()
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                response.Result = _ctx.Suppliers.AsQueryable().ToList();
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching suppliers!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse GetById(int id)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var res = _ctx.Suppliers.Where(x => x.SupplierId == id).Include(x => x.Products).FirstOrDefault();
                if(res == null)
                {
                    response.ResponseCode = 204;
                    response.ResponseMessage = "No supplier has been found!";
                }
                response.Result = res;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching a supplier!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Create(SupplierRequest supplier)
        {
            var response = new CAResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Database.Supplier>(supplier);
                _ctx.Suppliers.Add(entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while creating a supplier!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Edit(SupplierRequest supplier)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var entity = GetById(supplier.SupplierId).Result;
                _ctx.Set<Database.Supplier>().Attach(entity);
                _ctx.Set<Database.Supplier>().Update(entity);
                _mapper.Map(supplier, entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while editing a supplier!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Delete(int id)
        {
            var response = new CAResponse
            {
                ResponseCode = 202
            };
            try
            {
                _ctx.Remove(GetById(id));
                _ctx.SaveChanges();
                response.ResponseMessage = "Supplier has been successfully deleted!";
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while deleting a supplier!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

    }
}
