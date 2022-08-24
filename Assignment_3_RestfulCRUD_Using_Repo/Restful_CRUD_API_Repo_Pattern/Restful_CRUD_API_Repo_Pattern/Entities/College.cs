﻿using System.ComponentModel.DataAnnotations;

namespace Restful_CRUD_API_Repo_Pattern.Entity
{
    public class College
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100), MinLength(2)]
        public string University { get; set; }

        [Required]
        [MaxLength(500), MinLength(2)]
        public string Address { get; set; }

        [Required]
        [MaxLength(500), MinLength(2)]
        public string District { get; set; }
    }
}
