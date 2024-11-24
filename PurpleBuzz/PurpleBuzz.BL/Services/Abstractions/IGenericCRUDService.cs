using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Abstractions;

public interface IGenericCRUDService
{
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<T> GetByIdAsync<T>(int id) where T : class;
    Task CreateAsync<T>(T entity) where T : BaseEntity;
    Task UpdateAsync<T>(T entity) where T : BaseEntity;
    Task DeleteAsync<T>(int id) where T : BaseEntity;
    Task SoftDeleteAsync<T>(int id) where T : BaseEntity;
    Task RestoreAsync<T>(int id) where T : BaseEntity;
    
}