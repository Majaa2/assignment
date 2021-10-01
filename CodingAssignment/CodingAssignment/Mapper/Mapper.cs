using AutoMapper;
using Model.Request;
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
            CreateMap<Model.Supplier, SupplierRequest>();
            CreateMap<Database.Supplier, SupplierRequest>();
            CreateMap<SupplierRequest, Database.Supplier>();

            CreateMap<Database.Category, Model.Category>();
            CreateMap<Model.Category, Database.Category>();
            CreateMap<Model.Category, CategoryRequest>();
            CreateMap<Database.Category, CategoryRequest>();
            CreateMap<CategoryRequest, Database.Category>();

            CreateMap<Database.Product, Model.Product>();
            CreateMap<Model.Product, Database.Product>();
            CreateMap<Model.Product, ProductRequest>();
            CreateMap<Database.Product, ProductRequest>();
            CreateMap<ProductRequest, Database.Product>();

            CreateMap<Database.Order, Model.Order>();
            CreateMap<Model.Order, Database.Order>();
            CreateMap<Model.Order, OrderRequest>();
            CreateMap<Database.Order, OrderRequest>();
            CreateMap<OrderRequest, Database.Order>();

            CreateMap<Database.OrderDetail, Model.OrderDetail>();
            CreateMap<Model.OrderDetail, Database.OrderDetail>();
            CreateMap<Model.OrderDetail, OrderDetailRequest>();
            CreateMap<Database.OrderDetail, OrderDetailRequest>();
            CreateMap<OrderDetailRequest, Database.OrderDetail>();
        }
    }
}
