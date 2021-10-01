using CodingAssignment.Database;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Interface
{
    public interface IProduct
    {
        CAResponse Get(int? cId, int? sId);
        CAResponse GetById(int id);
        CAResponse Create(ProductRequest product);
        CAResponse Edit(ProductRequest product);
        CAResponse Delete(int id);
    }
}
