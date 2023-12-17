using System.ComponentModel.DataAnnotations;

namespace UDFirstTask.Models
{
    public class Information
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [MaxLength(50)]
        public string EnglishTitle { get; set; }
        [Required]
        [MaxLength(50)]
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string ImagePath { get; set; } // Image data
    }
}
