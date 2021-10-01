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
    public class CategoryService : ICategory
    {
        private readonly NorthWindContext _ctx;
        private readonly IMapper _mapper;

        public CategoryService(NorthWindContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public CAResponse Get()
        {
            var response = new CAResponse {
                ResponseCode = 200
            };
            try {
                var res = _ctx.Categories.AsQueryable().ToList();
                response.Result = res;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching categories!",
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
                var res = _ctx.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (res == null) {
                    response.ResponseCode = 204;
                    response.ResponseMessage = "No item has been found with the provided id!";
                }
                response.Result = res;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while fetching a category!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };

            }
            return response;
        }

            public CAResponse Create(CategoryRequest category)
        {
            var response = new CAResponse
            {
                ResponseCode = 201
            };
            try
            { 
                var entity = _mapper.Map<Database.Category>(category);
                _ctx.Categories.Add(entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }

            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while saving the category!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        public CAResponse Edit(CategoryRequest category)
        {
            var response = new CAResponse
            {
                ResponseCode = 200
            };
            try
            {
                var entity = GetById(category.CategoryId).Result;
                _ctx.Set<Database.Category>().Attach(entity);
                _ctx.Set<Database.Category>().Update(entity);
                _mapper.Map(category, entity);
                _ctx.SaveChanges();
                response.Result = entity;
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while editing a category!",
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
                response.ResponseMessage = "Category was deleted successfully!";
            }
            catch (Exception e)
            {
                response = new CAResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "An error occured while deleting a category!",
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