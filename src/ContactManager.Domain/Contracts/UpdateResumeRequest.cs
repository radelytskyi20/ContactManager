using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain.Contracts
{
    public record UpdateResumeRequest(
        string? Name,
        DateOnly? BirthDate,
        bool? Married,
        [Phone] string? Phone,
        decimal? Salary);
}
