﻿namespace UDFirstTask.DTO
{
    public class ImageDataDTO
    {
         public string ImagePath { get; set; } // Path to the image
        public IFormFile ImageFile { get; set; } // Actual image file
    }
}
