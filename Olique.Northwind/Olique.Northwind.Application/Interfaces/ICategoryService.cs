using Olique.Northwind.Application.Dtos;
using Olique.Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olique.Northwind.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryDto dto);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task UpdateAsync(int id, CategoryDto category);
        Task UpdateNameAsync(int id, string categoryName);
        Task DeleteAsync(int id);
    }
}
