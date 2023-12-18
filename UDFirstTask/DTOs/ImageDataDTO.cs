using System.ComponentModel.DataAnnotations;

namespace UDFirstTask.DTOs
{
    public class ImageDataDTO
    {
         public string ImagePath { get; set; } // Path to the image
        public IFormFile ImageFile { get; set; } // Actual image file
    }
}
