using ContactManager.Domain.Contracts;
using ContactManager.Domain.Entities;

namespace ContactManager.Service.Interfaces
{
    public interface IResumeManagerService
    {
        Task AddAsync(string name, DateOnly birthDate, bool married, string phone, decimal salary);
        Task<IReadOnlyCollection<Resume>> GetAllAsync();
        Task<Resume?> GetOneAsync(Guid id);
        Task<ServiceResponse> UpdateAsync(Guid id, string? name, DateOnly? birthDate, bool? married, string? phone, decimal? salary);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
