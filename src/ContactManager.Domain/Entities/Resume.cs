namespace ContactManager.Domain.Entities
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        public bool Married { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }
    }
}
