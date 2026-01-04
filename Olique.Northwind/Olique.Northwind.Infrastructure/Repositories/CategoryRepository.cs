using Olique.Northwind.Domain.Entities;
using Olique.Northwind.Domain.Interfaces;
using Olique.Northwind.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olique.Northwind.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }
    }
}
