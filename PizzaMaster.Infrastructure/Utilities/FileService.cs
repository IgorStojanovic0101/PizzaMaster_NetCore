using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.Utilities
{
    public class FileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }


        public string UploadFile(IFormFile file,string folderPath)
        {

            string wwwRootPath = _hostEnvironment.ContentRootPath;


            string url = string.Empty;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, folderPath);
                var extension = Path.GetExtension(file.FileName);

                if (!string.IsNullOrEmpty(url))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, url.TrimStart('\\'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return folderPath+"\\" + filename + extension;
            }
            else
            {
                return url; // If no new file is uploaded, return the existing URL
            }
        }


        public string? ConvertImageToBase64(Image image)
        {
            if (image == null || string.IsNullOrEmpty(image.Url) || !File.Exists(image.Url))
            {
                return GetDefaultImageBase64();
            }
            var imageUrl = image.Url;

            string extension = GetFileExtensionFromUrl(imageUrl);

            byte[] imageBytes = File.ReadAllBytes(imageUrl);

            // Convert the byte array to a base64 string
            string base64Image = Convert.ToBase64String(imageBytes);

            // Create and return the base64 image URL
            return $"data:image/{extension};base64,{base64Image}";
        }

        private string GetDefaultImageBase64()
        {
            string wwwRootPath = _hostEnvironment.ContentRootPath;

            // Construct the correct path for the default image
            string defaultImagePath = Path.Combine(wwwRootPath, "Files", "images", "default", "defaultUserPhoto.jpg");

            // Provide default image data in base64 format
            byte[] defaultImageBytes = File.ReadAllBytes(defaultImagePath);

            string base64DefaultImage = Convert.ToBase64String(defaultImageBytes);

            return $"data:image/jpg;base64,{base64DefaultImage}";
        }

        public string? ConverVideoToBase64(string url)
        {
            

            string extension = GetFileExtensionFromUrl(url);

            byte[] videoBytes = File.ReadAllBytes(url);

            // Convert the byte array to a base64 string
            string base64Video = Convert.ToBase64String(videoBytes);

            // Create and return the base64 image URL
            return $"data:video/{extension};base64,{base64Video}";
        }




        public static string GetFileExtensionFromUrl(string url)
        {

            // Use Path.GetExtension to get the file extension from the URL
            string extension = Path.GetExtension(url);

            if (!string.IsNullOrEmpty(extension))
            {
                // Remove the leading dot (.) from the extension
                return extension.Substring(1);
            }


            return string.Empty; // Return an empty string if no extension is found
        }
    }
}
