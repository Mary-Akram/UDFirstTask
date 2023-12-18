namespace UDFirstTask.HelperMethods
{
    public class ImageHelper
    {
        public static (bool isValid, string errorMessage) ValidateImageFile(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif")
                {
                    return (false, "*Please upload a valid image file.");
                }
            }

            return (true, null);
        }
    }
}
