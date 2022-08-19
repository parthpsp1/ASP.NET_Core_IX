using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_CRUD_API_Repo_Pattern.Model
{
    public class Student
    {
        [Key]
        [MaxLength(3), MinLength(1)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(3), MinLength(1)]
        public int CollegeId { get; set; }
    }
}
