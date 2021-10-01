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
    public class OrderService : IOrder
    {
        private readonly NorthWindContext _ctx;
        private readonly IMapper _mapper;

        public OrderService(NorthWindContext ctx, IMapper mapper)
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
                response.Result = _ctx.Orders.AsQueryable().OrderByDescending(o => o.OrderDate).ToList();
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching orders!",
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
                var order = _ctx.Orders.Where(x => x.OrderId == id).FirstOrDefault();
                var orderDetails = _ctx.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product).ToList();
                if (order != null) { 
                    order.OrderDetails = orderDetails;                 
                }
                else
                {
                    response.ResponseCode = 204;
                    response.ResponseMessage = "No order has been found!";
                }
                response.Result = order;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching an order!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Create(OrderRequest order)
        {
            var response = new CAResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Database.Order>(order);
                _ctx.Orders.Add(entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while creating an order!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

        public CAResponse Edit(OrderRequest order)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var entity = GetById(order.OrderId).Result;
                _ctx.Set<Database.Order>().Attach(entity);
                _ctx.Set<Database.Order>().Update(entity);
                _mapper.Map(order, entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while editing an order!",
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
                response.ResponseMessage = "Order has been deleted successfully";
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while deleting an order!",
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