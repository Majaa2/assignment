using CodingAssignment.Database;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Interface
{
    public interface IOrder
    {
        CAResponse Get();
        CAResponse GetById(int id);
        CAResponse Create(OrderRequest order);
        CAResponse Edit(OrderRequest order);
        CAResponse Delete(int id);
    }
}
