using CodingAssignment.Database;
using Model;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingAssignment.Interface
{
    public interface ICategory
    {
        CAResponse Get();
        CAResponse GetById(int id);
        CAResponse Create(CategoryRequest category);
        CAResponse Edit(CategoryRequest category);
        CAResponse Delete(int id);
    }
}
