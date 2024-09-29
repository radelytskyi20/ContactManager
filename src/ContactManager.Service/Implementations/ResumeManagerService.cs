using ContactManager.Domain.Constants;
using ContactManager.Domain.Contracts;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Implementations
{
    public class ResumeManagerService : IResumeManagerService
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeManagerService(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        public async Task AddAsync(string name, DateOnly birthDate, bool married, string phone, decimal salary)
        {
            var resume = new Resume
            {
                Name = name,
                BirthDate = birthDate,
                Married = married,
                Phone = phone,
                Salary = salary
            };

            await _resumeRepository.CreateAsync(resume);
        }

        public async Task<IReadOnlyCollection<Resume>> GetAllAsync() => await _resumeRepository.GetAllAsync();
        public async Task<Resume?> GetOneAsync(Guid id) => await _resumeRepository.GetOneAsync(id);
        public async Task<ServiceResponse> UpdateAsync(Guid id, string? name, DateOnly? birthDate, bool? married,
            string? phone, decimal? salary)
        {
            var resumeToUpdate = await _resumeRepository.GetOneAsync(id);
            if (resumeToUpdate is null)
            {
                return ServiceResponse.Failure(ErrorMessages.ResumeNotFound);
            }

            resumeToUpdate.Name = name ?? resumeToUpdate.Name;
            resumeToUpdate.BirthDate = birthDate ?? resumeToUpdate.BirthDate;
            resumeToUpdate.Married = married ?? resumeToUpdate.Married;
            resumeToUpdate.Phone = phone ?? resumeToUpdate.Phone;
            resumeToUpdate.Salary = salary ?? resumeToUpdate.Salary;

            await _resumeRepository.UpdateAsync(resumeToUpdate);
            return ServiceResponse.Success();
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var resumeToDelete = await _resumeRepository.GetOneAsync(id);
            if (resumeToDelete is null)
            {
                return ServiceResponse.Failure(ErrorMessages.ResumeNotFound);
            }

            await _resumeRepository.DeleteAsync(resumeToDelete);
            return ServiceResponse.Success();
        }
    }
}
