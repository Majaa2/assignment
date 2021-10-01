using CodingAssignment.Database;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Interface
{
    public interface ISupplier
    {
        CAResponse Get();
        CAResponse GetById(int id);
        CAResponse Create(SupplierRequest supplier);
        CAResponse Edit(SupplierRequest supplier);
        CAResponse Delete(int id);
    }
}
