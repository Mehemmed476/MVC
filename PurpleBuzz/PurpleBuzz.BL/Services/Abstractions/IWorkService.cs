using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.BL.Services.Abstractions;

public interface IWorkService
{
    Task AddWork(Work work);
    Task<List<Work>> GetAllWorksAsync();
    Task<Work> GetWorkAsync(int id);
    Task SoftDeleteWorkAsync(int id);
    Task RestoreWorkAsync(int id);
    Task DeleteWorkAsync(int id);
    Task UpdateWorkAsync(Work work);
}