using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Olique.Northwind.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Recupera uma entidade pelo seu ID
        Task<T?> GetByIdAsync(int id);

        // Recupera todos os registros
        Task<IEnumerable<T>> GetAllAsync();

        // Permite buscas personalizadas usando LINQ (Ex: x => x.Nome == "Teste")
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Adiciona um novo registro
        Task AddAsync(T entity);

        // Atualiza um registro existente
        void Update(T entity);

        // Remove um registro
        void Remove(T entity);

        // Salva as alterações no banco de dados
        Task<int> SaveChangesAsync();
    }
}
