using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beneficiary.DataAccess.Model
{
    public class BeneficiaryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string AccountNumber { get; set; }

        [MaxLength(100)]
        public string Reference { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
