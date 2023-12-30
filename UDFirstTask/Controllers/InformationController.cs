using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UDFirstTask.HelperMethods;
using UDFirstTask.DTOs;
using UDFirstTask.Repositories.Interfaces;
using UDFirstTask.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace UDFirstTask.Controllers
{
    [Authorize]
    public class InformationController : Controller
    {
        private readonly IInformationRepository _informationRepository;
        private readonly ILogger<InformationController> _logger;

        public InformationController(IInformationRepository informationRepository, ILogger<InformationController> logger)
        {
            _informationRepository = informationRepository;
            _logger = logger;
        }

        [UserTypeAuthorize("Admin","Client")]

        public async Task<ActionResult> Index()
        {
            try
            {
                var informationList = await _informationRepository.GetAllAsync();
                return View(informationList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching information for Index action");
                return RedirectToAction("ErrorHandler", "Error", new { statusCode = 500 });
            }
        }

        //  InformationController/Create
        [UserTypeAuthorize("Admin")]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveInfo(NewInformationDTO newInformation)
        {
            try
            {
                var image = newInformation.Image?.ImageFile;
                if (image != null)
                {
                    var validationResult = ImageHelper.ValidateImageFile(image);

                    if (!validationResult.isValid)
                    {
                        ModelState.AddModelError("Image.ImageFile", validationResult.errorMessage);
                    }
                }
                if (!ModelState.IsValid)
                {
                    return View("Create", newInformation);
                } 
           
                await _informationRepository.AddAsync(newInformation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the SaveInfo action");
                return RedirectToAction("ErrorHandler", "Error", new { statusCode = 500 });
            }
        }



        public async Task<ActionResult> ViewDetails(int id)
        {
            try
            {
                var informationEntity = await _informationRepository.GetByIdAsync(id);

                if (informationEntity == null)
                {
                    return View("~/Views/Shared/_PageNotFound.cshtml");
                }

                var information = new InformationDetailsDto
                {
                    EnglishTitle = informationEntity.EnglishTitle,
                    ArabicTitle = informationEntity.ArabicTitle,
                    EnglishDescription = informationEntity.EnglishDescription,
                    ArabicDescription = informationEntity.ArabicDescription,
                    ImagePath = informationEntity.ImagePath
                };

                return View(information);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the ViewDetails action");
                return RedirectToAction("ErrorHandler", "Error", new { statusCode = 500 });
            }
        }
    }

}
