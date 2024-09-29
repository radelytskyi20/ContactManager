using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Persistence.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ResumeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Resume resume, CancellationToken cancellationToken = default)
        {
            await _dbContext.Resumes.AddAsync(resume, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Resume>> GetAllAsync(CancellationToken cancellationToken = default) => await _dbContext.Resumes.ToListAsync(cancellationToken);
        public async Task<Resume?> GetOneAsync(Guid id, CancellationToken cancellationToken = default) => await _dbContext.Resumes.FindAsync(id, cancellationToken);
        public async Task UpdateAsync(Resume resume, CancellationToken cancellationToken = default)
        {
            _dbContext.Resumes.Update(resume);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Resume resume, CancellationToken cancellationToken = default)
        {
            _dbContext.Resumes.Remove(resume);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
