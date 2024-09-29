using ContactManager.Domain.Entities;

namespace ContactManager.Domain.Interfaces
{
    public interface IResumeRepository
    {
        Task CreateAsync(Resume resume, CancellationToken cancellationToken = default);
        Task<Resume?> GetOneAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Resume>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(Resume resume, CancellationToken cancellationToken = default);
        Task DeleteAsync(Resume resume, CancellationToken cancellationToken = default);
    }
}
