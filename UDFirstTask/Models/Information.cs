using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UDFirstTask.Models
{
    public class Information
    {
        [Key]
        public int InformationId { get; set; } // Primary Key

        [Required]
        public string EnglishTitle { get; set; }

        [Required]
        public string ArabicTitle { get; set; }

        [Required]
        public string EnglishDescription { get; set; }

        [Required]
        public string ArabicDescription { get; set; }

        public string ImagePath { get; set; }
    }

}
