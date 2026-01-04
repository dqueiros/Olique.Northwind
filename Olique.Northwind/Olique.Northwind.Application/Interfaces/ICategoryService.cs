using Olique.Northwind.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olique.Northwind.Application.Interfaces
{
    public interface ICategoryService
    {
        public List<CategoryDto> GetCategories();
    }
}
