using CodingAssignment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Interface
{
    public interface ISupplier
    {
        List<Supplier> Get();
        Supplier GetById(int id);
        Supplier Create(Model.Request.Supplier supplier);
    }
}
