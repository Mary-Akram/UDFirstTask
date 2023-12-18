using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;


namespace UDFirstTask.DTOs
{
    public class NewInformationDTO
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*English Title is required")]
        [MaxLength(50, ErrorMessage = "*English Title cannot exceed 50 characters")]
        public string EnglishTitle { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "*العنوان بالعربي مطلوب")]
        [MaxLength(50, ErrorMessage = "*لا يمكن يزيد العنوان عن 50 عنصر")]
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }   
        public ImageDataDTO Image { get; set; } // Image data

    }
}
