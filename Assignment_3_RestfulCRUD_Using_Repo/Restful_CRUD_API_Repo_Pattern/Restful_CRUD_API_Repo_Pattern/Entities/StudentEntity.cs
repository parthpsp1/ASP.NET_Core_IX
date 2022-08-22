using System;
using System.ComponentModel.DataAnnotations;

namespace Restful_CRUD_API_Repo_Pattern.Entities
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2), EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50), MinLength(2), Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CollegeId { get; set; }
    }

}
