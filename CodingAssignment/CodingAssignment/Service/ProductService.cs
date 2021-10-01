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
    public class ProductService : IProduct
    {
        private readonly NorthWindContext _ctx;
        private readonly IMapper _mapper;

        public ProductService(NorthWindContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public CAResponse Get(int? cId, int? sId)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var products = _ctx.Products.Include(x => x.Supplier).Include(x => x.Category).AsQueryable().ToList();
                if(cId != null)
                {
                    products = products.Where(x => x.CategoryId == cId).ToList();
                }
                if (sId != null)
                {
                    products = products.Where(x => x.SupplierId == sId).ToList();
                }
                response.Result = products;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching products!",
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
                var res = _ctx.Products.Where(x => x.ProductId == id).FirstOrDefault();
                if (res == null)
                {
                    response.ResponseCode = 204;
                    response.ResponseMessage = "No product has been found";
                }
                response.Result = res;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching a product!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Create(ProductRequest product)
        {
            var response = new CAResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Database.Product>(product);
                _ctx.Products.Add(entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while creating a product!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Edit(ProductRequest product)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var entity = GetById(product.ProductId).Result;
                _ctx.Set<Database.Product>().Attach(entity);
                _ctx.Set<Database.Product>().Update(entity);
                _mapper.Map(product, entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while editing a product!",
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
                response.ResponseMessage = "Product hass been successfully deleted!";
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while deleting a product!",
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
