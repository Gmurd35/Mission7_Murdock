using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Murdock.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }  // MovieId maps to the database MovieId column
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }  // CategoryId maps to the database CategoryId column
        public Category? Category { get; set; }

        [Required]
        public string Title { get; set; }  // Title is marked as required in the database schema

        [Required]
        public int Year { get; set; }  // Year is marked as required in the database schema

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }  // Edited is marked as required in the database schema

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }  // CopiedToPlex is marked as required in the database schema

        public string? Notes { get; set; }
    }
}
