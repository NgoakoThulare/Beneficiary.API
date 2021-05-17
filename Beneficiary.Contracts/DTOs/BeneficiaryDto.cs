using System.ComponentModel.DataAnnotations;

namespace Beneficiary.Contracts.DTOs
{
    public class BeneficiaryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public string Reference { get; set; }
    }
}
