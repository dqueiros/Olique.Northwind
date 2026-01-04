using Olique.Northwind.Application.Dtos;
using Olique.Northwind.Application.Interfaces;
using Olique.Northwind.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olique.Northwind.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository
                .GetAll()
                .Select(o => new CategoryDto { CategoryID = o.CategoryID,
                                            CategoryName = o.CategoryName,
                                            Description = o.Description })
                .ToList();
        }
    }
}
