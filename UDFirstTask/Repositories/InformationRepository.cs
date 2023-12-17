using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using UDFirstTask.Controllers;
using UDFirstTask.Data;
using UDFirstTask.DTOs;
using UDFirstTask.Models;
using UDFirstTask.Repositories.Interfaces;

namespace UDFirstTask.Repositories
{
    public class InformationRepository : IInformationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public InformationRepository(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _db = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<InformationDetailsDto> GetByIdAsync(int id)
        {
            var informationEntity = await _db.Informations.FindAsync(id);

            if (informationEntity == null)
            {
                return null;
            }

            var informationDTO = new InformationDetailsDto
            {
                EnglishTitle = informationEntity.EnglishTitle,
                ArabicTitle = informationEntity.ArabicTitle,
                EnglishDescription = informationEntity.EnglishDescription,
                ArabicDescription = informationEntity.ArabicDescription,
                ImagePath = informationEntity.ImagePath,
            };

            return informationDTO;
        }

        public async Task<IEnumerable<InformationDetailsDto>> GetAllAsync()
        {
            var informationEntities = await _db.Informations.ToListAsync();

            var informationDtos = informationEntities.Select(informationEntity => new InformationDetailsDto
            {
                Id= informationEntity.Id,
                EnglishTitle = informationEntity.EnglishTitle,
                ArabicTitle = informationEntity.ArabicTitle,
                EnglishDescription = informationEntity.EnglishDescription,
                ArabicDescription = informationEntity.ArabicDescription,
                ImagePath = informationEntity.ImagePath,
            });

            return informationDtos;
        }

        public async Task AddAsync(NewInformationDTO information)
        {
           
            if (information.Image.ImageFile!= null || information.Image.ImageFile.Length > 0)
            {
                var ImagePath = @"Images\Info";
                var uniqueImageName = Guid.NewGuid().ToString() + '_' + information.Image.ImageFile.FileName;
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, ImagePath, uniqueImageName);
                information.Image.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
                information.Image.ImagePath = Path.Combine(ImagePath, uniqueImageName);
            }

            var informationEntity = new Information
            {
                EnglishTitle = information.EnglishTitle,
                ArabicTitle = information.ArabicTitle,
                EnglishDescription = information.EnglishDescription,
                ArabicDescription = information.ArabicDescription,
                ImagePath = information.Image.ImagePath
            };

            _db.Informations.Add(informationEntity);
            await _db.SaveChangesAsync();
        }
    }
}