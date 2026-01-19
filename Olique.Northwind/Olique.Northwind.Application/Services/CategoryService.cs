using Olique.Northwind.Application.Dtos;
using Olique.Northwind.Application.Interfaces;
using Olique.Northwind.Application.Mappings;
using Olique.Northwind.Domain.Entities;
using Olique.Northwind.Domain.Interfaces;

namespace Olique.Northwind.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(CategoryDto dto)
        {
            var entity = dto.ToEntity();

            await _categoryRepository.AddAsync(entity);
            await _categoryRepository.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var entities = await _categoryRepository.GetAllAsync();

            if (entities == null)
                return Enumerable.Empty<CategoryDto>();

            return entities.ToDtoList();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return entity.ToDto();
        }

        public async Task UpdateAsync(int id, CategoryDto dto)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            existing.UpdateFromDto(dto);

            await _categoryRepository.UpdateAsync(existing);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateNameAsync(int id, string categoryName)
        {
            var existing = await _categoryRepository.GetByIdAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            existing.CategoryName = categoryName;

            await _categoryRepository.UpdateAsync(existing);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
