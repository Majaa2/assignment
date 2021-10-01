using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Database.Supplier, Model.Supplier>();
            CreateMap<Model.Supplier, Database.Supplier>();
            CreateMap<Model.Supplier, Model.Request.Supplier>();
            CreateMap<Database.Supplier, Model.Request.Supplier>();
            CreateMap<Model.Request.Supplier, Database.Supplier>();

            CreateMap<Database.Category, Model.Category>();
            CreateMap<Model.Category, Database.Category>();
            CreateMap<Model.Category, Model.Request.Category>();
            CreateMap<Database.Category, Model.Request.Category>();
            CreateMap<Model.Request.Category, Database.Category>();

            CreateMap<Database.Product, Model.Product>();
            CreateMap<Model.Product, Database.Product>();
            CreateMap<Model.Product, Model.Request.Product>();
            CreateMap<Database.Product, Model.Request.Product>();
            CreateMap<Model.Request.Product, Database.Product>();

            CreateMap<Database.Order, Model.Order>();
            CreateMap<Model.Order, Database.Order>();
            CreateMap<Model.Order, Model.Request.Order>();
            CreateMap<Database.Order, Model.Request.Order>();
            CreateMap<Model.Request.Order, Database.Order>();

            CreateMap<Database.OrderDetail, Model.OrderDetail>();
            CreateMap<Model.OrderDetail, Database.OrderDetail>();
            CreateMap<Model.OrderDetail, Model.Request.OrderDetail>();
            CreateMap<Database.OrderDetail, Model.Request.OrderDetail>();
            CreateMap<Model.Request.OrderDetail, Database.OrderDetail>();
        }
    }
}
