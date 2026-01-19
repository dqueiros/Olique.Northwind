using Olique.Northwind.Application.Dtos;
using Olique.Northwind.Domain.Entities;

namespace Olique.Northwind.Application.Mappings
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CategoryDto dto)
        {
            return new Category
            {
                CategoryID = dto.CategoryID,
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };
        }

        public static CategoryDto ToDto(this Category entity)
        {
            return new CategoryDto
            {
                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
        }

        public static IEnumerable<Category> ToEntityList(this IEnumerable<CategoryDto> dtos)
        {
            if (dtos == null)
                return Enumerable.Empty<Category>();

            return dtos.Select(dto => dto.ToEntity());
        }

        public static IEnumerable<CategoryDto> ToDtoList(this IEnumerable<Category> entities)
        {
            if (entities == null)
                return Enumerable.Empty<CategoryDto>();

            return entities.Select(entity => entity.ToDto());
        }

        public static void UpdateFromDto(this Category entity, CategoryDto dto)
        {
            entity.CategoryName = dto.CategoryName;
            entity.Description = dto.Description;
            entity.Picture = dto.Picture;
        }
    }
}
