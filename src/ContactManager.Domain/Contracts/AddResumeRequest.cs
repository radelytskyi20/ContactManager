using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain.Contracts
{
    public record AddResumeRequest(
        [Required] string Name,
        [Required] DateOnly BirthDate,
        [Required] bool Married,
        [Phone] [Required] string Phone,
        [Required] decimal Salary);
}
